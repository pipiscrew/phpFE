using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phpFE
{
    public partial class Form1 : Form
    {

        //https://www.php.net/download-logos.php

        //php
        IntPtr appWinHandle = IntPtr.Zero;
        int appID = 0;

        //mysql
        IntPtr appMySQLWinHandle = IntPtr.Zero;
        int appMySQLID = 0;

        public Form1()
        {
            InitializeComponent();

            trayIcon.Text = this.Text = Application.ProductName + " v" + Application.ProductVersion;
            trayIcon.Icon = this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            General.appPath = Application.StartupPath + "\\";
        }


        private void Form1_Load(object sender, EventArgs e)
        {


            //   trayIcon.Icon = mailbox_desktop.Properties.Resources.gmail_blue;

            ////////////PHP
            int phpInstances = IsProcessActive("php");

            if (phpInstances == 0)
            {
                SetStatus2Controls("PHP", true);
            }
            else if (phpInstances > 0)
            {
                //appID = (from p in Process.GetProcesses()
                //         where p.ProcessName.Equals("php", StringComparison.OrdinalIgnoreCase)
                //         select p).First().Id;

                UpdateProcessPHP();
            }
            //else if (phpInstances > 1)
            //{
            //    General.Mes("Found that php.exe processes exist " + phpInstances + " times.\r\n\r\nPlease terminate existing php.exe instances and restart the application.", MessageBoxIcon.Exclamation);
            //    Application.Exit();
            //    return;
            //}

            ////////////MYSQ:
            int mysqlInstances = IsProcessActive("mysqld");

            if (mysqlInstances == 0)
            {
                SetStatus2Controls("MYSQL", true);
            }
            else if (mysqlInstances > 0)
            {
                //appMySQLID = (from p in Process.GetProcesses()
                //              where p.ProcessName.Equals("mysqld", StringComparison.OrdinalIgnoreCase)
                //              select p).First().Id;

                //SetStatus2Controls("MYSQL", false);

                UpdateProcessMySQL();
            }
            //else if (mysqlInstances > 1)
            //{ 
            //    General.Mes("Found that mysqld.exe processes exist " + mysqlInstances + " times.\r\n\r\nPlease terminate existing mysqld.exe instances and restart the application.", MessageBoxIcon.Exclamation);
            //    Application.Exit();
            //    return;
            //}

        }



        internal void UpdateProcessPHP()
        {
            int r;

            lblPHP.Text = General.GetProcesses("php", out r);

            if (r > 0)
            {
                //possible needs more validation here when comes from tray click (because can have multiple destination app instances)
                if (appID == 0)
                    appID = (from p in Process.GetProcesses()
                             where p.ProcessName.Equals("php", StringComparison.OrdinalIgnoreCase)
                             orderby p.Id
                             select p).First().Id;

                SetStatus2Controls("PHP", false);
            }
            else
            {
                SetStatus2Controls("PHP", true);
            }
        }

        //act as button + toolstrip event
        private void btnPHP_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ToolStripMenuItem))
                StartPHP((sender as ToolStripMenuItem).Text);
            else
                StartPHP((sender as Button).Text);
        }

        internal void StartPHP(string statusText)
        {
            int instances = IsProcessActive("php");

            if (statusText.Equals("start"))
            {
                if (instances > 0)
                {
                    UpdateProcessPHP();
                    //SetStatus2Controls("PHP", true);

                    //General.Mes("The php.exe processes already exist " + instances + " times, operation aborted.\r\n\r\nPlease terminate existing php.exe instances and press 'start' button.", MessageBoxIcon.Exclamation);
                    return;
                }

                if (!File.Exists(General.appPath + @"php\php.exe"))
                {
                    General.Mes("Couldn't find " + General.appPath + @"php\php.exe" + ", operation aborted.", MessageBoxIcon.Exclamation);
                    return;
                }

                if (!Directory.Exists(General.appPath + @"htdocs"))
                {
                    General.Mes("The `htdocs` folder doesnt exist\r\n\r\n" + General.appPath + @"htdocs" + "\r\n\r\nplease create it by hand, operation aborted.", MessageBoxIcon.Exclamation);
                    return;
                }

                object[] p = General.RunFile(@"php\php.exe", "-S localhost:80 -t ../htdocs/", @"php\");

                if (p == null)
                {
                    General.Mes("The file \r\n" + General.appPath + @"php\php.exe" + "'\r\ncouldn't start, operation aborted.", MessageBoxIcon.Exclamation);
                    return;
                }

                //store for later use               //used on :
                appWinHandle = (IntPtr)p[1];        //attach + Resize event
                appID = int.Parse(p[0].ToString()); //kill process

                //attach
                long h = API.SetParent(appWinHandle, tabPHP.Handle);
                var handleRef = new HandleRef(this, appWinHandle);
                API.SetWindowLongPtr(handleRef, API.GWL_STYLE, new IntPtr(API.WS_VISIBLE)); // Remove border and whatnot
                API.MoveWindow(appWinHandle, 0, 0, this.Width, this.Height, true);

                UpdateProcessPHP();

                return;
            }
            else ////////// STOP
            {
                if (instances > 0)
                {
                    try
                    {
                        //Process.GetProcessById(appID).Kill();
                        Process.GetProcesses().Where(x => x.ProcessName.Equals("php", StringComparison.OrdinalIgnoreCase)).ToList().ForEach(x => x.Kill());
                    }
                    catch
                    {
                        General.Mes("Couldn't find php.exe instance with process ID : " + appID + " , operation aborted.\r\n\r\nPlease terminate existing php.exe instances and press 'start' button.", MessageBoxIcon.Exclamation);
                    }


                }
                else
                {
                    General.Mes("No php.exe instance found, operation aborted.", MessageBoxIcon.Exclamation);
                }

                //lblPHPled.BackColor = Color.Crimson;
                //btnPHP.Text = "start";

                appID = 0;
                appWinHandle = IntPtr.Zero;

                System.Threading.Thread.Sleep(200);

                UpdateProcessPHP();

            }
        }

        //////// MYSQL ///////////////


        internal void UpdateProcessMySQL()
        {
            int r;

            lblMYSQL.Text = General.GetProcesses("mysqld", out r);

            if (r > 0)
            {
                //possible needs more validation here when comes from tray click

                //get the earliest one
                if (appMySQLID == 0)
                    appMySQLID = (from p in Process.GetProcesses()
                                  where p.ProcessName.Equals("mysqld", StringComparison.OrdinalIgnoreCase)
                                  orderby p.Id
                                  select p).First().Id;

                SetStatus2Controls("MYSQL", false);
            }
            else
            {
                SetStatus2Controls("MYSQL", true);
            }
        }

        internal int IsProcessActive(string processName)
        {
            return (from p in Process.GetProcesses()
                    where p.ProcessName.Equals(processName, StringComparison.OrdinalIgnoreCase)
                    select p).Count();
        }

        private void btnMYSQL_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ToolStripMenuItem))
                StartMYSQL((sender as ToolStripMenuItem).Text);
            else
                StartMYSQL((sender as Button).Text);
        }

        internal void StartMYSQL(string statusText)
        {
            int instances = IsProcessActive("mysqld");

            if (statusText.Equals("start"))
            {
                if (instances > 0)
                {
                    //SetStatus2Controls("MYSQL", true);

                    //General.Mes("The mysqld.exe process already exist, operation aborted.\r\n\r\nPlease terminate existing mysqld.exe instance and press 'start' button.", MessageBoxIcon.Exclamation);
                    //return;
                    UpdateProcessMySQL();
                }

                if (!File.Exists(General.appPath + @"mysql\bin\mysqld.exe"))
                {
                    General.Mes("Couldn't find " + General.appPath + @"mysql\bin\mysqld.exe" + ", operation aborted.", MessageBoxIcon.Exclamation);
                    return;
                }

                object[] p = General.RunFile(@"mysql\bin\mysqld.exe", "", @"mysql\bin\");

                if (p == null)
                {
                    General.Mes("The file \r\n" + General.appPath + @"mysql\bin\mysqld.exe" + "'\r\ncouldn't start, operation aborted.", MessageBoxIcon.Exclamation);
                    return;
                }

                //store for later use               //used on :
                appMySQLWinHandle = (IntPtr)p[1];        //attach + Resize event
                appMySQLID = int.Parse(p[0].ToString()); //kill process

                //attach
                long h = API.SetParent(appMySQLWinHandle, tabMySQL.Handle);
                var handleRef = new HandleRef(this, appMySQLWinHandle);
                API.SetWindowLongPtr(handleRef, API.GWL_STYLE, new IntPtr(API.WS_VISIBLE)); // Remove border and whatnot
                API.MoveWindow(appMySQLWinHandle, 0, 0, this.Width, this.Height, true);

                UpdateProcessMySQL();

                return;
            }
            else ////////// STOP
            {
                if (instances > 0)
                {
                    try
                    {
                        Process.GetProcesses().Where(x => x.ProcessName.Equals("mysqld", StringComparison.OrdinalIgnoreCase)).ToList().ForEach(x => x.Kill());
                        //Process.GetProcessById(appMySQLID).Kill();
                    }
                    catch
                    {
                        General.Mes("Couldn't find mysqld.exe instance with process ID : " + appMySQLID + " , operation aborted.\r\n\r\nPlease terminate existing mysqld.exe instances and press 'start' button.", MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    General.Mes("No mysqld.exe instance found, operation aborted.", MessageBoxIcon.Exclamation);
                }

                //lblMYSQLled.BackColor = Color.Crimson;
                //btnMYSQL.Text = "start";

                appMySQLID = 0;
                appMySQLWinHandle = IntPtr.Zero;

                System.Threading.Thread.Sleep(200);

                UpdateProcessMySQL();

            }
        }

        //Function for tray icon
        //also on Form properties : WindowsState : Minimized | ShowInTaskbar = false
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                hide2tray();
            }
            else
            {
                if (this.appWinHandle != IntPtr.Zero)
                {
                    API.MoveWindow(appWinHandle, 0, 0, this.tabPHP.Width, tabPHP.Height - 20, true);
                }

                if (this.appMySQLWinHandle != IntPtr.Zero)
                {
                    API.MoveWindow(appMySQLWinHandle, 0, 0, this.tabMySQL.Width, tabMySQL.Height - 20, true);
                }
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                hide2tray();
            }
        }

        private void show_form()
        {
            //this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;

            // Set foreground window.
            API.SetForegroundWindow(this.Handle);
        }

        private void hide2tray()
        {
            //to minimize window
            this.WindowState = FormWindowState.Minimized;

            //to hide from taskbar
            // this.ShowInTaskbar = false;
            this.Hide();
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateProcessPHP();

            UpdateProcessMySQL();

            //by default left click show form
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                show_form();
            }
            //on right shows the context menu associated, no code needed.

        }

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        internal void SetStatus2Controls(string itemText, bool isStopped)
        {
            if (isStopped)
            {
                switch (itemText.ToUpper())
                {
                    case "PHP":
                        toolStripPHP.Image = phpFE.Properties.Resources.stop;
                        toolStripPHPStartStop.Text = "start";
                        //form ctls
                        lblPHPled.BackColor = Color.Crimson;
                        btnPHP.Text = "start";
                        break;
                    case "MYSQL":
                        toolStripMYSQL.Image = phpFE.Properties.Resources.stop;
                        toolStripMYSQLStartStop.Text = "start";
                        //form ctls
                        lblMYSQLled.BackColor = Color.Crimson;
                        btnMYSQL.Text = "start";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (itemText.ToUpper())
                {
                    case "PHP":
                        toolStripPHP.Image = phpFE.Properties.Resources.start;
                        toolStripPHPStartStop.Text = "stop";
                        //form ctls
                        lblPHPled.BackColor = Color.DarkSeaGreen;
                        btnPHP.Text = "stop";
                        break;
                    case "MYSQL":
                        toolStripMYSQL.Image = phpFE.Properties.Resources.start;
                        toolStripMYSQLStartStop.Text = "stop";
                        //form ctls
                        lblMYSQLled.BackColor = Color.DarkSeaGreen;
                        btnMYSQL.Text = "stop";
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateProcessPHP();

            UpdateProcessMySQL();
        }

    }
}

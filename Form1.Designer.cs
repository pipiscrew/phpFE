namespace phpFE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelOptions = new System.Windows.Forms.Panel();
            this.lblMYSQL = new System.Windows.Forms.Label();
            this.btnMYSQL = new System.Windows.Forms.Button();
            this.lblMYSQLled = new System.Windows.Forms.Label();
            this.lblPHP = new System.Windows.Forms.Label();
            this.btnPHP = new System.Windows.Forms.Button();
            this.lblPHPled = new System.Windows.Forms.Label();
            this.panelPHP = new System.Windows.Forms.Panel();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPHP = new System.Windows.Forms.TabPage();
            this.tabMySQL = new System.Windows.Forms.TabPage();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripPHP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPHPStartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMYSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMYSQLStartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelOptions.SuspendLayout();
            this.panelPHP.SuspendLayout();
            this.tab.SuspendLayout();
            this.trayContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOptions
            // 
            this.panelOptions.Controls.Add(this.btnRefresh);
            this.panelOptions.Controls.Add(this.lblMYSQL);
            this.panelOptions.Controls.Add(this.btnMYSQL);
            this.panelOptions.Controls.Add(this.lblMYSQLled);
            this.panelOptions.Controls.Add(this.lblPHP);
            this.panelOptions.Controls.Add(this.btnPHP);
            this.panelOptions.Controls.Add(this.lblPHPled);
            this.panelOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOptions.Location = new System.Drawing.Point(0, 0);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(721, 187);
            this.panelOptions.TabIndex = 0;
            // 
            // lblMYSQL
            // 
            this.lblMYSQL.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lblMYSQL.Location = new System.Drawing.Point(208, 74);
            this.lblMYSQL.Name = "lblMYSQL";
            this.lblMYSQL.Size = new System.Drawing.Size(255, 16);
            this.lblMYSQL.TabIndex = 5;
            this.lblMYSQL.Text = "stat";
            // 
            // btnMYSQL
            // 
            this.btnMYSQL.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnMYSQL.Location = new System.Drawing.Point(113, 71);
            this.btnMYSQL.Name = "btnMYSQL";
            this.btnMYSQL.Size = new System.Drawing.Size(75, 23);
            this.btnMYSQL.TabIndex = 4;
            this.btnMYSQL.Text = "start";
            this.btnMYSQL.UseVisualStyleBackColor = true;
            this.btnMYSQL.Click += new System.EventHandler(this.btnMYSQL_Click);
            // 
            // lblMYSQLled
            // 
            this.lblMYSQLled.Location = new System.Drawing.Point(22, 71);
            this.lblMYSQLled.Name = "lblMYSQLled";
            this.lblMYSQLled.Size = new System.Drawing.Size(57, 21);
            this.lblMYSQLled.TabIndex = 3;
            // 
            // lblPHP
            // 
            this.lblPHP.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lblPHP.Location = new System.Drawing.Point(208, 26);
            this.lblPHP.Name = "lblPHP";
            this.lblPHP.Size = new System.Drawing.Size(255, 16);
            this.lblPHP.TabIndex = 2;
            this.lblPHP.Text = "stat";
            // 
            // btnPHP
            // 
            this.btnPHP.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnPHP.Location = new System.Drawing.Point(113, 23);
            this.btnPHP.Name = "btnPHP";
            this.btnPHP.Size = new System.Drawing.Size(75, 23);
            this.btnPHP.TabIndex = 1;
            this.btnPHP.Text = "start";
            this.btnPHP.UseVisualStyleBackColor = true;
            this.btnPHP.Click += new System.EventHandler(this.btnPHP_Click);
            // 
            // lblPHPled
            // 
            this.lblPHPled.Location = new System.Drawing.Point(22, 23);
            this.lblPHPled.Name = "lblPHPled";
            this.lblPHPled.Size = new System.Drawing.Size(57, 21);
            this.lblPHPled.TabIndex = 0;
            // 
            // panelPHP
            // 
            this.panelPHP.Controls.Add(this.tab);
            this.panelPHP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPHP.Location = new System.Drawing.Point(0, 187);
            this.panelPHP.Name = "panelPHP";
            this.panelPHP.Size = new System.Drawing.Size(721, 232);
            this.panelPHP.TabIndex = 1;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPHP);
            this.tab.Controls.Add(this.tabMySQL);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(721, 232);
            this.tab.TabIndex = 0;
            // 
            // tabPHP
            // 
            this.tabPHP.Location = new System.Drawing.Point(4, 23);
            this.tabPHP.Name = "tabPHP";
            this.tabPHP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPHP.Size = new System.Drawing.Size(713, 205);
            this.tabPHP.TabIndex = 0;
            this.tabPHP.Text = "php";
            this.tabPHP.UseVisualStyleBackColor = true;
            // 
            // tabMySQL
            // 
            this.tabMySQL.Location = new System.Drawing.Point(4, 23);
            this.tabMySQL.Name = "tabMySQL";
            this.tabMySQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabMySQL.Size = new System.Drawing.Size(713, 205);
            this.tabMySQL.TabIndex = 1;
            this.tabMySQL.Text = "mysql";
            this.tabMySQL.UseVisualStyleBackColor = true;
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayContext;
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayContext
            // 
            this.trayContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPHP,
            this.toolStripMYSQL,
            this.toolStripSeparator2,
            this.toolStripExit});
            this.trayContext.Name = "trayContext";
            this.trayContext.Size = new System.Drawing.Size(113, 76);
            // 
            // toolStripPHP
            // 
            this.toolStripPHP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPHPStartStop});
            this.toolStripPHP.Name = "toolStripPHP";
            this.toolStripPHP.Size = new System.Drawing.Size(112, 22);
            this.toolStripPHP.Text = "PHP";
            // 
            // toolStripPHPStartStop
            // 
            this.toolStripPHPStartStop.Name = "toolStripPHPStartStop";
            this.toolStripPHPStartStop.Size = new System.Drawing.Size(84, 22);
            this.toolStripPHPStartStop.Text = "--";
            this.toolStripPHPStartStop.Click += new System.EventHandler(this.btnPHP_Click);
            // 
            // toolStripMYSQL
            // 
            this.toolStripMYSQL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMYSQLStartStop});
            this.toolStripMYSQL.Name = "toolStripMYSQL";
            this.toolStripMYSQL.Size = new System.Drawing.Size(112, 22);
            this.toolStripMYSQL.Text = "MySQL";
            // 
            // toolStripMYSQLStartStop
            // 
            this.toolStripMYSQLStartStop.Name = "toolStripMYSQLStartStop";
            this.toolStripMYSQLStartStop.Size = new System.Drawing.Size(84, 22);
            this.toolStripMYSQLStartStop.Text = "--";
            this.toolStripMYSQLStartStop.Click += new System.EventHandler(this.btnMYSQL_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(109, 6);
            // 
            // toolStripExit
            // 
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Size = new System.Drawing.Size(112, 22);
            this.toolStripExit.Text = "exit";
            this.toolStripExit.Click += new System.EventHandler(this.toolStripExit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(529, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(49, 36);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 419);
            this.Controls.Add(this.panelPHP);
            this.Controls.Add(this.panelOptions);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panelOptions.ResumeLayout(false);
            this.panelPHP.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.trayContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Panel panelPHP;
        private System.Windows.Forms.Button btnPHP;
        private System.Windows.Forms.Label lblPHPled;
        private System.Windows.Forms.Label lblPHP;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPHP;
        private System.Windows.Forms.TabPage tabMySQL;
        private System.Windows.Forms.Label lblMYSQL;
        private System.Windows.Forms.Button btnMYSQL;
        private System.Windows.Forms.Label lblMYSQLled;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayContext;
        private System.Windows.Forms.ToolStripMenuItem toolStripPHP;
        private System.Windows.Forms.ToolStripMenuItem toolStripPHPStartStop;
        private System.Windows.Forms.ToolStripMenuItem toolStripMYSQL;
        private System.Windows.Forms.ToolStripMenuItem toolStripMYSQLStartStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripExit;
        private System.Windows.Forms.Button btnRefresh;

    }
}


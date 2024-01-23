
namespace HallamBellemare_TicTacToeClient
{
	partial class ServerConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConnectionForm));
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_quit = new System.Windows.Forms.Button();
            this.txtbx_serverPort = new System.Windows.Forms.TextBox();
            this.lbl_serverIP = new System.Windows.Forms.Label();
            this.lbl_serverPort = new System.Windows.Forms.Label();
            this.txtbx_serverIP = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_username = new System.Windows.Forms.Label();
            this.txtbx_username = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkbx_rememberInfo = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_connect.Enabled = false;
            this.btn_connect.Location = new System.Drawing.Point(0, 0);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(106, 30);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_quit
            // 
            this.btn_quit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_quit.Location = new System.Drawing.Point(3, 108);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(58, 30);
            this.btn_quit.TabIndex = 1;
            this.btn_quit.Text = "Quit";
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // txtbx_serverPort
            // 
            this.txtbx_serverPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbx_serverPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_serverPort.Location = new System.Drawing.Point(67, 38);
            this.txtbx_serverPort.MaxLength = 5;
            this.txtbx_serverPort.Name = "txtbx_serverPort";
            this.txtbx_serverPort.Size = new System.Drawing.Size(214, 23);
            this.txtbx_serverPort.TabIndex = 3;
            this.txtbx_serverPort.TextChanged += new System.EventHandler(this.validateInputs);
            // 
            // lbl_serverIP
            // 
            this.lbl_serverIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_serverIP.AutoSize = true;
            this.lbl_serverIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_serverIP.Location = new System.Drawing.Point(25, 0);
            this.lbl_serverIP.Name = "lbl_serverIP";
            this.lbl_serverIP.Size = new System.Drawing.Size(36, 25);
            this.lbl_serverIP.TabIndex = 0;
            this.lbl_serverIP.Text = "IP:";
            // 
            // lbl_serverPort
            // 
            this.lbl_serverPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_serverPort.AutoSize = true;
            this.lbl_serverPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_serverPort.Location = new System.Drawing.Point(8, 35);
            this.lbl_serverPort.Name = "lbl_serverPort";
            this.lbl_serverPort.Size = new System.Drawing.Size(53, 25);
            this.lbl_serverPort.TabIndex = 3;
            this.lbl_serverPort.Text = "Port:";
            // 
            // txtbx_serverIP
            // 
            this.txtbx_serverIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbx_serverIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_serverIP.Location = new System.Drawing.Point(67, 3);
            this.txtbx_serverIP.MaxLength = 15;
            this.txtbx_serverIP.Name = "txtbx_serverIP";
            this.txtbx_serverIP.Size = new System.Drawing.Size(214, 23);
            this.txtbx_serverIP.TabIndex = 2;
            this.txtbx_serverIP.TextChanged += new System.EventHandler(this.validateInputs);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.88732F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.11268F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_serverPort, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtbx_serverPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_serverIP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtbx_serverIP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_quit, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_username, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtbx_username, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 141);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lbl_username
            // 
            this.lbl_username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.Location = new System.Drawing.Point(8, 70);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(53, 35);
            this.lbl_username.TabIndex = 4;
            this.lbl_username.Text = "User:";
            // 
            // txtbx_username
            // 
            this.txtbx_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbx_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_username.Location = new System.Drawing.Point(67, 73);
            this.txtbx_username.MaxLength = 16;
            this.txtbx_username.Name = "txtbx_username";
            this.txtbx_username.Size = new System.Drawing.Size(214, 23);
            this.txtbx_username.TabIndex = 5;
            this.txtbx_username.TextChanged += new System.EventHandler(this.validateInputs);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(67, 108);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkbx_rememberInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_connect);
            this.splitContainer1.Size = new System.Drawing.Size(214, 30);
            this.splitContainer1.SplitterDistance = 104;
            this.splitContainer1.TabIndex = 6;
            // 
            // chkbx_rememberInfo
            // 
            this.chkbx_rememberInfo.AutoSize = true;
            this.chkbx_rememberInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkbx_rememberInfo.Location = new System.Drawing.Point(0, 0);
            this.chkbx_rememberInfo.Name = "chkbx_rememberInfo";
            this.chkbx_rememberInfo.Size = new System.Drawing.Size(104, 30);
            this.chkbx_rememberInfo.TabIndex = 0;
            this.chkbx_rememberInfo.Text = "Remember Me?";
            this.chkbx_rememberInfo.UseVisualStyleBackColor = true;
            // 
            // ServerConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 180);
            this.MinimumSize = new System.Drawing.Size(300, 180);
            this.Name = "ServerConnectionForm";
            this.Text = "Connect to Server...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerConnectionForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerConnectionForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_connect;
		private System.Windows.Forms.Button btn_quit;
		private System.Windows.Forms.TextBox txtbx_serverPort;
		private System.Windows.Forms.Label lbl_serverIP;
		private System.Windows.Forms.Label lbl_serverPort;
		private System.Windows.Forms.TextBox txtbx_serverIP;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.TextBox txtbx_username;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkbx_rememberInfo;
    }
}


namespace HallamBellemare_TicTacToeClient
{
    partial class GameListForm
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
            this.btn_TEMPBypass = new System.Windows.Forms.Button();
            this.btn_logOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_TEMPBypass
            // 
            this.btn_TEMPBypass.Location = new System.Drawing.Point(713, 386);
            this.btn_TEMPBypass.Name = "btn_TEMPBypass";
            this.btn_TEMPBypass.Size = new System.Drawing.Size(75, 23);
            this.btn_TEMPBypass.TabIndex = 0;
            this.btn_TEMPBypass.Text = "BYPASS";
            this.btn_TEMPBypass.UseVisualStyleBackColor = true;
            this.btn_TEMPBypass.Click += new System.EventHandler(this.btn_TEMPBypass_Click);
            // 
            // btn_logOut
            // 
            this.btn_logOut.Location = new System.Drawing.Point(713, 415);
            this.btn_logOut.Name = "btn_logOut";
            this.btn_logOut.Size = new System.Drawing.Size(75, 23);
            this.btn_logOut.TabIndex = 1;
            this.btn_logOut.Text = "Log Out";
            this.btn_logOut.UseVisualStyleBackColor = true;
            this.btn_logOut.Click += new System.EventHandler(this.btn_logOut_Click);
            // 
            // GameListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_logOut);
            this.Controls.Add(this.btn_TEMPBypass);
            this.Name = "GameListForm";
            this.Text = "GameListForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameListForm_FormClosing);
            this.Load += new System.EventHandler(this.GameListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_TEMPBypass;
        private System.Windows.Forms.Button btn_logOut;
    }
}
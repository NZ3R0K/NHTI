
namespace HallamBellemare_TicTacToeClient
{
    partial class TTTGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TTTGameForm));
            this.tbllLotPnl_mainGame = new System.Windows.Forms.TableLayoutPanel();
            this.btn_TTTSlot0 = new System.Windows.Forms.Button();
            this.btn_TTTSlot1 = new System.Windows.Forms.Button();
            this.btn_TTTSlot2 = new System.Windows.Forms.Button();
            this.btn_TTTSlot3 = new System.Windows.Forms.Button();
            this.btn_TTTSlot4 = new System.Windows.Forms.Button();
            this.btn_TTTSlot5 = new System.Windows.Forms.Button();
            this.btn_TTTSlot6 = new System.Windows.Forms.Button();
            this.btn_TTTSlot7 = new System.Windows.Forms.Button();
            this.btn_TTTSlot8 = new System.Windows.Forms.Button();
            this.statsstrp_gameStatus = new System.Windows.Forms.StatusStrip();
            this.tlstrplbl_gameStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlstrp_gameControlStrip = new System.Windows.Forms.ToolStrip();
            this.tlstrpbtn_leaveGame = new System.Windows.Forms.ToolStripButton();
            this.lbl_clientName = new System.Windows.Forms.Label();
            this.lbl_opponentName = new System.Windows.Forms.Label();
            this.tmr_buttonLock = new System.Windows.Forms.Timer(this.components);
            this.tbllLotPnl_mainGame.SuspendLayout();
            this.statsstrp_gameStatus.SuspendLayout();
            this.tlstrp_gameControlStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbllLotPnl_mainGame
            // 
            this.tbllLotPnl_mainGame.AutoSize = true;
            this.tbllLotPnl_mainGame.ColumnCount = 3;
            this.tbllLotPnl_mainGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbllLotPnl_mainGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbllLotPnl_mainGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbllLotPnl_mainGame.Controls.Add(this.btn_TTTSlot0, 0, 0);
            this.tbllLotPnl_mainGame.Controls.Add(this.btn_TTTSlot1, 1, 0);
            this.tbllLotPnl_mainGame.Controls.Add(this.btn_TTTSlot2, 2, 0);
            this.tbllLotPnl_mainGame.Controls.Add(this.btn_TTTSlot3, 0, 1);
            this.tbllLotPnl_mainGame.Controls.Add(this.btn_TTTSlot4, 1, 1);
            this.tbllLotPnl_mainGame.Controls.Add(this.btn_TTTSlot5, 2, 1);
            this.tbllLotPnl_mainGame.Controls.Add(this.btn_TTTSlot6, 0, 2);
            this.tbllLotPnl_mainGame.Controls.Add(this.btn_TTTSlot7, 1, 2);
            this.tbllLotPnl_mainGame.Controls.Add(this.btn_TTTSlot8, 2, 2);
            this.tbllLotPnl_mainGame.Location = new System.Drawing.Point(12, 43);
            this.tbllLotPnl_mainGame.Name = "tbllLotPnl_mainGame";
            this.tbllLotPnl_mainGame.RowCount = 3;
            this.tbllLotPnl_mainGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbllLotPnl_mainGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbllLotPnl_mainGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbllLotPnl_mainGame.Size = new System.Drawing.Size(402, 402);
            this.tbllLotPnl_mainGame.TabIndex = 0;
            // 
            // btn_TTTSlot0
            // 
            this.btn_TTTSlot0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TTTSlot0.Enabled = false;
            this.btn_TTTSlot0.Font = new System.Drawing.Font("Perpetua Titling MT", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TTTSlot0.Location = new System.Drawing.Point(3, 3);
            this.btn_TTTSlot0.Name = "btn_TTTSlot0";
            this.btn_TTTSlot0.Size = new System.Drawing.Size(128, 128);
            this.btn_TTTSlot0.TabIndex = 0;
            this.btn_TTTSlot0.Tag = "0";
            this.btn_TTTSlot0.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_TTTSlot0.UseVisualStyleBackColor = true;
            this.btn_TTTSlot0.Click += new System.EventHandler(this.TakeSlot);
            // 
            // btn_TTTSlot1
            // 
            this.btn_TTTSlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TTTSlot1.Enabled = false;
            this.btn_TTTSlot1.Font = new System.Drawing.Font("Perpetua Titling MT", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TTTSlot1.Location = new System.Drawing.Point(137, 3);
            this.btn_TTTSlot1.Name = "btn_TTTSlot1";
            this.btn_TTTSlot1.Size = new System.Drawing.Size(128, 128);
            this.btn_TTTSlot1.TabIndex = 1;
            this.btn_TTTSlot1.Tag = "1";
            this.btn_TTTSlot1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_TTTSlot1.UseVisualStyleBackColor = true;
            this.btn_TTTSlot1.Click += new System.EventHandler(this.TakeSlot);
            // 
            // btn_TTTSlot2
            // 
            this.btn_TTTSlot2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TTTSlot2.Enabled = false;
            this.btn_TTTSlot2.Font = new System.Drawing.Font("Perpetua Titling MT", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TTTSlot2.Location = new System.Drawing.Point(271, 3);
            this.btn_TTTSlot2.Name = "btn_TTTSlot2";
            this.btn_TTTSlot2.Size = new System.Drawing.Size(128, 128);
            this.btn_TTTSlot2.TabIndex = 2;
            this.btn_TTTSlot2.Tag = "2";
            this.btn_TTTSlot2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_TTTSlot2.UseVisualStyleBackColor = true;
            this.btn_TTTSlot2.Click += new System.EventHandler(this.TakeSlot);
            // 
            // btn_TTTSlot3
            // 
            this.btn_TTTSlot3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TTTSlot3.Enabled = false;
            this.btn_TTTSlot3.Font = new System.Drawing.Font("Perpetua Titling MT", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TTTSlot3.Location = new System.Drawing.Point(3, 137);
            this.btn_TTTSlot3.Name = "btn_TTTSlot3";
            this.btn_TTTSlot3.Size = new System.Drawing.Size(128, 128);
            this.btn_TTTSlot3.TabIndex = 3;
            this.btn_TTTSlot3.Tag = "3";
            this.btn_TTTSlot3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_TTTSlot3.UseVisualStyleBackColor = true;
            this.btn_TTTSlot3.Click += new System.EventHandler(this.TakeSlot);
            // 
            // btn_TTTSlot4
            // 
            this.btn_TTTSlot4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TTTSlot4.Enabled = false;
            this.btn_TTTSlot4.Font = new System.Drawing.Font("Perpetua Titling MT", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TTTSlot4.Location = new System.Drawing.Point(137, 137);
            this.btn_TTTSlot4.Name = "btn_TTTSlot4";
            this.btn_TTTSlot4.Size = new System.Drawing.Size(128, 128);
            this.btn_TTTSlot4.TabIndex = 4;
            this.btn_TTTSlot4.Tag = "4";
            this.btn_TTTSlot4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_TTTSlot4.UseVisualStyleBackColor = true;
            this.btn_TTTSlot4.Click += new System.EventHandler(this.TakeSlot);
            // 
            // btn_TTTSlot5
            // 
            this.btn_TTTSlot5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TTTSlot5.Enabled = false;
            this.btn_TTTSlot5.Font = new System.Drawing.Font("Perpetua Titling MT", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TTTSlot5.Location = new System.Drawing.Point(271, 137);
            this.btn_TTTSlot5.Name = "btn_TTTSlot5";
            this.btn_TTTSlot5.Size = new System.Drawing.Size(128, 128);
            this.btn_TTTSlot5.TabIndex = 5;
            this.btn_TTTSlot5.Tag = "5";
            this.btn_TTTSlot5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_TTTSlot5.UseVisualStyleBackColor = true;
            this.btn_TTTSlot5.Click += new System.EventHandler(this.TakeSlot);
            // 
            // btn_TTTSlot6
            // 
            this.btn_TTTSlot6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TTTSlot6.Enabled = false;
            this.btn_TTTSlot6.Font = new System.Drawing.Font("Perpetua Titling MT", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TTTSlot6.Location = new System.Drawing.Point(3, 271);
            this.btn_TTTSlot6.Name = "btn_TTTSlot6";
            this.btn_TTTSlot6.Size = new System.Drawing.Size(128, 128);
            this.btn_TTTSlot6.TabIndex = 6;
            this.btn_TTTSlot6.Tag = "6";
            this.btn_TTTSlot6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_TTTSlot6.UseVisualStyleBackColor = true;
            this.btn_TTTSlot6.Click += new System.EventHandler(this.TakeSlot);
            // 
            // btn_TTTSlot7
            // 
            this.btn_TTTSlot7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TTTSlot7.Enabled = false;
            this.btn_TTTSlot7.Font = new System.Drawing.Font("Perpetua Titling MT", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TTTSlot7.Location = new System.Drawing.Point(137, 271);
            this.btn_TTTSlot7.Name = "btn_TTTSlot7";
            this.btn_TTTSlot7.Size = new System.Drawing.Size(128, 128);
            this.btn_TTTSlot7.TabIndex = 7;
            this.btn_TTTSlot7.Tag = "7";
            this.btn_TTTSlot7.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_TTTSlot7.UseVisualStyleBackColor = true;
            this.btn_TTTSlot7.Click += new System.EventHandler(this.TakeSlot);
            // 
            // btn_TTTSlot8
            // 
            this.btn_TTTSlot8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TTTSlot8.Enabled = false;
            this.btn_TTTSlot8.Font = new System.Drawing.Font("Perpetua Titling MT", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TTTSlot8.Location = new System.Drawing.Point(271, 271);
            this.btn_TTTSlot8.Name = "btn_TTTSlot8";
            this.btn_TTTSlot8.Size = new System.Drawing.Size(128, 128);
            this.btn_TTTSlot8.TabIndex = 8;
            this.btn_TTTSlot8.Tag = "8";
            this.btn_TTTSlot8.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_TTTSlot8.UseVisualStyleBackColor = true;
            this.btn_TTTSlot8.Click += new System.EventHandler(this.TakeSlot);
            // 
            // statsstrp_gameStatus
            // 
            this.statsstrp_gameStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrplbl_gameStatus});
            this.statsstrp_gameStatus.Location = new System.Drawing.Point(0, 459);
            this.statsstrp_gameStatus.Name = "statsstrp_gameStatus";
            this.statsstrp_gameStatus.Size = new System.Drawing.Size(429, 22);
            this.statsstrp_gameStatus.TabIndex = 4;
            // 
            // tlstrplbl_gameStatus
            // 
            this.tlstrplbl_gameStatus.Name = "tlstrplbl_gameStatus";
            this.tlstrplbl_gameStatus.Size = new System.Drawing.Size(39, 17);
            this.tlstrplbl_gameStatus.Text = "Status";
            // 
            // tlstrp_gameControlStrip
            // 
            this.tlstrp_gameControlStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpbtn_leaveGame});
            this.tlstrp_gameControlStrip.Location = new System.Drawing.Point(0, 0);
            this.tlstrp_gameControlStrip.Name = "tlstrp_gameControlStrip";
            this.tlstrp_gameControlStrip.Size = new System.Drawing.Size(429, 25);
            this.tlstrp_gameControlStrip.TabIndex = 5;
            this.tlstrp_gameControlStrip.Text = "toolStrip1";
            // 
            // tlstrpbtn_leaveGame
            // 
            this.tlstrpbtn_leaveGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlstrpbtn_leaveGame.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpbtn_leaveGame.Image")));
            this.tlstrpbtn_leaveGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpbtn_leaveGame.Name = "tlstrpbtn_leaveGame";
            this.tlstrpbtn_leaveGame.Size = new System.Drawing.Size(41, 22);
            this.tlstrpbtn_leaveGame.Text = "Leave";
            this.tlstrpbtn_leaveGame.Click += new System.EventHandler(this.btn_leaveGame_Click);
            // 
            // lbl_clientName
            // 
            this.lbl_clientName.AutoSize = true;
            this.lbl_clientName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_clientName.Location = new System.Drawing.Point(0, 25);
            this.lbl_clientName.Name = "lbl_clientName";
            this.lbl_clientName.Size = new System.Drawing.Size(32, 13);
            this.lbl_clientName.TabIndex = 6;
            this.lbl_clientName.Text = "You: ";
            // 
            // lbl_opponentName
            // 
            this.lbl_opponentName.AutoSize = true;
            this.lbl_opponentName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_opponentName.Location = new System.Drawing.Point(375, 25);
            this.lbl_opponentName.Name = "lbl_opponentName";
            this.lbl_opponentName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_opponentName.Size = new System.Drawing.Size(54, 13);
            this.lbl_opponentName.TabIndex = 7;
            this.lbl_opponentName.Text = "Opponent";
            this.lbl_opponentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TTTGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 481);
            this.Controls.Add(this.lbl_opponentName);
            this.Controls.Add(this.lbl_clientName);
            this.Controls.Add(this.tlstrp_gameControlStrip);
            this.Controls.Add(this.statsstrp_gameStatus);
            this.Controls.Add(this.tbllLotPnl_mainGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(445, 520);
            this.MinimumSize = new System.Drawing.Size(445, 500);
            this.Name = "TTTGameForm";
            this.Text = "TicTacToe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TTTGameForm_FormClosing);
            this.Load += new System.EventHandler(this.TTTGameForm_Load);
            this.tbllLotPnl_mainGame.ResumeLayout(false);
            this.statsstrp_gameStatus.ResumeLayout(false);
            this.statsstrp_gameStatus.PerformLayout();
            this.tlstrp_gameControlStrip.ResumeLayout(false);
            this.tlstrp_gameControlStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbllLotPnl_mainGame;
        private System.Windows.Forms.Button btn_TTTSlot0;
        private System.Windows.Forms.Button btn_TTTSlot1;
        private System.Windows.Forms.Button btn_TTTSlot2;
        private System.Windows.Forms.Button btn_TTTSlot3;
        private System.Windows.Forms.Button btn_TTTSlot4;
        private System.Windows.Forms.Button btn_TTTSlot5;
        private System.Windows.Forms.Button btn_TTTSlot6;
        private System.Windows.Forms.Button btn_TTTSlot7;
        private System.Windows.Forms.Button btn_TTTSlot8;
        protected System.Windows.Forms.StatusStrip statsstrp_gameStatus;
        private System.Windows.Forms.ToolStripStatusLabel tlstrplbl_gameStatus;
        private System.Windows.Forms.ToolStrip tlstrp_gameControlStrip;
        private System.Windows.Forms.ToolStripButton tlstrpbtn_leaveGame;
        private System.Windows.Forms.Label lbl_clientName;
        private System.Windows.Forms.Label lbl_opponentName;
        private System.Windows.Forms.Timer tmr_buttonLock;
    }
}
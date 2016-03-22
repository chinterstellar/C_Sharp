namespace Minesweeper
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.遊戲ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.初級ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中級ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高級ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrCounter = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblView = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_mines = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.遊戲ToolStripMenuItem,
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 遊戲ToolStripMenuItem
            // 
            this.遊戲ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.初級ToolStripMenuItem,
            this.中級ToolStripMenuItem,
            this.高級ToolStripMenuItem});
            this.遊戲ToolStripMenuItem.Name = "遊戲ToolStripMenuItem";
            this.遊戲ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.遊戲ToolStripMenuItem.Text = "遊戲";
            // 
            // 初級ToolStripMenuItem
            // 
            this.初級ToolStripMenuItem.Name = "初級ToolStripMenuItem";
            this.初級ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.初級ToolStripMenuItem.Text = "初級";
            this.初級ToolStripMenuItem.Click += new System.EventHandler(this.初級ToolStripMenuItem_Click);
            // 
            // 中級ToolStripMenuItem
            // 
            this.中級ToolStripMenuItem.Name = "中級ToolStripMenuItem";
            this.中級ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.中級ToolStripMenuItem.Text = "中級";
            this.中級ToolStripMenuItem.Click += new System.EventHandler(this.中級ToolStripMenuItem_Click);
            // 
            // 高級ToolStripMenuItem
            // 
            this.高級ToolStripMenuItem.Name = "高級ToolStripMenuItem";
            this.高級ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.高級ToolStripMenuItem.Text = "高級";
            this.高級ToolStripMenuItem.Click += new System.EventHandler(this.高級ToolStripMenuItem_Click);
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // tmrCounter
            // 
            this.tmrCounter.Interval = 1000;
            this.tmrCounter.Tick += new System.EventHandler(this.tmrCounter_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(98, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "時間";
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.BackColor = System.Drawing.SystemColors.Control;
            this.lblView.Location = new System.Drawing.Point(141, 6);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(11, 12);
            this.lblView.TabIndex = 2;
            this.lblView.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(170, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "地雷";
            // 
            // lbl_mines
            // 
            this.lbl_mines.AutoSize = true;
            this.lbl_mines.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_mines.Location = new System.Drawing.Point(208, 6);
            this.lbl_mines.Name = "lbl_mines";
            this.lbl_mines.Size = new System.Drawing.Size(11, 12);
            this.lbl_mines.TabIndex = 4;
            this.lbl_mines.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lbl_mines);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "踩地雷";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 遊戲ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 初級ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中級ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高級ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.Timer tmrCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_mines;
    }
}


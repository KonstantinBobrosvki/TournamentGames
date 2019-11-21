namespace Pong
{
    partial class PongGameField
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainGameLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.P1ScoreLabel = new System.Windows.Forms.Label();
            this.P2ScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MainGameLoopTimer
            // 
            this.MainGameLoopTimer.Enabled = true;
            this.MainGameLoopTimer.Interval = 25;
            this.MainGameLoopTimer.Tick += new System.EventHandler(this.MainGameLoopTimer_Tick);
            // 
            // P1ScoreLabel
            // 
            this.P1ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.P1ScoreLabel.Location = new System.Drawing.Point(129, 9);
            this.P1ScoreLabel.Name = "P1ScoreLabel";
            this.P1ScoreLabel.Size = new System.Drawing.Size(75, 53);
            this.P1ScoreLabel.TabIndex = 0;
            this.P1ScoreLabel.Text = "Player one Score: ";
            this.P1ScoreLabel.UseMnemonic = false;
            // 
            // P2ScoreLabel
            // 
            this.P2ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.P2ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.P2ScoreLabel.Location = new System.Drawing.Point(565, 9);
            this.P2ScoreLabel.Name = "P2ScoreLabel";
            this.P2ScoreLabel.Size = new System.Drawing.Size(75, 53);
            this.P2ScoreLabel.TabIndex = 1;
            this.P2ScoreLabel.Text = "Player one Score: ";
            this.P2ScoreLabel.UseMnemonic = false;
            // 
            // PongGameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.P2ScoreLabel);
            this.Controls.Add(this.P1ScoreLabel);
            this.Name = "PongGameField";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PongGameField_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PongGameField_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PongGameField_KeyDown);
            this.Resize += new System.EventHandler(this.PongGameField_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer MainGameLoopTimer;
        private System.Windows.Forms.Label P1ScoreLabel;
        private System.Windows.Forms.Label P2ScoreLabel;
    }
}


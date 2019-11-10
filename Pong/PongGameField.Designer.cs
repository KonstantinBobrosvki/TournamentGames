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
            this.SuspendLayout();
            // 
            // MainGameLoopTimer
            // 
            this.MainGameLoopTimer.Enabled = true;
            this.MainGameLoopTimer.Interval = 25;
            this.MainGameLoopTimer.Tick += new System.EventHandler(this.MainGameLoopTimer_Tick);
            // 
            // PongGameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "PongGameField";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PongGameField_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PongGameField_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PongGameField_KeyUp);
            this.Resize += new System.EventHandler(this.PongGameField_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer MainGameLoopTimer;
    }
}


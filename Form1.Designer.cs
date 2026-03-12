namespace CatchButton
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Target = new Button();
            SuspendLayout();
            // 
            // Target
            // 
            Target.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            Target.ForeColor = Color.Red;
            Target.Location = new Point(392, 160);
            Target.Name = "Target";
            Target.Size = new Size(152, 66);
            Target.TabIndex = 0;
            Target.Text = "나를 잡아봐";
            Target.UseVisualStyleBackColor = true;
            Target.Click += Target_Click;
            Target.MouseEnter += Target_MouseEnter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Target);
            Name = "Form1";
            Text = "Catch the button version 1.2";
            ResumeLayout(false);
        }

        #endregion

        private Button Target;
    }
}

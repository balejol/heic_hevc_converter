namespace hevc_to_mov
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
            btnOpener = new Button();
            btnConverter = new Button();
            SuspendLayout();
            // 
            // btnOpener
            // 
            btnOpener.BackgroundImageLayout = ImageLayout.Stretch;
            btnOpener.Location = new Point(72, 12);
            btnOpener.Name = "btnOpener";
            btnOpener.Size = new Size(119, 23);
            btnOpener.TabIndex = 8;
            btnOpener.Text = "Open .hevc file";
            btnOpener.UseVisualStyleBackColor = true;
            btnOpener.Click += btnOpener_Click;
            // 
            // btnConverter
            // 
            btnConverter.BackgroundImageLayout = ImageLayout.Stretch;
            btnConverter.Location = new Point(210, 12);
            btnConverter.Name = "btnConverter";
            btnConverter.Size = new Size(52, 23);
            btnConverter.TabIndex = 9;
            btnConverter.Text = "Save";
            btnConverter.UseVisualStyleBackColor = true;
            btnConverter.Click += btnConverter_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 160);
            Controls.Add(btnConverter);
            Controls.Add(btnOpener);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpener;
        private Button btnConverter;
    }
}
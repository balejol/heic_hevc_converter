namespace heic_to_jpeg
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            btnConverter = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnOpener = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(15, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(335, 451);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnConverter
            // 
            btnConverter.BackgroundImageLayout = ImageLayout.Stretch;
            btnConverter.Location = new Point(299, 12);
            btnConverter.Name = "btnConverter";
            btnConverter.Size = new Size(52, 23);
            btnConverter.TabIndex = 2;
            btnConverter.Text = "Save";
            btnConverter.UseVisualStyleBackColor = true;
            btnConverter.Click += btnConverter_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btnOpener
            // 
            btnOpener.BackgroundImageLayout = ImageLayout.Stretch;
            btnOpener.Location = new Point(12, 12);
            btnOpener.Name = "btnOpener";
            btnOpener.Size = new Size(119, 23);
            btnOpener.TabIndex = 7;
            btnOpener.Text = "Open .heic file";
            btnOpener.UseVisualStyleBackColor = true;
            btnOpener.Click += btnOpener_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 506);
            Controls.Add(btnOpener);
            Controls.Add(btnConverter);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Button btnConverter;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnOpener;
    }
}
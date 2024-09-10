using System;
using System.IO;
using System.Windows.Forms;
using ImageMagick;
using System.Drawing;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace heic_to_jpeg
{
    public partial class Form1 : Form
    {
        private MagickImage _magickImage;

        public Form1()
        {
            InitializeComponent();
            btnConverter.Visible = false;
        }

        private void btnOpener_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "HEIC Files|*.heic";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        pictureBox1.Image?.Dispose();

                        if (IsHeicFile(filePath))
                        {
                            _magickImage = new MagickImage(filePath);

                            // Resizes the image so it could be displayed in the pictureBox
                            using (MagickImage resizedImage = new MagickImage(_magickImage))
                            {
                                int displayWidth = pictureBox1.Width;
                                int displayHeight = pictureBox1.Height;

                                resizedImage.Resize(displayWidth, displayHeight);

                                using (MemoryStream ms = new MemoryStream()) // Stores data in the memory
                                {
                                    resizedImage.Write(ms, MagickFormat.Jpg);
                                    ms.Position = 0;
                                    pictureBox1.Image = Image.FromStream(ms);
                                }
                            }

                            btnConverter.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Selected file is not in .heic format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening file: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the selected file is a .heic file
        /// </summary>
        /// <param name="filePath"> Full name of the file with it's format </param>
        /// <returns> True if the file is .heic format </returns>
        private bool IsHeicFile(string filePath)
        {
            string result = Path.GetExtension(filePath).ToLower();
            return result == ".heic";
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;

                    savePath += ".jpg";
                    _magickImage.Write(savePath, MagickFormat.Jpg);
                    MessageBox.Show($"Image successfully saved to {savePath}");
                }
            }
        }
    }
}

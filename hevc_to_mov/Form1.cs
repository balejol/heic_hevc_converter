using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace hevc_to_mov
{
    public partial class Form1 : Form
    {
        private string selectedFilePath;

        public Form1()
        {
            InitializeComponent();
            btnConverter.Visible = false;
        }

        /// <summary>
        /// Button for opening wanted file
        /// </summary>
        private void btnOpener_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;

                    try
                    {
                        MessageBox.Show("HEVC file successfully opened.");
                        btnConverter.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening file: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Button that converts the wanted hevc file into mov format
        /// </summary>
        private void btnConverter_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "MOV Files (*.mov)|*.mov"; // Filters out only mov files in the folder

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;

                    // Ensures that the saved file has the correct format
                    if (!savePath.EndsWith(".mov", StringComparison.OrdinalIgnoreCase))
                    {
                        savePath += ".mov";
                    }

                    // Chosen file convertion from hevc to mov
                    try
                    {
                        ConvertToMov(selectedFilePath, savePath);
                        MessageBox.Show($"Video successfully saved to {savePath}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error converting file: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// HEVC converter to MOV using FFmpeg
        /// </summary>
        /// <param name="inputFilePath"> Chosen file that we want to convert </param>
        /// <param name="outputFilePath"> Place where we want to save the converted file </param>
        private void ConvertToMov(string inputFilePath, string outputFilePath)
        {
            string ffmpegPath = @"C:\ffmpeg\bin\ffmpeg.exe";
            // -i \"{inputFilePath}\": Specifies the input file
            // -c:v mpeg4: Specifies the video codec to use for the output file (mpeg4 used for mov format)
            // -c:a copy: Copies the audio stream from the input file
            // \"{outputFilePath}\": Specifies the output file path for the converted video
            string arguments = $"-i \"{inputFilePath}\" -c:v mpeg4 -c:a copy \"{outputFilePath}\"";

            // ProcessStartInfo starts the FFmpeg process
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = ffmpegPath, // Points to the FFmpeg executable
                Arguments = arguments, // Specifies the previously writen command-line arguments
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Starts the process of the ProcessStartInfo
            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"FFmpeg error: {error}\nOutput: {output}");
                }
            }
        }
    }
}

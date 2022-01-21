using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CopyContentsMenu
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // Check arguments for context menu start
            if (args.Length > 0)
            {
                // Copy image to clipboard
                try
                {
                    // Copy image to clipboard
                    Clipboard.SetImage(Image.FromFile(args[0]));
                }
                catch (Exception ex)
                {
                    // Advise user
                    MessageBox.Show($"Contents copy error:{Environment.NewLine}{ex.Message}", "Copy contents menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // By user
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }

    }
}

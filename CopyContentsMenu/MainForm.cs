// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace CopyContentsMenu
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using PublicDomain;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Gets or sets the associated icon.
        /// </summary>
        /// <value>The associated icon.</value>
        private Icon associatedIcon = null;

        /// <summary>
        /// The copy contents menu key listenfolder.
        /// </summary>
        private List<string> copyContentsMenuKeyList = new List<string> { @"Software\Classes\*\shell\Copy contents", @"Software\Classes\directory\shell\Copy contents" };

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CopyContentsMenu.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            /* Set icons */

            // Set associated icon from exe file
            this.associatedIcon = Icon.ExtractAssociatedIcon(typeof(MainForm).GetTypeInfo().Assembly.Location);

            // Set public domain weekly tool strip menu item contents
            this.freeReleasesPublicDomainisToolStripMenuItem.Image = this.associatedIcon.ToBitmap();

            // Update GUI
            this.UpdateByRegistryKey();
        }

        private void OnAddButtonClick(object sender, EventArgs e)
        {

        }

        private void OnRemoveButtonClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the program by registry key.
        /// </summary>
        private void UpdateByRegistryKey()
        {
            // Try to set copyContentsMenu key
            using (var copyContentsMenuKey = Registry.CurrentUser.OpenSubKey(this.copyContentsMenuKeyList[1]))
            {
                // Check for no returned registry key
                if (copyContentsMenuKey == null)
                {
                    // Disable remove button
                    this.removeButton.Enabled = false;

                    // Enable add button
                    this.addButton.Enabled = true;

                    // Update status text
                    this.activityToolStripStatusLabel.Text = "Inactive";
                }
                else
                {
                    // Disable add button
                    this.addButton.Enabled = false;

                    // Enable remove button
                    this.removeButton.Enabled = true;

                    // Update status text
                    this.activityToolStripStatusLabel.Text = "Active";
                }
            }
        }

        /// <summary>
        /// Handles the more releases public domain giftcom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFreeReleasesPublicDomainisToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open our website
            Process.Start("https://publicdomain.is");
        }

        /// <summary>
        /// Handles the original thread donation codercom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open original thread
            Process.Start("https://www.donationcoder.com/forum/index.php?topic=52087.0");
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open GitHub
            Process.Start("https://github.com/publicdomain/copy-contents-menu");
        }

        /// <summary>
        /// Handles the about tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the exit tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Close application
            this.Close();
        }
    }
}

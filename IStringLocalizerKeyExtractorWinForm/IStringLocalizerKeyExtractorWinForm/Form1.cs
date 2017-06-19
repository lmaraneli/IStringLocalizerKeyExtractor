using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IStringLocalizerKeyExtractorWinForm
{
    public partial class Form1 : Form
    {
        static string ResourcePathConstant = @"\resources";

        public Form1()
        {
            InitializeComponent();

            ResourcePath.Enabled = false;
            SaveLocation.Enabled = false;
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                MainPath.Text = FolderBrowser.SelectedPath;
                ResourcePath.Text = FolderBrowser.SelectedPath + ResourcePathConstant;
                ResourcePath.Enabled = true;
                SaveLocation.Enabled = true;
                SaveLocation.Text = FolderBrowser.SelectedPath + ResourcePathConstant;
            }
        }

        private void ResoucePath_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                ResourcePath.Text = FolderBrowser.SelectedPath;
                SaveLocation.Text = FolderBrowser.SelectedPath;
            }

            ResoucePath.Enabled = !string.IsNullOrEmpty(ResourcePath.Text);
            SaveLocation.Enabled = !string.IsNullOrEmpty(ResourcePath.Text);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Variables.Text)) return;

            var v = Variables.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var main = new Main(MainPath.Text, ResourcePath.Text, SaveLocation.Text, v);
            var value = main.ProcessFiles();

            Status.Text = "exited with code: " + value;
        }
    }
}

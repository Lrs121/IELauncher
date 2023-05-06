using IELauncher.Properties;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace IELauncher
{
    public partial class Gui : Form
    {
        public Gui()
        {
            InitializeComponent();
        }

        public string CurrentVersion
        {
            get
            {
                string? productVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
                if (productVersion != null)
                    return productVersion;
                else return string.Empty;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            saveSettings();
            cancelButton.Text = "Close";
            ((Button)sender).Enabled = false;
        }

        private void saveSettings()
        {
            if (string.IsNullOrWhiteSpace(startUpUrlTextBox.Text))
            {
                startUpUrlTextBox.Text = "about:blank";
            }

            Settings.Default.StartupURL = startUpUrlTextBox.Text;
            Settings.Default.Save();
            return;
        }

        private void Gui_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.None)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            saveSettings();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Gui_Load(object sender, EventArgs e)
        {
            startUpUrlTextBox.Text = Settings.Default.StartupURL;
            applyButton.Enabled = false;
        }

        private void startUpUrlTextBox_TextChanged(object sender, EventArgs e)
        {
            cancelButton.Text = "Cancel";
            applyButton.Enabled = true;
        }

        private void aboutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            aboutLink.LinkVisited = true;
            ProcessStartInfo startInfo = new();
            startInfo.FileName = "https://github.com/ciao1092/IELauncher/";
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }
    }
}

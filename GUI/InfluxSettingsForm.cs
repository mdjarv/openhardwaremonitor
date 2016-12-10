using System;
using System.Windows.Forms;

namespace OpenHardwareMonitor.GUI
{
    public partial class InfluxSettingsForm : Form
    {
        private MainForm parent;

        public InfluxSettingsForm(MainForm m)
        {
            InitializeComponent();
            parent = m;

        }

        private void InfluxSettingsForm_Load(object sender, EventArgs e)
        {
            hostTextBox.Text = parent.InfluxDB.Host;
            portNumericUpDn.Value = parent.InfluxDB.Port;

            // portNumericUpDn_ValueChanged(null, null);
            // hostTextBox_TextChanged(null, null);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            parent.InfluxDB.Host = hostTextBox.Text;
            parent.InfluxDB.Port = (int)portNumericUpDn.Value;
            this.Close();
        }

        private void portNumericUpDn_ValueChanged(object sender, EventArgs e)
        {
            parent.InfluxDB.Port = (int) portNumericUpDn.Value;
        }

        private void hostTextBox_TextChanged(object sender, EventArgs e)
        {
            parent.InfluxDB.Host = hostTextBox.Text;
        }
    }
}

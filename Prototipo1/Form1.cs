using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void radioButtonGenSettingY_CheckedChanged(object sender, EventArgs e){
            this.panelParamSelectInstance.Visible = !this.radioButtonGenSettingY.Checked;
            this.buttonOptimizeAll.Enabled = this.radioButtonGenSettingY.Checked;
        }

        private void advancedOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new FormAdvancedOptions();
            dialog.ShowDialog();
        }

        private void instanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var instanceLoader = new InstanceLoader();
            instanceLoader.ShowDialog();
            
        }
    }
}

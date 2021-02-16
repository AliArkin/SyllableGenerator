using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyllableGenerator;



namespace SyllableGeneratorDemoApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(SyllableType)))
            {
                cbSyllableType.Items.Add(item);
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cbSyllableType.SelectedIndex<0)
            {
                MessageBox.Show("select syllable type!");
                return;
            }
            txtResult.Text = string.Empty;
            Generator gen = new Generator();
            var result = gen.Generate((SyllableType)cbSyllableType.SelectedItem);
            txtResult.Text = string.Join(Environment.NewLine, result.ToArray<string>());
        }
    }
}

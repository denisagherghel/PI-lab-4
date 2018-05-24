using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form2 : Form
    {
        Form1 form;
        public Form2(Form1 form, int maxI, int maxJ)
        {
            this.form = form;
            InitializeComponent();

            iNumericUD.Minimum = 0;
            iNumericUD.Maximum = maxI;
            jNumericUD.Minimum = 0;
            jNumericUD.Maximum = maxJ;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

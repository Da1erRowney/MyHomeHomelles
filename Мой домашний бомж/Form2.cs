using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мой_домашний_бомж
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            List<Form> openForms = Application.OpenForms.OfType<Form>().ToList();
            foreach (Form form in openForms)
            {
                if (form != this)
                {
                    form.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}

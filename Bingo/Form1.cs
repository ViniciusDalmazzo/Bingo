using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bingo c = new Bingo();

            Disponivel(false);

            c.VariaBingo();
        }

        private void Disponivel(bool cond)
        {
            foreach (Control gb in this.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control b in gb.Controls)
                    {
                        if (b is Button && b.Text != "FREE")
                        {
                            b.Enabled = cond;
                        }
                    }
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Bingo c = new Bingo();
            c.VariaBingo();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            button13.Enabled = false;
            button26.Enabled = false;
            Disponivel(true);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

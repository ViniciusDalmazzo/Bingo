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
    public partial class Opcoes : Form
    {
        Principal pri;

        public Opcoes(Principal pr)
        {
            InitializeComponent();
            pri = pr;
        }

        //Salva alterações feitas
        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (pri.opcaoContinua() == DialogResult.Yes)
            {
                pri.continua();
                CorCartela();
                NomeJogador();
                numCartelas();
                this.Close();
            }
        }

        //Define a cor da tabpage através do scrollbar
        private void CorCartela()
        {
            if (cbx_cartela1.Checked)
                pri.tp_cartela1.BackColor = Color.FromArgb(hsb_red.Value, hsb_green.Value, hsb_blue.Value);
            if (cbx_cartela2.Checked)
                pri.tp_cartela2.BackColor = Color.FromArgb(hsb_red.Value, hsb_green.Value, hsb_blue.Value);
            if (cbx_cartela3.Checked)
                pri.tp_cartela3.BackColor = Color.FromArgb(hsb_red.Value, hsb_green.Value, hsb_blue.Value);
            if (cbx_cartela4.Checked)
                pri.tp_cartela4.BackColor = Color.FromArgb(hsb_red.Value, hsb_green.Value, hsb_blue.Value);
        }

        //Altera Nome do Jogador
        private void NomeJogador()
        {
            if (txt_nome.Text != "")
            {
               // pri.lbl_Nome.Text = txt_nome.Text;
                //pri.lbl_Nome.TextAlign = ContentAlignment.MiddleCenter;
            }
                
        }

        //Altera o número de cartelas
        private void numCartelas()
        {
            //Verifica se o radiobutton esta marcado
            if (rb_um.Checked)
            {
                //Verifica se a tabpage já esta criado
                if (!pri.tabControl1.Contains(pri.tp_cartela1))
                    pri.tabControl1.TabPages.Add(pri.tp_cartela1);
                pri.tabControl1.TabPages.Remove(pri.tp_cartela2);
                pri.tabControl1.TabPages.Remove(pri.tp_cartela3);
                pri.tabControl1.TabPages.Remove(pri.tp_cartela4);
            }
            else if (rb_dois.Checked)
            {
                if (!pri.tabControl1.Contains(pri.tp_cartela1))
                    pri.tabControl1.TabPages.Add(pri.tp_cartela1);
                if (!pri.tabControl1.Contains(pri.tp_cartela2))
                    pri.tabControl1.TabPages.Add(pri.tp_cartela2);
                pri.tabControl1.TabPages.Remove(pri.tp_cartela3);
                pri.tabControl1.TabPages.Remove(pri.tp_cartela4);
            }
            else if (rb_tres.Checked)
            {
                if (!pri.tabControl1.Contains(pri.tp_cartela1))
                    pri.tabControl1.TabPages.Add(pri.tp_cartela1);
                if (!pri.tabControl1.Contains(pri.tp_cartela2))
                    pri.tabControl1.TabPages.Add(pri.tp_cartela2);
                if (!pri.tabControl1.Contains(pri.tp_cartela3))
                    pri.tabControl1.TabPages.Add(pri.tp_cartela3);
                pri.tabControl1.TabPages.Remove(pri.tp_cartela4);
            }
            else if (rb_quatro.Checked)
            {
                if (!pri.tabControl1.Contains(pri.tp_cartela1))
                    pri.tabControl1.TabPages.Add(pri.tp_cartela1);
                if (!pri.tabControl1.Contains(pri.tp_cartela2))
                    pri.tabControl1.TabPages.Add(pri.tp_cartela2);
                if (!pri.tabControl1.Contains(pri.tp_cartela3))
                    pri.tabControl1.TabPages.Add(pri.tp_cartela3);
                if (!pri.tabControl1.Contains(pri.tp_cartela4))
                    pri.tabControl1.TabPages.Add(pri.tp_cartela4);
            }
        }

        //Cor Vermelha
        private void hsb_red_Scroll(object sender, ScrollEventArgs e)
        {
            pb_corCartela.BackColor = Color.FromArgb(hsb_red.Value, hsb_green.Value, hsb_blue.Value);
        }

        //Cor Verde
        private void hsb_green_Scroll(object sender, ScrollEventArgs e)
        {
            pb_corCartela.BackColor = Color.FromArgb(hsb_red.Value, hsb_green.Value, hsb_blue.Value);
        }

        //Cor Azul
        private void hsb_blue_Scroll(object sender, ScrollEventArgs e)
        {
            pb_corCartela.BackColor = Color.FromArgb(hsb_red.Value, hsb_green.Value, hsb_blue.Value);
        }

        //Fecha a Form sem fazer alteracoes
        private void btn_cancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

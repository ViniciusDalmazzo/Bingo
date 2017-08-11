using System;
using System.Collections;
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
    public partial class Principal : Form
    {
        Bingo c = new Bingo();
        Lista sort = new Lista();
        Node p;
        Lista nums = new Lista();
        int l1 = 0, l2 = 0, l3 = 0, l4 = 0, l5 = 0, c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, v1 = 0, v2 = 0, bingo = 0,score=0;

        public Principal()
        {

            InitializeComponent();


        }

        //Carrega todas as cartelas e deixa como padão só a primeira
        private void Form1_Load(object sender, EventArgs e)
        {
            MontaBingo(groupBox1);
            MontaBingo(groupBox2);
            MontaBingo(groupBox3);
            MontaBingo(groupBox4);
            tabControl1.TabPages.Remove(tp_cartela2);
            tabControl1.TabPages.Remove(tp_cartela3);
            tabControl1.TabPages.Remove(tp_cartela4);
            botaosorteio.Enabled = false;
          
        }

        //Troca todos os números da cartela do bingo
        private void TrocarBingo(GroupBox gb)
        {
            c.ZeraLista();
            c.InsereBingo();
            nums = c.NumSortiados(75);
            completaBingo(nums, gb);
        }

        //Monta a cartela do bingo inserindo seus números
        private void MontaBingo(GroupBox gb)
        {
            Disponivel(false, gb);
            c.InsereBingo();
            nums = c.NumSortiados(75);
            completaBingo(nums, gb);
        }

        //Faz uma nova cartela para o jogo
        public void continua()
        {

            TrocarBingo(groupBox1);
            TrocarBingo(groupBox2);
            TrocarBingo(groupBox3);
            TrocarBingo(groupBox4);
            Disponivel(false, groupBox1);
            Disponivel(false, groupBox2);
            Disponivel(false, groupBox3);
            Disponivel(false, groupBox4);
            btn_trocaCartela.Enabled = true;
        }

        //Varia dentro do groupbox para habilitar ou desabilitar os botões
        private void Disponivel(bool cond, GroupBox gb)
        {
            Button[] btns = new Button[25];

            foreach (Button b in gb.Controls)
            {
                if (b.Text != "FREE")
                    b.Enabled = cond;
                else
                    b.Enabled = !cond;
            }
        }

        //Com o hashtable joga seus valores nos botões
        private void completaBingo(Lista nums, GroupBox gb)
        {
            Node p = nums.FirstNode;
            Button[] btns = new Button[25];
            int i = 0;

            foreach (Button b in gb.Controls)
            {
                if (b.Text != "FREE")
                {
                    btns[i] = b;
                    i++;
                }
            }

            for (i = 0; i < 24; i++)
            {
                btns[i].Text = p.Info.ToString();
                p = p.Next;
            }

        }

        //Troca todos os valores das cartelas
        private void trocarCartela(object sender, EventArgs e)
        {
            TrocarBingo(groupBox1);
            TrocarBingo(groupBox2);
            TrocarBingo(groupBox3);
            TrocarBingo(groupBox4);
        }

        //Habilita as configurações para começar a partida
        private void jogar(object sender, EventArgs e)
        {
            botaosorteio.Enabled = true;
            btn_jogar.Enabled = false;
            bfree1.Enabled = false;
            btn_trocaCartela.Enabled = false;
            Disponivel(true, groupBox1);
            Disponivel(true, groupBox2);
            Disponivel(true, groupBox3);
            Disponivel(true, groupBox4);


        }

        //Sai do jogo
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        //Cria um novo jogo
        private void novoJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (opcaoContinua() == DialogResult.Yes)
            {
                continua();
                Principal NewForm = new Principal();
                NewForm.Show();
                this.Dispose(false);
            }
        }

        //Opções do jogo
        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcoes op = new Opcoes(this);

            op.ShowDialog();
        }

        //Confirmação de ações
        public DialogResult opcaoContinua()
        {
            DialogResult dr;
            dr = MessageBox.Show("Seu jogo atual será perdido\nDeseja continuar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr;
        }

        private void botaosorteio_Click(object sender, EventArgs e)
        {
            if(sort.FirstNode==null)
            {
                Bingo b2 = new Bingo();
                b2.InsereBingo();
                sort = b2.NumSortiados(100);
                p = sort.FirstNode;
            }
                       
                Sorteio();
                botaosorteio.Enabled = false;
                                      
        }

        private void Sorteio()
        {          
            timer1.Tick += new System.EventHandler(Exibir);       
        }

        private void Exibir(object sender, EventArgs e)
        {
            if (p == sort.LastNode)
            {
                timer1.Stop();
            }
            textBox1.Text = p.Info.ToString();
            listView1.Items.Add(p.Info.ToString());
            p = p.Next;


        }

        private int ClickBotao(Button b)
        {
            int c = 0;
            Boolean aux = false;

            aux = VerificaCartela(b);

            if (aux == true)
            {
                c++;
                return c;
            }

            return 0;

        }

        private Boolean VerificaCartela(Button b)
        {
            for (int i = 0; i < 100; i++)
            {
                if (p.Info.ToString() == b.Text)
                {
                    b.BackColor = Color.Red;
                    return true;
                }
                p = p.Next;
            }

            return false;
        }

        #region botões

        private void b1_Click(object sender, EventArgs e)
        {
            if (b1.BackColor != Color.Red)
            {
                int c = ClickBotao(b1);

                if (c > 0)
                {
                    bingo++;
                    c1++;
                    l1++;
                    v1++;
                    VerificaPontos();
                }

            }

        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (b2.BackColor != Color.Red)
            {
                int c = ClickBotao(b2);

                if (c > 0)
                {
                    bingo++;
                    c2++;
                    l1++;
                    VerificaPontos();
                }

            }

        }
        private void b3_Click(object sender, EventArgs e)
        {
            if (b3.BackColor != Color.Red)
            {
                int c = ClickBotao(b3);

                if (c > 0)
                {
                    bingo++;
                    c3++;
                    l1++;
                    VerificaPontos();
                }

            }

        }
        private void b4_Click(object sender, EventArgs e)
        {
            if (b4.BackColor != Color.Red)
            {
                int c = ClickBotao(b4);

                if (c > 0)
                {
                    bingo++;
                    c4++;
                    l1++;
                    VerificaPontos();
                }

            }

        }
        private void b5_Click(object sender, EventArgs e)
        {
            if (b5.BackColor != Color.Red)
            {
                int c = ClickBotao(b5);

                if (c > 0)
                {
                    bingo++;
                    c5++;
                    l1++;
                    v2++;
                    VerificaPontos();
                }

            }

        }
        private void b6_Click(object sender, EventArgs e)
        {
            if (b6.BackColor != Color.Red)
            {
                int c = ClickBotao(b6);

                if (c > 0)
                {
                    bingo++;
                    c1++;
                    l2++;
                    VerificaPontos();
                }

            }

        }
        private void b7_Click(object sender, EventArgs e)
        {
            if (b7.BackColor != Color.Red)
            {
                int c = ClickBotao(b7);

                if (c > 0)
                {
                    bingo++;
                    c2++;
                    l2++;
                    v1++;
                    VerificaPontos();
                }

            }

        }
        private void b8_Click(object sender, EventArgs e)
        {
            if (b8.BackColor != Color.Red)
            {
                int c = ClickBotao(b8);

                if (c > 0)
                {
                    bingo++;
                    c3++;
                    l2++;
                    VerificaPontos();
                }

            }

        }
        private void b9_Click(object sender, EventArgs e)
        {
            if (b9.BackColor != Color.Red)
            {
                int c = ClickBotao(b9);

                if (c > 0)
                {
                    bingo++;
                    c4++;
                    l2++;
                    v2++;
                    VerificaPontos();
                }

            }

        }
        private void b10_Click(object sender, EventArgs e)
        {
            if (b10.BackColor != Color.Red)
            {
                int c = ClickBotao(b10);

                if (c > 0)
                {
                    bingo++;
                    c5++;
                    l2++;
                    VerificaPontos();
                }

            }
        }
        private void b11_Click(object sender, EventArgs e)
        {
            if (b11.BackColor != Color.Red)
            {
                int c = ClickBotao(b11);

                if (c > 0)
                {
                    bingo++;
                    c1++;
                    l3++;
                    VerificaPontos();
                }

            }

        }
        private void b12_Click(object sender, EventArgs e)
        {
            if (b12.BackColor != Color.Red)
            {
                int c = ClickBotao(b12);

                if (c > 0)
                {
                    bingo++;
                    c2++;
                    l3++;
                    VerificaPontos();
                }

            }

        }

     
        private void b13_Click(object sender, EventArgs e)
        {

            if (b13.BackColor != Color.Red)
            {
                int c = ClickBotao(b13);

                if (c > 0)
                {
                    bingo++;
                    c4++;
                    l3++;
                    VerificaPontos();
                }

            }

        }
        private void b14_Click(object sender, EventArgs e)
        {
            if (b14.BackColor != Color.Red)
            {
                int c = ClickBotao(b14);

                if (c > 0)
                {
                    bingo++;
                    c5++;
                    l3++;
                    VerificaPontos();
                }

            }

        }
        private void b15_Click(object sender, EventArgs e)
        {
            if (b15.BackColor != Color.Red)
            {
                int c = ClickBotao(b15);

                if (c > 0)
                {
                    bingo++;
                    c1++;
                    l4++;
                    VerificaPontos();
                }

            }

        }
        private void b16_Click(object sender, EventArgs e)
        {
            if (b16.BackColor != Color.Red)
            {
                int c = ClickBotao(b16);

                if (c > 0)
                {
                    bingo++;
                    c2++;
                    l4++;
                    v2++;
                    VerificaPontos();
                }

            }

        }
        private void b17_Click(object sender, EventArgs e)
        {
            if (b17.BackColor != Color.Red)
            {
                int c = ClickBotao(b17);

                if (c > 0)
                {
                    bingo++;
                    c3++;
                    l4++;
                    VerificaPontos();
                }

            }

        }
        private void b18_Click(object sender, EventArgs e)
        {
            if (b18.BackColor != Color.Red)
            {
                int c = ClickBotao(b18);

                if (c > 0)
                {
                    bingo++;
                    c4++;
                    l4++;
                    v1++;
                    VerificaPontos();
                }

            }

        }
        private void b19_Click(object sender, EventArgs e)
        {
            if (b19.BackColor != Color.Red)
            {
                int c = ClickBotao(b19);

                if (c > 0)
                {
                    bingo++;
                    c5++;
                    l4++;
                    VerificaPontos();
                }

            }

        }
        private void b20_Click(object sender, EventArgs e)
        {

            if (b20.BackColor != Color.Red)
            {
                int c = ClickBotao(b20);

                if (c > 0)
                {
                    bingo++;
                    c1++;
                    l5++;
                    v2++;
                    VerificaPontos();
                }

            }

        }
        private void b21_Click(object sender, EventArgs e)
        {

            if (b21.BackColor != Color.Red)
            {
                int c = ClickBotao(b21);

                if (c > 0)
                {
                    bingo++;
                    c2++;
                    l5++;
                    VerificaPontos();
                }

            }
        }
        private void b22_Click(object sender, EventArgs e)
        {
            if (b22.BackColor != Color.Red)
            {
                int c = ClickBotao(b22);

                if (c > 0)
                {
                    bingo++;
                    c3++;
                    l5++;
                    VerificaPontos();
                }

            }

        }
        private void b23_Click(object sender, EventArgs e)
        {

            if (b23.BackColor != Color.Red)
            {
                int c = ClickBotao(b23);

                if (c > 0)
                {
                    bingo++;
                    c4++;
                    l5++;
                    VerificaPontos();
                }

            }


        }
private void b24_Click(object sender, EventArgs e)
{
    if (b24.BackColor != Color.Red)
    {
        int c = ClickBotao(b24);

        if (c > 0)
        {
            bingo++;
            c5++;
            l5++;
            v1++;
            VerificaPontos();
        }

    }
}
        #endregion

        #region verifica ponto do jogo

        private void VerificaPontos()
        {
             if (bingo == 24)
            {
                score += 500;
                MessageBox.Show("Parabéns! Você Ganhou", "Aviso");
                bingo = 0;
            }
            if (c1 == 5)
            {
                score += 100;
                MessageBox.Show("Você fez uma quina na coluna 1", "Aviso");
                c1 = 0;
            }
            if (c2 == 5)
            {
                score += 100;
                MessageBox.Show("Você fez uma quina na coluna 2", "Aviso");
                c2 = 0;
            }
            if (c3 == 4)
            {
                score += 100;
                MessageBox.Show("Você fez uma quina na coluna 3", "Aviso");
                c3 = 0;
            }
            if (c4 == 5)
            {
                score += 100;
                MessageBox.Show("Você fez uma quina na coluna 4", "Aviso");
                c4 = 0;
            }
            if (c5 == 5)
            {
                score += 100;
                MessageBox.Show("Você fez uma quina na coluna 5", "Aviso");
                c5 = 0;
            }
            if (l1 == 5)
            {
                score += 100;
                MessageBox.Show("Você fez uma sequencia na linha 1", "Aviso");
                l1 = 0;
            }
            if (l2 == 5)
            {
                score += 100;
                MessageBox.Show("Você fez uma sequencia  na linha 2", "Aviso");
                l2 = 0;
            }
            if (l3 == 4)
            {
                score += 100;
                MessageBox.Show("Você fez uma sequencia  na linha 3", "Aviso");
                l3 = 0;
            }
            if (l4 == 5)
            {
                score += 100;
                MessageBox.Show("Você fez uma sequencia  na linha 4", "Aviso");
                l4 = 0;
            }
            if (l5 == 5)
            {
                score += 100;
                MessageBox.Show("Você fez uma sequencia  na linha 5", "Aviso");
                l5 = 0;
            }
            if (v1 == 4)
            {
                score += 250;
                MessageBox.Show("Você fez uma sequencia vertical 1 ", "Aviso");
                v1 = 0;
            }
            if (v2 == 4)
            {
                score += 250;
                MessageBox.Show("Você fez uma sequencia vertical 2", "Aviso");
                v2 = 0;
            }
            label_score.Text = score.ToString();
        }

        #endregion
}


}

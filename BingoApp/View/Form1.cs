using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BingoApp.BLL;

namespace BingoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InicializarEventosBotoes();
        }

        private void InicializarEventosBotoes()
        {
            // Associa o mesmo manipulador de evento aos botões btnSorteioXX existentes
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name.StartsWith("btnSorteio"))
                {
                    button.Click += BtnSorteio_Click;
                }
            }
        }

        private void BtnSorteio_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.ForeColor = Color.Red; // Muda apenas a cor do botão clicado
                string numeroBola = button.Name.Replace("btnSorteio", "").Replace("_Click", "");
                AtualizaPedrasSorteadas(BingoManager.AtualizaBolaSorteada(txtBolasSorteadas.Text, numeroBola));
                AtualizaBolaSorteadaAtual(numeroBola);
            }
        }

        public void AtualizaBolaSorteadaAtual(string numeroBola)
        {
            lblBolaSorteada.Text = BingoManager.PegaBolaSorteada(numeroBola);
        }

        public void AtualizaPedrasSorteadas(string labelParaAtualizar)
        {
            txtBolasSorteadas.Text = labelParaAtualizar;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button37_Click(object sender, EventArgs e)
        {
        }

        private void btnSorteio02_Click(object sender, EventArgs e)
        {
        }

        private void btnSorteio03_Click(object sender, EventArgs e)
        {
        }

        private void btnSorteio04_Click(object sender, EventArgs e)
        {
        }
        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void btnEncerarSorteio_Click(object sender, EventArgs e)
        {
            EncerrarSorteio();
        }

        private void EncerrarSorteio()
        {
            // Define a cor de todos os botões btnSorteioXX para preto
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name.StartsWith("btnSorteio"))
                {
                    button.ForeColor = Color.White;
                }
            }

            //Reseta o texto das bolas sorteadas
            txtBolasSorteadas.Text = "ORDEM DO SORTEIO";

            lblBolaSorteada.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lblTipoJogo.Text = "CARTELA CHEIA";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lblTipoJogo.Text = "LINHAS";
        }
    }
}
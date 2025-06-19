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
        private System.Windows.Forms.Timer timerProgresso; // Timer para ProgressBar
        private double tempoTotal = 10.0; // Tempo total em segundos
        private double tempoDecorrido = 0.0; // Tempo decorrido em segundos

        public Form1()
        {
            InitializeComponent();
            InicializarEventosBotoes();

            // Configura a ProgressBar
            pbTemporizadorNumerosAutomaticos.Minimum = 0;
            pbTemporizadorNumerosAutomaticos.Maximum = 100;
            pbTemporizadorNumerosAutomaticos.Value = 0;

            // Configura o Timer de progresso (atualiza a cada 100ms)
            timerProgresso = new System.Windows.Forms.Timer();
            timerProgresso.Interval = 100; // 100 milissegundos
            timerProgresso.Tick += TimerProgresso_Tick;
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

        private void btnEncerrarSorteio_Click(object sender, EventArgs e)
        {
            EncerrarSorteio();
        }

        private void EncerrarSorteio()
        {
            // Define a cor de todos os botões btnSorteioXX para branco
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name.StartsWith("btnSorteio"))
                {
                    button.ForeColor = Color.White;
                }
            }

            // Reseta o texto das bolas sorteadas
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

        private void btnSorteadorAutomatico_Click(object sender, EventArgs e)
        {
            // Inicializa o Timer de sorteio
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 30000; // 10 segundos em milissegundos
            timer1.Tick += SortearBolaAutomaticamente; // Associa o evento Tick ao método
            timer1.Start(); // Inicia o Timer

            // Reinicia a ProgressBar e inicia o Timer de progresso
            tempoDecorrido = 0.0;
            pbTemporizadorNumerosAutomaticos.Value = 0;
            timerProgresso.Start();
        }

        private void SortearBolaAutomaticamente(object sender, EventArgs e)
        {
            string numeroBola = BingoManager.SortearBolaAutomaticamente();
            AtualizaPedrasSorteadas(BingoManager.AtualizaBolaSorteada(txtBolasSorteadas.Text, numeroBola));
            AtualizaBolaSorteadaAtual(numeroBola);

            string nomeBotao = $"btnSorteio{numeroBola}";
            Control[] controles = this.Controls.Find(nomeBotao, true);
            if (controles.Length > 0 && controles[0] is Button botao)
            {
                botao.ForeColor = Color.Red; // Altera a cor da fonte para vermelho
            }

            // Reinicia a ProgressBar para o próximo sorteio
            tempoDecorrido = 0.0;
            pbTemporizadorNumerosAutomaticos.Value = 0;
        }

        private void TimerProgresso_Tick(object sender, EventArgs e)
        {
            // Incrementa o tempo decorrido (100ms = 0.1 segundos)
            tempoDecorrido += 0.1;

            // Calcula o progresso como uma porcentagem
            int progresso = (int)((tempoDecorrido / tempoTotal) * 100);

            // Atualiza a ProgressBar
            if (progresso <= 100)
            {
                pbTemporizadorNumerosAutomaticos.Value = progresso;
            }
            else
            {
                pbTemporizadorNumerosAutomaticos.Value = 100;
            }
        }

        private void btnPararSorteioAutomatico_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timerProgresso.Stop(); // Para o Timer de progresso
        }
    }
}
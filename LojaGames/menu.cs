﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using LojaGames.Properties;

namespace LojaGames
{
    public partial class menu : Form
    {
        byte[] imagem;
        byte[] icone;

        public menu()
        {
            InitializeComponent();
            pcbJogoCarousel1.Controls.Add(panelJogo1);
            pcbJogoCarousel2.Controls.Add(panelJogo2);
            pcbJogoCarousel3.Controls.Add(panelJogo3);
            pcbJogoCarousel4.Controls.Add(panelJogo4);
            pcbJogoCarousel5.Controls.Add(panelJogo5);
        }

        private void CycleButtons()
        {
            int currentButtonIndex = pgJogos.SelectedIndex;
            int nextButtonIndex = (currentButtonIndex + 1) % 5;
            pgJogos.SetPage(nextButtonIndex);
        }

        private void menu_Load(object sender, EventArgs e)
        {
            btnCasa.Image = Resources.Home_Page_Active;
        }

        private void btnCasa_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(0);
            btnCasa.Image = Resources.Home_Page_Active;
            btnDashboard.Image = Resources.Control_Panel1;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
            btnConfiguracao.Image = Resources.Wrench;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(1);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel_Active;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
            btnConfiguracao.Image = Resources.Wrench;
        }

        private void btnJogos_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(2);
            btnCasa.Image = Resources.Home_Page;
            btnJogos.Image = Resources.Game_Controller_Active;
            btnDashboard.Image = Resources.Control_Panel1;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
            btnConfiguracao.Image = Resources.Wrench;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(3);
            pgAdd.SetPage(0);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel1;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New_Active;
            btnDinheiro.Image = Resources.Cash;
            btnConfiguracao.Image = Resources.Wrench;
        }

        private void btnDinheiro_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(4);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel1;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash_Active;
            btnConfiguracao.Image = Resources.Wrench;
        }

        private void btnConfiguracao_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(5);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel1;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
            btnConfiguracao.Image = Resources.Wrench_Active;
        }

        private void EscolherImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                imagem = File.ReadAllBytes(caminhoArquivo);

                pcbImagemJogo.Image = Image.FromFile(caminhoArquivo);
            }
        }

        private void btnEnviarjogo_Click(object sender, EventArgs e)
        {
            string nome = txtNomeJogo.Text;
            string descricao = txtDescricao.Text;
            DadosJogo.EnviarDadosJogo(imagem, nome, descricao);
        }

        private void btnEnviarCarrousel_Click(object sender, EventArgs e)
        {
            string nome = txtNomeJogoCarousel.Text;
            string descricao = txtCarousel.Text;
            DadosJogo.EnviarDadosCarousel(icone, imagem, nome, descricao);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            btnJogo1.LeftIcon.Image = DadosJogo.PegarImagemPequena(1);
            pcbJogoCarousel1.Image = DadosJogo.PegarImagemCarrousel(1);
            btnJogo1.Refresh();
            btnJogo1.Text = DadosJogo.PegarTexto(1);
            btnJogo2.LeftIcon.Image = DadosJogo.PegarImagemPequena(2);
            pcbJogoCarousel2.Image = DadosJogo.PegarImagemCarrousel(2);
            btnJogo2.Refresh();
            btnJogo2.Text = DadosJogo.PegarTexto(2);
            btnJogo3.LeftIcon.Image = DadosJogo.PegarImagemPequena(3);
            pcbJogoCarousel3.Image = DadosJogo.PegarImagemCarrousel(3);
            btnJogo3.Refresh();
            btnJogo3.Text = DadosJogo.PegarTexto(3);
            btnJogo4.LeftIcon.Image = DadosJogo.PegarImagemPequena(4);
            pcbJogoCarousel4.Image = DadosJogo.PegarImagemCarrousel(4);
            btnJogo4.Refresh();
            btnJogo4.Text = DadosJogo.PegarTexto(4);
            btnJogo5.LeftIcon.Image = DadosJogo.PegarImagemPequena(5);
            pcbJogoCarousel5.Image = DadosJogo.PegarImagemCarrousel(5);
            btnJogo5.Refresh();
            btnJogo5.Text = DadosJogo.PegarTexto(5);
            CycleButtons();
        }

        private void btnJogo1_Click(object sender, EventArgs e)
        {
            pgJogos.SetPage(0);
        }

        private void btnJogo2_Click(object sender, EventArgs e)
        {
            pgJogos.SetPage(1);
        }

        private void btnJogo3_Click(object sender, EventArgs e)
        {
            pgJogos.SetPage(2);
        }

        private void btnJogo4_Click(object sender, EventArgs e)
        {
            pgJogos.SetPage(3);
        }

        private void btnJogo5_Click(object sender, EventArgs e)
        {
            pgJogos.SetPage(4);
        }

        private void jogo1_Enter(object sender, EventArgs e)
        {
            jogo1.BackgroundImage = DadosJogo.PegarImagemCarrousel(1);
            jogo1.Refresh();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            pgAdd.SetPage(1);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            pgAdd.SetPage(2);
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            ListarJogos();
        }

        private void ListarJogos()
        {
            pbJogo1.Image = DadosJogo.PegarImagemGrande(1);
            pbJogo2.Image = DadosJogo.PegarImagemGrande(2);
            pbJogo3.Image = DadosJogo.PegarImagemGrande(3);
            pbJogo4.Image = DadosJogo.PegarImagemGrande(4);
            pbJogo5.Image = DadosJogo.PegarImagemGrande(5);
            pbJogo6.Image = DadosJogo.PegarImagemGrande(6);
            pbJogo7.Image = DadosJogo.PegarImagemGrande(7);
            pbJogo8.Image = DadosJogo.PegarImagemGrande(8);
            pbJogo9.Image = DadosJogo.PegarImagemGrande(9);
            pbJogo10.Image = DadosJogo.PegarImagemGrande(10);
            pbJogo11.Image = DadosJogo.PegarImagemGrande(11);
            pbJogo12.Image = DadosJogo.PegarImagemGrande(12);
        }

        private void btnIcone_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter =
                    "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = openFileDialog.FileName;
                    icone = File.ReadAllBytes(caminhoArquivo);

                    pcbIcone.Image = Image.FromFile(caminhoArquivo);
                }
            }
        }

        private void btnCarrousel_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter =
                    "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = openFileDialog.FileName;
                    imagem = File.ReadAllBytes(caminhoArquivo);

                    pcbCarousel.Image = Image.FromFile(caminhoArquivo);
                }
            }
        }

        private void btnSair_MouseEnter(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(152, 145, 202);
            btnSair.Image = Resources.Exit;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(147, 140, 197);
            btnSair.Image = Resources.ExitCinza;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
            new login().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CycleButtons();
        }

        private void pbJogo1_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(6);
        }
    }
}

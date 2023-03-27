﻿using BLL;
using Models;
using System;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormConsultaPermissao : Form
    {
        public int Id;
        public FormConsultaPermissao()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                permissaoBindingSource.DataSource = new PermissaoBLL().BuscarPorDescricao(textBoxBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (permissaoBindingSource.Count > 0)
                {
                    Id = ((Permissao)permissaoBindingSource.Current).Id;
                    Close();
                }
                else
                    MessageBox.Show("Não existe registro para ser selecionado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

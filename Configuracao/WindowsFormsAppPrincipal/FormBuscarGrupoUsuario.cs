using BLL;
using Models;
using System;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormBuscarGrupoUsuario : Form
    {
        public FormBuscarGrupoUsuario()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            grupoUsuarioBindingSource.DataSource = new GrupoUsuarioBLL().BuscarTodos();
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            int id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
            using (FormCadastroGrupoUsuario frm = new FormCadastroGrupoUsuario(id))
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }

        private void buttonAdicionarGrupoUsuario_Click(object sender, EventArgs e)
        {
            using (FormCadastroGrupoUsuario frm = new FormCadastroGrupoUsuario())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }
        private void buttonExcluirGrupoUsuario_Click(object sender, EventArgs e)
        {
            if (grupoUsuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Não existe registro para ser excluído");
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            int id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
            new UsuarioBLL().Excluir(id);
            grupoUsuarioBindingSource.RemoveCurrent();

            MessageBox.Show("Registro excluído com sucesso!");
        }
        private void buttonAdicionarPermissao_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormConsultaPermissao frm = new FormConsultaPermissao())
                {
                    frm.ShowDialog();
                    if (frm.Id != 0)
                    {
                        int idGrupoUsuario = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
                        new GrupoUsuarioBLL().AdicionarPermissao(idGrupoUsuario, frm.Id);
                    }
                }
                buttonBuscar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonExcluirPermissao_Click(object sender, EventArgs e)
        {
            try
            {
                int idPermissao = ((Permissao)permissoesBindingSource.Current).Id;
                int idGrupoUsuario = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
                new GrupoUsuarioBLL().RemoverPermissao(idPermissao, idGrupoUsuario);
                permissoesBindingSource.RemoveCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

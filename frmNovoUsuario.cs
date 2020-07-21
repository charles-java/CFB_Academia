using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFB_Academia
{
    public partial class frmNovoUsuario : Form
    {
        public frmNovoUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.u_nome = txtNome.Text;
            usuario.u_user = txtUsuario.Text;
            usuario.u_senha = txtSenha.Text;
            usuario.u_status = cboStatus.Text;
            usuario.u_nivel = Convert.ToInt32(Math.Round(numNivel.Value));

            Banco.novoUsu(usuario);

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
            cboStatus.Text = "";
            numNivel.Value = 0;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
            cboStatus.Text = "";
            numNivel.Value = 0;
            txtNome.Focus();
        }
    }
}

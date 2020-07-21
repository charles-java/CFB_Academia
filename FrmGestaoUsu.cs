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
    public partial class FrmGestaoUsu : Form
    {
        public FrmGestaoUsu()
        {
            InitializeComponent();
        }

        private void FrmGestaoUsu_Load(object sender, EventArgs e)
        {
            dtGrid.DataSource = Banco.ObterUsuariosIdNome();

            dtGrid.Columns[0].Width = 85;
            dtGrid.Columns[1].Width = 190;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtGrid_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int cont = dgv.SelectedRows.Count;
            if (cont > 0)
            {
                //como não é possivel multi selection selectedrows terá indice [0] sempre
                // cell  posição da coluna

                DataTable dt = new DataTable();
                string vId = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosUsuarios(vId);

                if (dt.Rows.Count > 0)
                {
                    txtNome.Text = dt.Rows[0].Field<string>("T_nomeUsuario").ToString();
                    txtId.Text = dt.Rows[0].Field<Int64>("N_idUsuario").ToString();
                    txtUsuario.Text = dt.Rows[0].Field<string>("T_userName").ToString();
                    txtSenha.Text = dt.Rows[0].Field<string>("T_senhaUsuario").ToString();
                    cboStatus.Text = dt.Rows[0].Field<string>("T_status").ToString();
                    numNivel.Value = dt.Rows[0].Field<Int64>("N_nivelUsuario");
                }
                else
                {
                    MessageBox.Show("Usuario não Encontrado!!:"+ vId);
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmNovoUsuario f_novo = new frmNovoUsuario();
            f_novo.ShowDialog();

            dtGrid.DataSource = Banco.ObterUsuariosIdNome(); 

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int linha = dtGrid.SelectedRows[0].Index;
            Usuario u = new Usuario();
            u.u_id = Convert.ToInt32(txtId.Text);
            u.u_nome = txtNome.Text;
            u.u_user = txtUsuario.Text;
            u.u_status = cboStatus.Text;
            u.u_nivel= Convert.ToInt32(Math.Round(numNivel.Value,0));


            Banco.AtualizarUsuario1(u);

            //dtGrid.DataSource = Banco.ObterUsuariosIdNome();
            //dtGrid.CurrentCell = dtGrid[0, linha];
            dtGrid[1, linha].Value = txtNome.Text;

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja Realmente Excluir ? (S/N)", "Excluir ?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Banco.DeletarUsuario(txtId.Text);
                dtGrid.Rows.Remove(dtGrid.CurrentRow);
            }
        }
    }
}

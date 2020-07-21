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
    public partial class FrmLogin : Form
    {
        Form1 form1;
        DataTable dt = new DataTable();

        public FrmLogin(Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            string username = txtBUser.Text;
            string senha = txtBSenha.Text;

            if (username == "" || senha == "")

            {
                MessageBox.Show("Usuario e Senha Incorretos!");
                txtBUser.Focus();
            }

            string sql = "select * from tb_usuarios where T_userName ='" + username + "' and T_senhaUsuario='" + senha +"'";
            dt = Banco.dql(sql);

            if (dt.Rows.Count ==1)
            {
              
 
                //  item[5] referece ao campo ou coluna nivelUsuario
                form1.lblAcesso.Text = dt.Rows[0].ItemArray[5].ToString();              
                form1.lblNomeUsuario.Text = dt.Rows[0].Field<string>("T_nomeUsuario");
                form1.picBlogado.Image = Properties.Resources.led_verde;
                Globais.nivel = int.Parse(dt.Rows[0].Field<Int64>("N_nivelUsuario").ToString());
                Globais.logado = true;
                this.Close();

            }
            else
            {
                MessageBox.Show("Usuario Não encontrado!!");
                Globais.logado = false;
                this.Close();
            }

        }

 

  
    }
}

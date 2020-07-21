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
    public partial class Form1 : Form
    {
 
        public Form1()
        {
            InitializeComponent();
 
            FrmLogin f_login = new FrmLogin(this);
            f_login.ShowDialog();
        }

        private void abreform(int nivel, Form f)
        { 
            if (Globais.logado)
            {
                if (Globais.nivel >= 1)
                {                     
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso Não Permitido!");
                }
            }
            else
            {
                MessageBox.Show("É preciso Logar");
            }
 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void logONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin f_login = new FrmLogin(this);
            f_login.ShowDialog();
        }

        private void logoOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblAcesso.Text = "0";
            lblNomeUsuario.Text = ("---");
            picBlogado.Image = Properties.Resources.ledVermelho;
            Globais.nivel = 0;
            Globais.logado = false;
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // FrmGestaoUsu f_gestaoUsu = new FrmGestaoUsu();
          //  f_gestaoUsu.ShowDialog();
          //  abreform(2, f_gestaoUsu);
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestãoDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

     
            FrmGestaoUsu f_gestaoUsu = new FrmGestaoUsu();
            f_gestaoUsu.ShowDialog();
            abreform(1, f_gestaoUsu);
      
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {

          //  FrmGestaoUsu f_gestaoUsu = new FrmGestaoUsu();
          //  f_gestaoUsu.ShowDialog();
          //  abreform(1, f_gestaoUsu);

        }

        private void cadastroDeUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
            frmNovoUsuario f_novoUsu = new frmNovoUsuario();
            f_novoUsu.ShowDialog();

            abreform(1, f_novoUsu);

        }
        

        private void horáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHorarios f_horarios = new frmHorarios();
            f_horarios.ShowDialog();

            abreform(2, f_horarios);

 
        }
    }
}

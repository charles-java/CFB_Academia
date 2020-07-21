using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
using System.Data.SQLite;
using System.Windows.Forms;
using System.Security.Policy;
//using Microsoft.Data.Sqlite;

namespace CFB_Academia
{
    public class Banco
    {
        private static SQLiteConnection conexao;

        // funcoes genericas 
        public static DataTable dql(string sql)  // data query language  - select
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

        public static void dml(string q, string msgOK = null, string msgErro = null) 
            // data manipulation language   para insert, update e delete
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();

                if (msgOK != null)
                {
                    MessageBox.Show(msgOK);
                }

            }
            catch (Exception ex)
            {
                if (msgErro != null)
                {
                    MessageBox.Show(msgErro + "\n" + ex.Message);
                }
                throw ex;
            }
        }

        private static SQLiteConnection ConexaoBanco()
        {
            //conexao = new SQLiteConnection("Data Source="+Globais.caminho + "\\" + Globais.nomeBanco);
            conexao = new SQLiteConnection("Data Source=" + Globais.caminhoBanco);


            conexao.Open();
            return conexao;
        }

        public static DataTable ObterTodosUsuarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "Select * from tb_usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
 
                throw ex;
            } 
        }

        public static DataTable consulta1(string sql)  // data query language
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
                throw ex;
            }
        }

        ////////////   funcoes do formulario ////////////////////////
        public static void novoUsu(Usuario u)
        {
            if (existeUsu(u))
            {
                MessageBox.Show("UserName já Existe!");
                return;

            }
            else
            {   // insere no banco
                try
                {
                    var vcon = ConexaoBanco();
                    var cmd = vcon.CreateCommand();
                    cmd.CommandText = "Insert into tb_usuarios (T_nomeUsuario,T_userName,T_senhaUsuario,T_status,N_nivelUsuario) values (@nome,@user,@senha,@status,@nivel) ";
                    cmd.Parameters.AddWithValue("@nome", u.u_nome);
                    cmd.Parameters.AddWithValue("@user", u.u_user);
                    cmd.Parameters.AddWithValue("@senha", u.u_senha);
                    cmd.Parameters.AddWithValue("@status", u.u_status);
                    cmd.Parameters.AddWithValue("@nivel", u.u_nivel);
                    cmd.ExecuteNonQuery();
                    vcon.Close();
                    MessageBox.Show("Usuario Incluído com Sucesso!!");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Usuario NÃO Incluído!!" + ex);
                }
            }
        }
        //  fim das funções

        //// rotinas gerais
        public static bool existeUsu(Usuario u)
        {
            bool res;
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            var vcon = ConexaoBanco();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "Select T_userName from tb_usuarios where T_userName = '" + u.u_user + "'";
            da = new SQLiteDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            vcon.Close();
            return res; 
        }
        ///   funcoes do form Gestao de usuario
        ///   
        public static DataTable ObterUsuariosIdNome()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "Select N_idUsuario as ID_Usu, T_nomeUsuario as Nome_Usuario from tb_usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            
        }

        public static DataTable ObterDadosUsuarios(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "Select * from tb_usuarios where N_idUsuario = "+id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

        public static void AtualizarUsuario1(Usuario u)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "update tb_usuarios set T_nomeUsuario ='"+u.u_nome+"'" +
                    ",T_userName = '"+u.u_user+"',T_senhaUsuario = '"+u.u_senha+"'" +
                    ",T_status = '"+u.u_status+ "',N_nivelUsuario = "+u.u_nivel+" where N_idUsuario ="+u.u_id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close(); 
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }

        }

        public static void DeletarUsuario(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "delete from tb_usuarios where N_idUsuario =" + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }

        }
        ///   fim gestao
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFB_Academia
{
    class Globais
    {
        public static string versao = "1.0";
        public static bool logado = false;
        public static int nivel = 0;  // 0 -nivel basico,  1- Gerencia,   2- Master
        public static string caminho = System.Environment.CurrentDirectory;
        public static string nomeBanco = "banco_academia.db";
        public static string caminhoBanco = caminho  + @"\banco\" + nomeBanco;
        

        /*   atributos da tabela usuarios
          N_idUsuario
          T_nomeUsuario
          T_userName
          T_senhaUsuario
          T_status
          N_nivelUsuario
         */



    }
}

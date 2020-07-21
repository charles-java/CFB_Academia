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
    public partial class frmHorarios : Form
    {
        public frmHorarios()
        {
            InitializeComponent();
        }

        private void frmHorarios_Load(object sender, EventArgs e)
        {
            string vquery = @"
                select N_idHorario as 'ID',
                T_DescHorario as 'Horario'
                from
                tb_horarios";

            //dql - padrao de consulta implementado
            dtGridHorario.DataSource = Banco.dql(vquery);
            dtGridHorario.Columns[0].Width = 60;
            dtGridHorario.Columns[1].Width = 170;

        }

        private void dtGridHorario_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;
            int cont = dtGridHorario.SelectedRows.Count;

            if (cont > 0)
            {
                DataTable dt = new DataTable();

                string vid = dtGridHorario.SelectedRows[0].Cells[0].Value.ToString();

                string vquery = @"
                    select * from tb_horarios
                    where N_idHorario = " + vid;
                
                dt = Banco.dql(vquery);
                txtId.Text = dt.Rows[0].Field<Int64>("N_idHorario").ToString();
                mskHorario.Text = dt.Rows[0].Field<string>("T_DescHorario");



            } 


        }

        private void mskHorario_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {


        }
    }
}

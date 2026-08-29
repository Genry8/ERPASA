using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERPASA.Frm_TabMaestra
{

    public partial class frm_BuscarUsuario : Form
    {
        cn_usuario objcuserneg = new cn_usuario();
        cd_conexion objcdconex = new cd_conexion();
        cn_datosventa objdatventaneg = new cn_datosventa();
        DataTable dtg2;

        //private Size formSize; //Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.
        //Overridden methods

        public frm_BuscarUsuario()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;            
        }

        private void frm_BuscarUsuario_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            dtg2 = cn_rolesuser.ListaBuscarUsuarioAPP("%", "%");
            dataGridView2.DataSource = dtg2;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ClearSelection();

            //
        }

        private void Frm_agregar_Resize(object sender, EventArgs e)
        {
            //AdjustForm();
        }

        private void panel_titulo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.None;
            }
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textbox_factura_KeyUp(object sender, KeyEventArgs e)
        {
            //dataGridView2.Columns.Clear();
            //dataGridView2.DataSource = cn_datosventa.BuscarProducto(textbox_Perifericodesc.Text, ce_datosventa.Select_almacen);
            //dataGridView2.ClearSelection();
            //OrigenColorfila();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int minstk = int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());

            if (dataGridView2.CurrentRow.Cells[0].Value.ToString() == "EN USO")
            {
                Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("ACTIVO EN USO, VERIFICAR", Color.Red, 3);
                ng.ShowDialog();
                //break;
            }

            //else if (dataGridView2.CurrentRow.Cells[8].Value.ToString() == "0")
            //{
            //    Msbox.Frm_Notificaciones ng = new Msbox.Frm_Notificaciones("PRODUCTO SIN STOCK", Color.DarkRed, 3);
            //    ng.ShowDialog();
            //    //break;
            //}

            else
            {
                /////////
                VarDatosEntroFormUsuario var1 = Owner as VarDatosEntroFormUsuario;
                DataGridViewRow fila = dataGridView2.SelectedRows[0] as DataGridViewRow;
                var1.TablaAgregarDatosFilaAsig(fila);
                this.Close();

            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Modo")
            {
                if (Convert.ToString(e.Value) == "EN USO")
                {
                    e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    e.CellStyle.Font = new Font("Verdana", 11.0f);
                    e.CellStyle.ForeColor = Color.FromArgb(252, 70, 0);
                    //e.CellStyle.BackColor = Color.YellowGreen;
                }
                if (Convert.ToString(e.Value) == "LIBRE")
                {
                    e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    e.CellStyle.Font = new Font("Verdana", 10.0f);
                    e.CellStyle.ForeColor = Color.MediumSeaGreen;
                    //e.CellStyle.BackColor = Color.YellowGreen;
                }
            }

            //if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Stock")
            //{
            //    if (Convert.ToInt32(e.Value) <= 0)
            //    {
            //        e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
            //        e.CellStyle.Font = new Font("Verdana", 11.0f);
            //        e.CellStyle.ForeColor = Color.FromArgb(252, 70, 0);
            //        //e.CellStyle.BackColor = Color.YellowGreen;
            //    }

            //    else if (Convert.ToInt32(e.Value) <= 5)
            //    {
            //        e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
            //        e.CellStyle.Font = new Font("Verdana", 10.0f);
            //        e.CellStyle.ForeColor = Color.FromArgb(255, 128, 0);
            //        //e.CellStyle.BackColor = Color.YellowGreen;
            //    }

            //    else
            //    {
            //        e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
            //        e.CellStyle.Font = new Font("Verdana", 10.0f);
            //        e.CellStyle.ForeColor = Color.MediumSeaGreen;
            //        //e.CellStyle.BackColor = Color.YellowGreen;
            //    }

            //}
        }

        public void OrigenColorfila()
        {
            //int c = dataGridView2.Rows.Count;
            //for (int i = 0; i < c; i++)
            //{
            //    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "ANULADO")
            //    {
            //        dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.Red; //DarkRed FromArgb(252, 70, 0)
            //        dataGridView2.Rows[i].DefaultCellStyle.Font = new Font("Verdana", 9.0f);
            //        //dataGridView2.Rows[i].DefaultCellStyle.Font = new Color.FromArgb(192, 12, 0);
            //        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            //    }
            //}
        }



        private void guna2TextBoxSearch_TextChanged(object sender, EventArgs e)
        {

            string filtro = guna2TextBoxSearch.Text.Trim().Replace("'", "''");

            if (dtg2 != null)
            {
                DataView dv = dtg2.DefaultView;

                if (string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = ""; // Quitar el filtro si el textbox está vacío
                    OrigenColorfila();
                }
                else
                {
                    // Generar condiciones para todas las columnas tipo string
                    var condiciones = dtg2.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string)) // Opcional: solo columnas de texto
                        .Select(col => $"[{col.ColumnName}] LIKE '%{filtro}%'");

                    dv.RowFilter = string.Join(" OR ", condiciones);
                    OrigenColorfila();
                }
            }
        }
    }

}

using System.Windows.Forms;

namespace CapaUtilidad
{
    public class cu_excel
    {
        public void ExportarExcel(DataGridView tabla)
        {
            Microsoft.Office.Interop.Excel.Application exc = new Microsoft.Office.Interop.Excel.Application();
            exc.Application.Workbooks.Add(true);
            int indicecolumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns) // columna
            {
                indicecolumna++;
                exc.Cells[1, indicecolumna] = col.Name;
            }

            int Indicefila = 0;

            foreach (DataGridViewRow fil in tabla.Rows)
            {
                Indicefila++;
                indicecolumna = 0;

                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    indicecolumna++;
                    //object cellValue = fil.Cells[col.Name].Value;
                    //exc.Cells[Indicefila + 1, indicecolumna] = cellValue != null ? cellValue.ToString() : string.Empty;

                    exc.Cells[Indicefila + 1, indicecolumna] = fil.Cells[col.Name].Value;

                }
            }

            exc.Visible = true;
        }

        public void ExportarExcelInsp(DataGridView tabla)
        {
            Microsoft.Office.Interop.Excel.Application exc = new Microsoft.Office.Interop.Excel.Application();
            exc.Application.Workbooks.Add(true);
            int indicecolumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns) // columna
            {
                indicecolumna++;
                exc.Cells[1, indicecolumna] = col.Name;
            }

            int Indicefila = 0;

            foreach (DataGridViewRow fil in tabla.Rows)
            {
                Indicefila++;
                indicecolumna = 0;

                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    indicecolumna++;
                    object cellValue = fil.Cells[col.Name].Value;
                    exc.Cells[Indicefila + 1, indicecolumna] = cellValue != null ? cellValue.ToString() : string.Empty;

                    //exc.Cells[Indicefila + 1, indicecolumna] = fil.Cells[col.Name].Value;

                }
            }

            exc.Visible = true;
        }


    }
}

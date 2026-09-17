using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaUtilidad;
using ERPASA.Frm_Contabilidad;
using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace ERPASA.Frm_Comercial
{
    public partial class Frm_CargarLiquidacionCIT : Form
    {
        private DataSet dtsTablas = new DataSet();
        private DataSet dtsTablasLicencia = new DataSet();
        cn_planilla objcnlog = new cn_planilla();
        string TipoAlimento;

        cu_excel_progressForm objexcel_progress = new cu_excel_progressForm();
        DataTable dtg;
        private CancellationTokenSource _cts;

        public Frm_CargarLiquidacionCIT()
        {
            InitializeComponent();
            // Identidad visual del ERP (barra de título, acciones, campos y grilla).
            this.Load += delegate { Estilos.EstilizadorErp.Aplicar(this); };
        }

        private void Frm_CargarLiquidacionCIT_Load(object sender, EventArgs e)
        {
            //ALTO RIESGO
            //poner osucro

            comboBox_Hojas.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox_TipoProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox_TipoProveedor.SelectedIndex = 0;

            Cargar_Empresa();
            ColumnasDtgv1();

            dataGridView1.AllowUserToAddRows = false;

        }


        public void Cargar_Empresa()
        {
            //CARGAR NORMA
            guna2ComboBox_TipoProveedor.DataSource = cn_comercial.ListaProveedorLiq();
            guna2ComboBox_TipoProveedor.DisplayMember = "Proveedor"; //NOMBRE DE COLUMNA 
            guna2ComboBox_TipoProveedor.ValueMember = "id"; // NOMBRE DEL ID

        }

        private void ColumnasDtgv1()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Contenedor", "N° de Contenedor");
            dataGridView1.Columns.Add("TotalKg", "Total Kg.");
            dataGridView1.Columns.Add("Variedad", "Variedad");
            dataGridView1.Columns.Add("Var_desc", "Var_desc");
            dataGridView1.Columns.Add("Documento", "Documento de Venta");

            dataGridView1.Columns.Add("PctPeso", "% Peso");
            dataGridView1.Columns.Add("PctVenta", "% Venta");

            dataGridView1.Columns.Add("Cajas", "Cajas");
            dataGridView1.Columns.Add("Sales", "SALES USD $");
            dataGridView1.Columns.Add("PricePerBox", "PRICE PER BOX $");

            dataGridView1.Columns.Add("Pct", "%");

            dataGridView1.Columns.Add("Commission", "Commission");
            dataGridView1.Columns.Add("Chep", "Chep Pallet");
            dataGridView1.Columns.Add("Cold", "Cold Storage In/Out Fees");
            dataGridView1.Columns.Add("Customs", "Customs/Clearing");
            dataGridView1.Columns.Add("ImportTariff", "Import Tariff");
            dataGridView1.Columns.Add("Inland", "Inland Freight Charges");
            dataGridView1.Columns.Add("Inspections", "Inspections");
            dataGridView1.Columns.Add("Ocean", "OceanFreight - Imports");
            dataGridView1.Columns.Add("Operations", "Operations/Handling");
            dataGridView1.Columns.Add("Repacking", "Repacking");

            dataGridView1.Columns.Add("TotalExpenses", "Total Expenses $");
            dataGridView1.Columns.Add("CostPerBox", "Cost per box $");

            dataGridView1.Columns.Add("FOB", "FOB USD");
            dataGridView1.Columns.Add("FOB_KG", "FOB $ x KG");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void ColumnasDtgv_SP()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Contenedor", "N° de Contenedor");
            dataGridView1.Columns.Add("TotalKg", "Total Kg.");
            dataGridView1.Columns.Add("Variedad", "Variedad");
            dataGridView1.Columns.Add("VarDesc", "Var_desc");
            dataGridView1.Columns.Add("Documento", "Documento de Venta");

            dataGridView1.Columns.Add("PctPeso", "% Peso");
            dataGridView1.Columns.Add("PctVenta", "% Venta");

            dataGridView1.Columns.Add("Cajas", "Cajas");
            dataGridView1.Columns.Add("Sales", "SALES USD $");
            dataGridView1.Columns.Add("PricePerBox", "PRICE PER BOX $");

            dataGridView1.Columns.Add("CommissionPct", "%");

            dataGridView1.Columns.Add("Commission", "COMMISSION");
            dataGridView1.Columns.Add("CustomBroker", "CUSTOM BROKER");
            dataGridView1.Columns.Add("ExpeditorFees", "EXPEDITOR FEES");
            dataGridView1.Columns.Add("InlandFreight", "INLAND FREIGHT");
            dataGridView1.Columns.Add("PortFees", "PORT FEES");
            dataGridView1.Columns.Add("Inspection", "INSPECTION");
            dataGridView1.Columns.Add("ExamFee", "EXAM FEE");
            dataGridView1.Columns.Add("MaterialBoxes", "MATERIAL-BOXES");
            dataGridView1.Columns.Add("MaterialFilm", "MATERIAL-FILM");
            dataGridView1.Columns.Add("MaterialShipping", "MATERIAL-SHIPPING");
            dataGridView1.Columns.Add("MaterialPallets", "MATERIAL-PALLETS");
            dataGridView1.Columns.Add("OceanFreight", "OCEAN FREIGHT");
            dataGridView1.Columns.Add("PackingFees", "PACKING FEES");
            dataGridView1.Columns.Add("StorageFee", "STORAGE FEE");
            dataGridView1.Columns.Add("CutiesMarketingAccrual", "CUTIES MARKETING ACCRUAL");
            dataGridView1.Columns.Add("Tariff", "TARIFF");
            dataGridView1.Columns.Add("HarborMaintenanceFee", "HARBOR MAINTENANCE FEE");

            dataGridView1.Columns.Add("TotalExpenses", "Total Expenses $");

            dataGridView1.Columns.Add("FOB", "FOB USD");
            dataGridView1.Columns.Add("FOBxKg", "FOB $ x KG");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void ColumnasDtgv_LGS()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Contenedor", "N° de Contenedor");
            dataGridView1.Columns.Add("TotalKg", "Total Kg.");
            dataGridView1.Columns.Add("Variedad", "Variedad");
            dataGridView1.Columns.Add("Var_desc", "Var_Desc");
            dataGridView1.Columns.Add("Documento", "Documento");

            dataGridView1.Columns.Add("PctPeso", "% Peso");
            dataGridView1.Columns.Add("PctVenta", "% Venta");

            dataGridView1.Columns.Add("Cajas", "Cajas");
            dataGridView1.Columns.Add("Sales", "SALES");
            dataGridView1.Columns.Add("SalesBox", "SALES/BOX");

            dataGridView1.Columns.Add("Pct", "%");

            dataGridView1.Columns.Add("Comision", "Comisión");

            dataGridView1.Columns.Add("ContainerFreight", "Container Freight");
            dataGridView1.Columns.Add("Customs", "Customs Clearance");
            dataGridView1.Columns.Add("Duty", "Duty");
            dataGridView1.Columns.Add("Expeditor", "Expeditor");
            dataGridView1.Columns.Add("Inspections", "Inspections");
            dataGridView1.Columns.Add("LoadingStorage", "Loading & Storage");

            dataGridView1.Columns.Add("OceanFreight", "Ocean Freight");
            dataGridView1.Columns.Add("Repacking", "Repacking");

            dataGridView1.Columns.Add("TotalExpenses", "Total Expenses $");
            dataGridView1.Columns.Add("FOB", "FOB USD");
            dataGridView1.Columns.Add("FOB_KG", "FOB $ x KG");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void ColumnasDtgv2()
        {
            // 
            // Column1
            // 
            DataGridViewTextBoxColumn Dni = new DataGridViewTextBoxColumn();
            Dni.HeaderText = "DNI";
            Dni.Name = "Column1";
            Dni.Width = 85;
            dataGridView1.Columns.Add(Dni);
            //
            //
            DataGridViewTextBoxColumn Nombres = new DataGridViewTextBoxColumn();
            Nombres.HeaderText = "NOMBRES";
            Nombres.Name = "Column3";
            Nombres.Width = 85;
            dataGridView1.Columns.Add(Nombres);
            // 
            // Column4
            // 
            DataGridViewTextBoxColumn Empresa = new DataGridViewTextBoxColumn();
            Empresa.HeaderText = "EMPRESA";
            Empresa.Name = "Column4";
            Empresa.Width = 87;
            dataGridView1.Columns.Add(Empresa);
            //
            // Column5
            // 
            DataGridViewTextBoxColumn Autorizacion = new DataGridViewTextBoxColumn();
            Autorizacion.HeaderText = "AUTORIZACION";
            Autorizacion.Name = "Column5";
            Autorizacion.Width = 87;
            dataGridView1.Columns.Add(Autorizacion);
        }

        private void toolStripButton_Credenciales_CargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(textRuta.Text))
                {
                    MessageBox.Show("Seleccione un PDF");
                    return;
                }

                Cursor = Cursors.WaitCursor;


                if (guna2ComboBox_TipoProveedor.Text == "CLASSIC")
                {
                    ColumnasDtgv1();

                    string texto = LeerPdf(textRuta.Text);

                    if (string.IsNullOrWhiteSpace(texto))
                    {
                        MessageBox.Show("No se pudo leer el PDF.");
                        return;
                    }

                    VentaPdf venta = ExtraerDatos(texto);
                    AgregarAGrid(venta);
                }
                if (guna2ComboBox_TipoProveedor.Text == "SUN PACIFIC")
                {
                    ColumnasDtgv_SP();

                    string texto = LeerPdf_SP(textRuta.Text);

                    if (string.IsNullOrWhiteSpace(texto))
                    {
                        MessageBox.Show("No se pudo leer el PDF.");
                        return;
                    }

                    VentaPdf_SP venta = ExtraerDatos_SP(texto);
                    AgregarAGrid_SP(venta);
                }

                if (guna2ComboBox_TipoProveedor.Text == "LGS")
                {
                    ColumnasDtgv_LGS();

                    string texto = LeerPdf_LGS(textRuta.Text);

                    if (string.IsNullOrWhiteSpace(texto))
                    {
                        MessageBox.Show("No se pudo leer el PDF.");
                        return;
                    }

                    VentaPdf_LGS venta = ExtraerDatos_LGS(texto);
                    AgregarAGrid_LGS(venta);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private string LeerPdf(string rutaPdf)
        {
            StringBuilder sb = new StringBuilder();

            using (PdfDocument pdf = PdfDocument.Open(rutaPdf))
            {
                foreach (var page in pdf.GetPages())
                {
                    // Agrupar palabras por la coordenada vertical (misma línea)
                    var lineas = page.GetWords()
                                     .GroupBy(w => Math.Round(w.BoundingBox.Bottom))
                                     .OrderByDescending(g => g.Key);

                    foreach (var linea in lineas)
                    {
                        string textoLinea = string.Join(" ",
                            linea.OrderBy(w => w.BoundingBox.Left)
                                 .Select(w => w.Text));

                        sb.AppendLine(textoLinea);
                    }
                }
            }

            string texto = sb.ToString();

            Console.WriteLine("===== TEXTO RECONSTRUIDO =====");
            Console.WriteLine(texto);

            return texto;
        }

        private string NormalizarPDF(string texto)
        {
            texto = texto.Replace("\r", "");

            texto = Regex.Replace(
                texto,
                @"[ \t]+",
                " ");

            return texto;
        }

        private VentaPdf ExtraerDatos(string texto)
        {
            texto = NormalizarPDF(texto);

            VentaPdf v = new VentaPdf();

            v.Contenedor = ExtraerContenedor(texto);

            var prod = ExtraerProducto(texto);

            v.Cajas = prod.cajas;
            v.Sales = prod.sales;

            v.Variedad = "ORO GRANDE";

            v.var_desc = ExtraerVariedad(texto);

            var costos = ExtraerCostos(texto);

            Console.WriteLine("===== COSTOS ENCONTRADOS =====");

            foreach (var item in costos)
            {
                Console.WriteLine($"{item.Key} => {item.Value:N2}");
            }

            Console.WriteLine("==============================");

            v.ChepPallet =
                BuscarCosto(costos, "CHEP");

            v.ColdStorage =
                BuscarCosto(costos, "COLD STORAGE");

            v.Commission =
                BuscarCosto(costos, "COMMISSIONS");

            v.CustomsClearing =
                BuscarCosto(costos, "CUSTOMS");

            v.ImportTariff =
                BuscarCosto(costos, "IMPORT TARIFF");

            v.InlandFreight =
                BuscarCosto(costos, "INLAND FREIGHT");

            v.Inspections =
                BuscarCosto(costos, "INSPECTIONS");

            v.OceanFreight =
                BuscarCosto(costos, "OCEANFREIGHT");

            v.OperationsHandling =
                BuscarCosto(costos, "OPERATIONS");

            v.Repacking =
                BuscarCosto(costos, "REPACKING");


            // ================= DEBUG =================
            Console.WriteLine("");
            Console.WriteLine("=========== RESULTADO PDF ===========");
            Console.WriteLine($"Contenedor          : {v.Contenedor}");
            Console.WriteLine($"Variedad            : {v.Variedad}");
            Console.WriteLine($"Cajas               : {v.Cajas}");
            Console.WriteLine($"Sales               : {v.Sales:N2}");
            Console.WriteLine($"Price Per Box       : {v.PricePerBox:N2}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Commission          : {v.Commission:N2}");
            Console.WriteLine($"Chep Pallet         : {v.ChepPallet:N2}");
            Console.WriteLine($"Cold Storage        : {v.ColdStorage:N2}");
            Console.WriteLine($"Customs Clearing    : {v.CustomsClearing:N2}");
            Console.WriteLine($"Import Tariff       : {v.ImportTariff:N2}");
            Console.WriteLine($"Inland Freight      : {v.InlandFreight:N2}");
            Console.WriteLine($"Inspections         : {v.Inspections:N2}");
            Console.WriteLine($"Ocean Freight       : {v.OceanFreight:N2}");
            Console.WriteLine($"Operations Handling : {v.OperationsHandling:N2}");
            Console.WriteLine($"Repacking           : {v.Repacking:N2}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Total Expenses      : {v.TotalExpenses:N2}");
            Console.WriteLine($"Cost Per Box        : {v.CostPerBox:N2}");
            Console.WriteLine($"FOB USD             : {v.FOB:N2}");
            Console.WriteLine($"FOB x KG            : {v.FOBxKg:N3}");
            Console.WriteLine("=====================================");
            Console.WriteLine("");


            return v;
        }

        private string ExtraerContenedor(string texto)
        {
            Match m = Regex.Match(
                texto,
                @"MNBU\s*(\d{7,8})");

            if (!m.Success)
                return "";

            string numero = m.Groups[1].Value;

            if (numero.Length >= 7)
            {
                return $"MNBU {numero.Substring(0, 6)}-{numero.Substring(6)}";
            }

            return "MNBU " + numero;
        }

        private (int cajas, decimal sales) ExtraerProducto(string texto)
        {
            Match m = Regex.Match(
                texto,
                @"Mandarin Imports.*?\r?\n\s*(\d+)\s+35\.85\s+([\d,]+\.\d{2})",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (!m.Success)
                return (0, 0);

            int cajas = int.Parse(m.Groups[1].Value);

            decimal sales = decimal.Parse(
                m.Groups[2].Value.Replace(",", ""),
                CultureInfo.InvariantCulture);

            return (cajas, sales);
        }

        private decimal BuscarCosto(Dictionary<string, decimal> costos, string concepto)
        {
            foreach (var item in costos)
            {
                if (item.Key.Contains(concepto.ToUpper()))
                    return item.Value;
            }

            return 0;
        }

        private string ExtraerVariedad(string texto)
        {
            var lineas = texto.Split('\n');

            for (int i = 0; i < lineas.Length - 1; i++)
            {
                string actual = lineas[i].Trim();
                string siguiente = lineas[i + 1].Trim();

                // Detecta línea del producto + línea numérica
                if (Regex.IsMatch(siguiente, @"^\d+\s+[\d.]+\s+[\d,]+\.\d{2}"))
                {
                    return actual;
                }
            }

            return "";
        }

        private Dictionary<string, decimal> ExtraerCostos(string texto)
        {
            var costos = new Dictionary<string, decimal>();

            string[] lineas = texto.Split('\n');

            foreach (string lineaOriginal in lineas)
            {
                string linea = lineaOriginal.Trim();

                Match m = Regex.Match(
                    linea,
                    @"^(.*?)\s+([\d,]+\.\d{2})$");

                if (!m.Success)
                    continue;

                string descripcion =
                    m.Groups[1].Value.Trim();

                decimal monto =
                    decimal.Parse(
                        m.Groups[2].Value.Replace(",", ""),
                        CultureInfo.InvariantCulture);

                costos[descripcion.ToUpper()] = monto;
            }

            return costos;
        }

        private void AgregarAGrid(VentaPdf v)
        {
            dataGridView1.Rows.Add(
                v.Contenedor,
                v.TotalKg,
                v.Variedad,
                v.var_desc,
                v.Documento,

                "100%",
                "100%",

                v.Cajas,
                v.Sales,
                v.PricePerBox,

                "",

                v.Commission,
                v.ChepPallet,
                v.ColdStorage,
                v.CustomsClearing,
                v.ImportTariff,
                v.InlandFreight,
                v.Inspections,
                v.OceanFreight,
                v.OperationsHandling,
                v.Repacking,

                v.TotalExpenses,
                v.CostPerBox,
                v.FOB,
                v.FOBxKg
            );
        }


        /// <summary>
        /// EXTRAER COSTOS SAN PACIFIC
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        /// 

        private VentaPdf_SP ExtraerDatos_SP(string texto)
        {
            texto = NormalizarPDF_SP(texto);

            VentaPdf_SP v = new VentaPdf_SP();

            //==============================
            // DATOS GENERALES
            //==============================

            v.Contenedor = ExtraerContenedor_SP(texto);

            v.Cajas = ExtraerCajas_SP(texto);

            v.Sales = ExtraerSales_SP(texto);

            v.Variedad = "ORO GRANDE";

            // Si deseas luego puedes crear ExtraerVariedad_SP()
            v.VarDesc = "MANDARIN";

            //==============================
            // COSTOS
            //==============================

            var costos = ExtraerCostos_SP(texto);

            Console.WriteLine("===== COSTOS ENCONTRADOS =====");

            foreach (var item in costos)
            {
                Console.WriteLine($"{item.Key} => {item.Value:N2}");
            }

            Console.WriteLine("==============================");

            v.Commission =
                BuscarCosto(costos, "SALES COMMISSION");

            v.CustomBroker =
                BuscarCosto(costos, "CUSTOM BROKER");

            v.ExpeditorFees =
                BuscarCosto(costos, "EXPEDITOR FEES");

            v.InlandFreight =
                BuscarCosto(costos, "INLAND FREIGHT");

            v.PortFees =
                BuscarCosto(costos, "DEMURRAGE");

            v.Inspection =
                BuscarCosto(costos, "INSPECTION");

            v.ExamFee =
                BuscarCosto(costos, "EXAM FEE");

            v.MaterialBoxes =
                BuscarCosto(costos, "MATERIAL-BOXES");

            v.MaterialFilm =
                BuscarCosto(costos, "MATERIAL-FILM");

            v.MaterialShipping =
                BuscarCosto(costos, "MATERIAL-SHIPPING");

            v.MaterialPallets =
                BuscarCosto(costos, "MATERIAL-PALLETS");

            v.OceanFreight =
                BuscarCosto(costos, "OCEAN FREIGHT");

            v.PackingFees =
                BuscarCosto(costos, "PACKING FEES");

            v.StorageFee =
                BuscarCosto(costos, "STORAGE FEE");

            v.CutiesMarketingAccrual =
                BuscarCosto(costos, "CUTIES MARKETING ACCRUAL");

            v.Tariff =
                BuscarCosto(costos, "TARIFF");

            v.HarborMaintenanceFee =
                BuscarCosto(costos, "HARBOR MAINTENANCE FEE");

            //==============================
            // PORCENTAJES
            //==============================

            // En el PDF figura 3.31 (Per Ctn)
            // En tu Excel quieres 0.32%.
            // Ajusta este valor según tu lógica de negocio.
            v.CommissionPct = 0.32m;

            //==============================
            // DEBUG
            //==============================

            Console.WriteLine();
            Console.WriteLine("========== RESULTADO SUN PACIFIC ==========");

            Console.WriteLine($"Contenedor                 : {v.Contenedor}");
            Console.WriteLine($"Variedad                   : {v.Variedad}");
            Console.WriteLine($"Cajas                      : {v.Cajas}");
            Console.WriteLine($"Sales                      : {v.Sales:N2}");
            Console.WriteLine($"Price Per Box              : {v.PricePerBox:N2}");

            Console.WriteLine("-------------------------------------------");

            Console.WriteLine($"Commission                 : {v.Commission:N2}");
            Console.WriteLine($"Custom Broker              : {v.CustomBroker:N2}");
            Console.WriteLine($"Expeditor Fees             : {v.ExpeditorFees:N2}");
            Console.WriteLine($"Inland Freight             : {v.InlandFreight:N2}");
            Console.WriteLine($"Port Fees                  : {v.PortFees:N2}");
            Console.WriteLine($"Inspection                 : {v.Inspection:N2}");
            Console.WriteLine($"Exam Fee                   : {v.ExamFee:N2}");
            Console.WriteLine($"Material Boxes             : {v.MaterialBoxes:N2}");
            Console.WriteLine($"Material Film              : {v.MaterialFilm:N2}");
            Console.WriteLine($"Material Shipping          : {v.MaterialShipping:N2}");
            Console.WriteLine($"Material Pallets           : {v.MaterialPallets:N2}");
            Console.WriteLine($"Ocean Freight              : {v.OceanFreight:N2}");
            Console.WriteLine($"Packing Fees               : {v.PackingFees:N2}");
            Console.WriteLine($"Storage Fee                : {v.StorageFee:N2}");
            Console.WriteLine($"Cuties Marketing Accrual   : {v.CutiesMarketingAccrual:N2}");
            Console.WriteLine($"Tariff                     : {v.Tariff:N2}");
            Console.WriteLine($"Harbor Maintenance Fee     : {v.HarborMaintenanceFee:N2}");

            Console.WriteLine("-------------------------------------------");

            Console.WriteLine($"Total Expenses             : {v.TotalExpenses:N2}");
            Console.WriteLine($"FOB                        : {v.FOB:N2}");
            Console.WriteLine($"FOB x KG                   : {v.FOBxKg:N2}");

            Console.WriteLine("===========================================");
            Console.WriteLine();

            return v;
        }

        private string LeerPdf_SP(string rutaPdf)
        {
            StringBuilder sb = new StringBuilder();

            using (PdfDocument pdf = PdfDocument.Open(rutaPdf))
            {
                foreach (var page in pdf.GetPages())
                {
                    // Agrupar palabras por la coordenada vertical (misma línea)
                    var lineas = page.GetWords()
                                     .GroupBy(w => Math.Round(w.BoundingBox.Bottom))
                                     .OrderByDescending(g => g.Key);

                    foreach (var linea in lineas)
                    {
                        string textoLinea = string.Join(" ",
                            linea.OrderBy(w => w.BoundingBox.Left)
                                 .Select(w => w.Text));

                        sb.AppendLine(textoLinea);
                    }
                }
            }

            string texto = sb.ToString();
            texto = Regex.Replace(
            texto,
            @"(\d)\s+(\d{1,3},\d{3}\.\d{2})",
            "$1$2");

            Console.WriteLine("===== TEXTO RECONSTRUIDO =====");
            Console.WriteLine(texto);

            return texto;
        }

        private string NormalizarPDF_SP(string texto)
        {
            texto = texto.Replace("\r", "");

            texto = Regex.Replace(
                texto,
                @"[ \t]+",
                " ");

            return texto;
        }

        private Dictionary<string, decimal> ExtraerCostos_SP(string texto)
        {
            var costos = new Dictionary<string, decimal>();

            string[] lineas = texto.Split('\n');

            foreach (string l in lineas)
            {
                string linea = l.Trim();

                //----------------------------------------
                // OCEAN FREIGHT
                //----------------------------------------
                if (linea.StartsWith("OCEAN FREIGHT"))
                {
                    Match m = Regex.Match(linea,
                        @"OCEAN FREIGHT.*?(\d{2},\d{3}\.\d{2})");

                    if (m.Success)
                    {
                        costos["OCEAN FREIGHT"] =
                            decimal.Parse(
                                m.Groups[1].Value.Replace(",", ""),
                                CultureInfo.InvariantCulture);

                        continue;
                    }
                }

                //----------------------------------------
                // PACKING FEES
                //----------------------------------------
                if (linea.StartsWith("PACKING FEES"))
                {
                    Match m = Regex.Match(linea,
                        @"PACKING FEES.*?(\d{2},\d{3}\.\d{2})");

                    if (m.Success)
                    {
                        costos["PACKING FEES"] =
                            decimal.Parse(
                                m.Groups[1].Value.Replace(",", ""),
                                CultureInfo.InvariantCulture);

                        continue;
                    }
                }

                //----------------------------------------
                // TARIFF
                //----------------------------------------
                if (linea.StartsWith("TARIFF"))
                {
                    Match m = Regex.Match(linea,
                        @"\(([\d,]+\.\d{2})\)");

                    if (m.Success)
                    {
                        costos["TARIFF"] =
                            decimal.Parse(
                                m.Groups[1].Value.Replace(",", ""),
                                CultureInfo.InvariantCulture);

                        continue;
                    }
                }

                //----------------------------------------
                // HARBOR
                //----------------------------------------
                if (linea.StartsWith("HARBOR MAINTENANCE"))
                {
                    Match m = Regex.Match(linea,
                        @"\(([\d,]+\.\d{2})\)");

                    if (m.Success)
                    {
                        costos["HARBOR MAINTENANCE FEE"] =
                            decimal.Parse(
                                m.Groups[1].Value.Replace(",", ""),
                                CultureInfo.InvariantCulture);

                        continue;
                    }
                }

                //----------------------------------------
                // resto de conceptos
                //----------------------------------------
                Match x = Regex.Match(linea,
                    @"^(.*?)\s+([\d,]+\.\d{2})\s+[\d.()-]+$");

                if (x.Success)
                {
                    costos[x.Groups[1].Value.Trim()] =
                        decimal.Parse(
                            x.Groups[2].Value.Replace(",", ""),
                            CultureInfo.InvariantCulture);
                }
            }

            return costos;
        }

        private string ExtraerContenedor_SP(string texto)
        {
            Match m = Regex.Match(
                texto,
                @"MNBU\d{7,8}",
                RegexOptions.IgnoreCase);

            if (!m.Success) return "";

            string num = m.Value.Replace("MNBU", "");

            return $"MNBU {num.Substring(0, 6)}-{num.Substring(6)}";
        }

        private decimal ExtraerSales_SP(string texto)
        {
            Match m = Regex.Match(
                texto,
                @"Total Sales:\s*([\d,]+\.\d{2})",
                RegexOptions.IgnoreCase);

            if (!m.Success) return 0;

            return decimal.Parse(m.Groups[1].Value.Replace(",", ""),
                CultureInfo.InvariantCulture);
        }

        private int ExtraerCajas_SP(string texto)
        {
            Match m = Regex.Match(
                texto,
                @"TOTAL\s+([\d,]+)",
                RegexOptions.IgnoreCase);

            if (!m.Success) return 0;

            return int.Parse(m.Groups[1].Value.Replace(",", ""));
        }

        private void AgregarAGrid_SP(VentaPdf_SP v)
        {
            dataGridView1.Rows.Add(

                v.Contenedor,
                v.TotalKg,
                v.Variedad,
                v.VarDesc,
                v.Documento,


                "100%",
                "100%",
                //v.PctPeso,
                //v.PctVenta,

                v.Cajas,
                v.Sales,
                v.PricePerBox,

                v.CommissionPct,

                v.Commission,
                v.CustomBroker,
                v.ExpeditorFees,
                v.InlandFreight,
                v.PortFees,
                v.Inspection,
                v.ExamFee,
                v.MaterialBoxes,
                v.MaterialFilm,
                v.MaterialShipping,
                v.MaterialPallets,
                v.OceanFreight,
                v.PackingFees,
                v.StorageFee,
                v.CutiesMarketingAccrual,
                v.Tariff,
                v.HarborMaintenanceFee,

                v.TotalExpenses,
                v.FOB,
                v.FOBxKg
            );
        }


        /// <summary>
        /// EXTRAER COSTOS LGS
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        /// 

        private string LeerPdf_LGS(string rutaPdf)
        {
            StringBuilder sb = new StringBuilder();

            using (PdfDocument pdf = PdfDocument.Open(rutaPdf))
            {
                foreach (var page in pdf.GetPages())
                {
                    var lineas = page.GetWords()
                        .GroupBy(w => Math.Round(w.BoundingBox.Bottom, 1))
                        .OrderByDescending(g => g.Key);

                    foreach (var linea in lineas)
                    {
                        string textoLinea = string.Join(" ",
                            linea.OrderBy(w => w.BoundingBox.Left)
                                 .Select(w => w.Text));

                        sb.AppendLine(textoLinea);
                    }
                }
            }

            string texto = sb.ToString();

            // 🔴 FIX 1: separa números pegados (CRÍTICO)
            texto = Regex.Replace(texto,
                @"(\d{1,3},\d{3})(\d{3},\d{2})",
                "$1 $2");

            // 🔴 FIX 2: arregla spacing general de números
            texto = Regex.Replace(texto,
                @"(\d)\s{2,}(\d)",
                "$1$2");

            Console.WriteLine("===== TEXTO LGS =====");
            Console.WriteLine(texto);

            return texto;
        }

        private VentaPdf_LGS ExtraerDatos_LGS(string texto)
        {
            texto = NormalizarPDF_SP(texto);

            VentaPdf_LGS v = new VentaPdf_LGS();

            // =========================
            // IDENTIFICACIÓN
            // =========================
            v.Contenedor = ExtraerContenedor_LGS(texto);
            v.Variedad = ExtraerVariedad_LGS(texto);
            v.Var_Desc = v.Variedad;
            v.Documento = "LGS ACCOUNT";

            // =========================
            // VENTAS
            // =========================
            v.Cajas = ExtraerCajas_LGS(texto);
            v.Sales = ExtraerSales_LGS(texto);
            v.SalesPerBox = ExtraerAvgPrice_LGS(texto);
            v.TotalKg = ExtraerTotalKg_LGS(texto);   // 🔴 NUEVO

            // =========================
            // COSTOS
            // =========================
            var costos = ExtraerCostos_LGS(texto);

            v.Commission = BuscarCosto(costos, "MARKETING FEE");
            v.ContainerFreight = BuscarCosto(costos, "CONTAINER FREIGHT");
            v.CustomsClearance = BuscarCosto(costos, "CUSTOMS CLEARANCE");
            v.Duty = BuscarCosto(costos, "DUTY");
            v.Expeditor = BuscarCosto(costos, "EXPEDITOR");
            v.Inspections = BuscarCosto(costos, "INSPECTIONS");
            v.LoadingStorage = BuscarCosto(costos, "LOADING & STORAGE");
            v.OceanFreight = BuscarCosto(costos, "OCEAN FREIGHT");
            v.Repacking = BuscarCosto(costos, "REPACKING");

            Console.WriteLine($"FOB: {v.FOB:N2}");

            return v;
        }

        private Dictionary<string, decimal> ExtraerCostos_LGS(string texto)
        {
            Dictionary<string, decimal> costos =
                new Dictionary<string, decimal>();

            string[] lineas = texto.Split('\n');

            foreach (string l in lineas)
            {
                string linea = Regex.Replace(l, @"\s+", " ").Trim();

                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                // ================================
                // 1. CASO NORMAL (tu lógica original)
                // ================================
                Match mNormal = Regex.Match(
                    linea,
                    @"^(Container Freight|Customs Clearance|Duty|Expeditor|Inspections|Loading\s*&\s*Storage|Ocean Freight|Repacking|Less:\s*Marketing Fee|Total Expenses|Total Return|Net Proceeds)\s+([\d,]+\.\d{2})",
                    RegexOptions.IgnoreCase);

                if (mNormal.Success)
                {
                    string concepto = mNormal.Groups[1].Value.ToUpper().Replace("LESS: ", "");
                    decimal valor = decimal.Parse(mNormal.Groups[2].Value.Replace(",", ""), CultureInfo.InvariantCulture);

                    costos[concepto] = valor;

                    Console.WriteLine($"{concepto} => {valor}");
                    continue;
                }

                // ================================
                // 2. CASO PDF REAL (CONTAINER + FECHA + CONCEPTO)
                // ================================

                Match mAlt = Regex.Match(
                    linea,
                    @"(Container Freight|Customs Clearance|Duty|Expeditor|Inspections|Loading\s*&\s*Storage|Ocean Freight|Repacking)\s+([\d,]+\.\d{2})$",
                    RegexOptions.IgnoreCase);

                if (mAlt.Success)
                {
                    string concepto = mAlt.Groups[1].Value.ToUpper();
                    decimal valor = decimal.Parse(mAlt.Groups[2].Value.Replace(",", ""), CultureInfo.InvariantCulture);

                    costos[concepto] = valor;

                    Console.WriteLine($"{concepto} => {valor}");
                }
            }

            return costos;
        }

        private string ExtraerContenedor_LGS(string texto)
        {
            MatchCollection mc = Regex.Matches(
                texto,
                @"\b[A-Z]{4}\d{7}\b",
                RegexOptions.IgnoreCase);

            if (mc.Count == 0)
                return "";

            // normalmente ERP usa el segundo contenedor
            string c = mc.Count >= 2 ? mc[1].Value : mc[0].Value;

            return $"{c.Substring(0, 4)} {c.Substring(4, 6)}-{c.Substring(10, 1)}";
        }

        private int ExtraerCajas_LGS(string texto)
        {
            Match m = Regex.Match(texto,
                @"Total\s+([\d,]+)\s+([\d,]+\.\d{2})");

            if (!m.Success)
                return 0;

            return int.Parse(m.Groups[1].Value.Replace(",", ""));
        }

        private string ExtraerVariedad_LGS(string texto)
        {
            Match m = Regex.Match(
                texto,
                @"Clementines\s+([A-Za-z]+)",
                RegexOptions.IgnoreCase);

            if (m.Success)
                return m.Groups[1].Value.ToUpper();

            return "";
        }

        private decimal ExtraerSales_LGS(string texto)
        {
            Match m = Regex.Match(
                texto,
                @"Total\s+[\d,]+\s+([\d,]+\.\d{2})",
                RegexOptions.IgnoreCase);

            if (m.Success)
            {
                return decimal.Parse(
                    m.Groups[1].Value.Replace(",", ""),
                    CultureInfo.InvariantCulture);
            }

            // fallback seguro
            MatchCollection mc = Regex.Matches(texto, @"\d{1,3}(?:,\d{3})+\.\d{2}");

            decimal max = 0;

            foreach (Match x in mc)
            {
                decimal val = decimal.Parse(x.Value.Replace(",", ""),
                    CultureInfo.InvariantCulture);

                if (val > max)
                    max = val;
            }

            return max;
        }

        private decimal ExtraerTotalKg_LGS(string texto)
        {
            Match m = Regex.Match(texto,
                @"Total\s+([\d,]+)\s+[\d,]+\.\d{2}");

            if (!m.Success)
                return 0;

            return decimal.Parse(m.Groups[1].Value.Replace(",", ""));
        }

        private decimal ExtraerAvgPrice_LGS(string texto)
        {
            MatchCollection mc = Regex.Matches(texto,
                @"\d+\.\d{2}");

            if (mc.Count == 0)
                return 0;

            // 🔴 C# 7.3 compatible (SIN ^ operator)
            Match last = mc[mc.Count - 1];

            return decimal.Parse(
                last.Value,
                CultureInfo.InvariantCulture);
        }

        private void AgregarAGrid_LGS(VentaPdf_LGS v)
        {
            dataGridView1.Rows.Add(

                v.Contenedor,          //0
                v.TotalKg,             //1

                v.Variedad,            //2
                v.Var_Desc,            //3
                v.Documento,           //4

                v.PctPeso,             //5
                v.PctVenta,            //6

                v.Cajas,               //7
                v.Sales,               //8
                v.SalesPerBox,         //9

                v.Pct,                 //10   <<< ESTA FALTABA

                v.Commission,          //11

                v.ContainerFreight,    //12
                v.CustomsClearance,    //13
                v.Duty,                //14
                v.Expeditor,           //15
                v.Inspections,         //16
                v.LoadingStorage,      //17
                v.OceanFreight,        //18
                v.Repacking,           //19

                v.TotalExpenses,       //20
                v.FOB,                 //21
                v.FOBxKg               //22

            );
        }



        private void LeerPdfConOCR(string rutaPdf)
        {
            StringBuilder sb = new StringBuilder();

            using (var document = PdfDocument.Open(rutaPdf))
            {
                foreach (var page in document.GetPages())
                {
                    sb.AppendLine(page.Text);
                }
            }

            string texto = sb.ToString();

            string carpeta = Path.GetDirectoryName(rutaPdf);

            string archivoDebug = Path.Combine(
                carpeta,
                "pdf_extraido.txt");

            File.WriteAllText(archivoDebug, texto);

            //MessageBox.Show(texto);
            Console.WriteLine(texto);
            Console.WriteLine(
            Regex.Match(texto,
            @"Chep Pallet(.*?)Cold Storage",
            RegexOptions.IgnoreCase).Groups[1].Value);

            ExtraerDatos(texto);
        }

        /*private void ExtraerDatos(string texto)
        {
            VentaPdf venta = new VentaPdf();

            // =====================================
            // CONTENEDOR
            // =====================================
            Match mContenedor =
                Regex.Match(texto, @"MNBU\d+");

            if (mContenedor.Success)
                venta.Contenedor = mContenedor.Value;

            // =====================================
            // CLIENTE
            // Texto:
            // MNBU4558015 004 Costco MAClose Date:
            // =====================================
            Match mCliente =
                Regex.Match(
                    texto,
                    @"MNBU\d+\s+\d+\s+(.*?)Close Date",
                    RegexOptions.IgnoreCase);

            if (mCliente.Success)
                venta.Cliente = mCliente.Groups[1].Value.Trim();

            // =====================================
            // VARIEDAD
            // Mandarin Imports
            // =====================================
            Match mVariedad =
                Regex.Match(
                    texto,
                    @"([A-Za-z]+)\s+Imports",
                    RegexOptions.IgnoreCase);

            if (mVariedad.Success)
                venta.Variedad = mVariedad.Groups[1].Value.Trim();

            // =====================================
            // SALES
            // Texto:
            // Total Product:35.85174262,450.70
            // Price=35.85
            // Qty=1742
            // Amount=62,450.70
            // =====================================
            Match mSales = Regex.Match(
                texto,
                @"Total Product:\d+\.\d+(\d+)([\d,]+\.\d{2})Chep Pallet",
                RegexOptions.IgnoreCase);

            if (mSales.Success)
            {
                venta.Cajas = int.Parse(mSales.Groups[1].Value);

                decimal.TryParse(
                    mSales.Groups[2].Value.Replace(",", ""),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out decimal sales);

                venta.Sales = sales;
            }

            // =====================================
            // CAJAS
            // Usaremos Qty del producto
            // 1742 35.85 Mandarin Imports
            // =====================================
            Match mCajas =
                Regex.Match(
                    texto,
                    @"(\d+)35\.85Mandarin Imports",
                    RegexOptions.IgnoreCase);

            if (mCajas.Success)
            {
                int.TryParse(
                    mCajas.Groups[1].Value,
                    out int cajas);

                venta.Cajas = cajas;
            }

            // =====================================
            // NET RETURN
            // =====================================
            Match mNet =
                Regex.Match(
                    texto,
                    @"Net Return:([\d,]+\.\d{2})",
                    RegexOptions.IgnoreCase);

            if (mNet.Success)
            {
                decimal.TryParse(
                    mNet.Groups[1].Value.Replace(",", ""),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out decimal net);

                venta.NetReturn = net;
            }

            // =====================================
            // GROWER ADVANCE
            // Grower Advances - IMPORTS135213,520.0010.00
            // =====================================
            Match mGrower =
                Regex.Match(
                    texto,
                    @"Grower Advances\s*-\s*IMPORTS\d+([\d,]+\.\d{2})10\.00",
                    RegexOptions.IgnoreCase);

            if (mGrower.Success)
            {
                decimal.TryParse(
                    mGrower.Groups[1].Value.Replace(",", ""),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out decimal grower);

                venta.GrowerAdvance = grower;
            }

            // =====================================
            // COMISION
            // Commissions Imports4,996.05
            // =====================================
            venta.Commission =
    ExtraerMontoDespuesDe(texto, "Commissions Imports");

            venta.ChepPallet =
    ExtraerMontoEntreConceptos(
        texto,
        "Chep Pallet",
        "Cold Storage In/Out Fees");

            venta.ColdStorage =
                ExtraerMontoEntreConceptos(
                    texto,
                    "Cold Storage In/Out Fees",
                    "Commissions Imports");

            venta.CustomsClearing =
                ExtraerMontoEntreConceptos(
                    texto,
                    "Customs/Clearing",
                    "Grower Advances");

            venta.ImportTariff =
                ExtraerMontoEntreConceptos(
                    texto,
                    "Import Tariff",
                    "Inland Freight Charges");

            venta.InlandFreight =
                ExtraerMontoEntreConceptos(
                    texto,
                    "Inland Freight Charges",
                    "Inspections");

            venta.Inspections =
                ExtraerMontoEntreConceptos(
                    texto,
                    "Inspections",
                    "OceanFreight - Imports");

            venta.OceanFreight =
                ExtraerMontoEntreConceptos(
                    texto,
                    "OceanFreight - Imports",
                    "Operations/Handling");

            venta.OperationsHandling =
                ExtraerMontoEntreConceptos(
                    texto,
                    "Operations/Handling",
                    "Repacking");

            venta.Repacking =
                ExtraerMontoEntreConceptos(
                    texto,
                    "Repacking",
                    "Total Charges");

            // =====================================
            // TOTAL EXPENSES
            // NO incluye Commission
            // NO incluye Grower Advance
            // =====================================
            venta.TotalExpenses =
                  venta.ChepPallet
                + venta.ColdStorage
                + venta.CustomsClearing
                + venta.ImportTariff
                + venta.InlandFreight
                + venta.Inspections
                + venta.OceanFreight
                + venta.OperationsHandling
                + venta.Repacking;

            // =====================================
            // CALCULOS
            // =====================================
            venta.PctPeso = 1m;
            venta.PctVenta = 1m;

            venta.PricePerBox =
                venta.Cajas > 0
                    ? venta.Sales / venta.Cajas
                    : 0;

            venta.PctCommission =
                venta.Sales > 0
                    ? venta.Commission / venta.Sales
                    : 0;

            venta.CostPerBox =
                venta.Cajas > 0
                    ? venta.TotalExpenses / venta.Cajas
                    : 0;

            venta.FOB =
                venta.Sales - venta.TotalExpenses;

            venta.FOBxKg =
                venta.TotalKg > 0
                    ? venta.FOB / venta.TotalKg
                    : 0;

            // =====================================
            // DEBUG
            // =====================================
            Console.WriteLine("================================");
            Console.WriteLine($"Contenedor      : {venta.Contenedor}");
            Console.WriteLine($"Cliente         : {venta.Cliente}");
            Console.WriteLine($"Variedad        : {venta.Variedad}");
            Console.WriteLine($"Cajas           : {venta.Cajas}");
            Console.WriteLine($"Sales           : {venta.Sales:N2}");
            Console.WriteLine($"Commission      : {venta.Commission:N2}");
            Console.WriteLine($"Chep            : {venta.ChepPallet:N2}");
            Console.WriteLine($"Cold            : {venta.ColdStorage:N2}");
            Console.WriteLine($"Customs         : {venta.CustomsClearing:N2}");
            Console.WriteLine($"Import Tariff   : {venta.ImportTariff:N2}");
            Console.WriteLine($"Inland Freight  : {venta.InlandFreight:N2}");
            Console.WriteLine($"Inspections     : {venta.Inspections:N2}");
            Console.WriteLine($"Ocean Freight   : {venta.OceanFreight:N2}");
            Console.WriteLine($"Operations      : {venta.OperationsHandling:N2}");
            Console.WriteLine($"Repacking       : {venta.Repacking:N2}");
            Console.WriteLine($"Expenses        : {venta.TotalExpenses:N2}");
            Console.WriteLine($"FOB             : {venta.FOB:N2}");
            Console.WriteLine($"Net Return      : {venta.NetReturn:N2}");
            Console.WriteLine("================================");

            Console.WriteLine("=== FRAGMENTOS ===");
            Console.WriteLine(Regex.Match(texto, @"Chep Pallet(.*?)Cold Storage", RegexOptions.IgnoreCase).Groups[1].Value);
            Console.WriteLine(Regex.Match(texto, @"Cold Storage In/Out Fees(.*?)Commissions", RegexOptions.IgnoreCase).Groups[1].Value);
            Console.WriteLine(Regex.Match(texto, @"Customs/Clearing(.*?)Grower Advances", RegexOptions.IgnoreCase).Groups[1].Value);
            Console.WriteLine("==================");

            // =====================================
            // GRID
            // =====================================
            dataGridView1.Rows.Add(
                venta.Contenedor,
                venta.Sales.ToString("N2"),
                venta.PctPeso.ToString("P2"),
                venta.PctVenta.ToString("P2"),
                venta.PricePerBox.ToString("N2"),
                venta.PctCommission.ToString("P2"),
                venta.Commission.ToString("N2"),
                venta.ChepPallet.ToString("N2"),
                venta.ColdStorage.ToString("N2"),
                venta.CustomsClearing.ToString("N2"),
                venta.ImportTariff.ToString("N2"),
                venta.InlandFreight.ToString("N2"),
                venta.Inspections.ToString("N2"),
                venta.OceanFreight.ToString("N2"),
                venta.OperationsHandling.ToString("N2"),
                venta.Repacking.ToString("N2"),
                venta.TotalExpenses.ToString("N2"),
                venta.CostPerBox.ToString("N2"),
                venta.FOB.ToString("N2"),
                venta.FOBxKg.ToString("N3")
            );
        }

        private decimal ExtraerValor(string texto, string keyword)
        {
            int pos = texto.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);
            if (pos < 0) return 0;

            string bloque = texto.Substring(pos, Math.Min(400, texto.Length - pos));

            // extrae todos los posibles números
            MatchCollection matches = Regex.Matches(bloque, @"[\d,]+\.?\d{0,2}");

            if (matches.Count == 0) return 0;

            string raw = matches[matches.Count - 1].Value;

            decimal.TryParse(
                raw.Replace(",", ""),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out decimal val);

            return val;
        }
        */


        public void mostrarDatosOF()
        {
            string hojaText = string.Empty, hoja;
            ////////////////////////////////////
            if (comboBox_Hojas.InvokeRequired)
            {
                comboBox_Hojas.Invoke(new MethodInvoker(() =>
                {
                    hojaText = comboBox_Hojas.Text;
                }));
            }
            else
            {
                hojaText = comboBox_Hojas.Text;
            }

            // Cargar los datos desde el DataTable
            dtg = dtsTablas.Tables[hojaText];
            dataGridView1.ClearSelection();


            // Rellenar el DataGridView con los datos
            //dataGridView1.DataSource = dtg;
        }

        private void toolStripButton_guardar_Click(object sender, EventArgs e)
        {
            // Obtener datagridview
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new MethodInvoker(() =>
                {
                    dataGridView1.AllowUserToAddRows = false;
                }));
            }

            if (dataGridView1.Rows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    string MessageBoxTitle = guna2ComboBox_TipoProveedor.Text;
                    string MessageBoxContent = "¿Desea Guardar?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (guna2ComboBox_TipoProveedor.Text == "CARGA ORIGINAL")
                        {
                            GuardarDatosSync();
                        }
                        else if (guna2ComboBox_TipoProveedor.Text == "CARGA AJUSTADO")
                        {
                            GuardarDatosSyncFn();
                        }
                    }

                    //GuardarProductividad();
                }

                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
            else
            {
                Msbox.Frm_NotificacionesPeligro ng = new Msbox.Frm_NotificacionesPeligro("FALTA CARGAR DATOS", Color.FromArgb(238, 24, 24), 3);
                ng.ShowDialog();
            }

        }


        private async void GuardarDatosSync()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            frbm.label1.Text = "🤖 ANALIZANDO Y PROCESANDO..."; // Actualizar el texto del formulario de carga

            try
            {
                // Esperar 1 segundo antes de continuar
                await Task.Delay(600);
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    //GuardarTareoFinal();
                    GuardarReporteLiquidacionesBulk();
                });


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
                              // Mostrar mensaje de éxito

            }
        }

        public object GuardarReporteLiquidacionesBulk()
        {
            try
            {
                // 1️⃣ Convertir el DataGridView a una lista de entidades ce_liquidaciones
                List<ce_liquidaciones> listaLiquidaciones = ConvertirDataGridViewALista(dataGridView1);

                // 2️⃣ Convertir la lista a un DataTable compatible con el TVP de SQL
                DataTable dt = ConvertirListaADataTable(listaLiquidaciones);

                // 3️⃣ Llamar al método de la capa de datos
                var result = cd_comercial.UpsertLiquidacionesSave(dt);

                bool success = result.IdLiq != null;

                string mensaje = result.Mensaje;
                string titulo = success ? "Éxito" : "Error al Guardar";
                MessageBoxIcon icono = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;

                // Mostrar el MessageBox
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);


                // 5️⃣ Retornar respuesta estructurada (por si quieres usarla en código)
                return new
                {
                    Success = success,
                    Message = result.Mensaje,
                    IdLiq = result.IdLiq
                };
            }
            catch (Exception ex)
            {
                string mensajeError = "Error al realizar el UPSERT: " + ex.Message;
                string titulo = "Error al guardar";

                // Mostrar el MessageBox
                MessageBox.Show(mensajeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new
                {
                    Success = false,
                    Message = "Error al Guardar: " + ex.Message,
                    IdLiq = (int?)null
                };
            }
        }


        public List<ce_liquidaciones> ConvertirDataGridViewALista(DataGridView dgv)
        {

            string hojaText = string.Empty;

            // Obtener el valor de la hojaText
            if (comboBox_Hojas.InvokeRequired)
            {
                comboBox_Hojas.Invoke(new MethodInvoker(() =>
                {
                    hojaText = comboBox_Hojas.Text;
                }));
            }
            else
            {
                hojaText = comboBox_Hojas.Text;
            }

            List<ce_liquidaciones> lista = new List<ce_liquidaciones>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    ce_liquidaciones entidad = new ce_liquidaciones
                    {
                        idliq = 0, // SQL Server genera el ID automáticamente

                        // 🟢 Datos de embarque
                        ShipmentCode = hojaText, // Se asigna desde la variable externa

                        // 🟢 Datos del bloque
                        growerblockid = row.Cells[0].Value?.ToString(),
                        blockname = row.Cells[1].Value?.ToString(),

                        // 🟢 Información de transacción
                        trxtype = decimal.TryParse(row.Cells[2].Value?.ToString(), out decimal trxtypeVal) ? trxtypeVal : (decimal?)null,
                        chargeorderby = decimal.TryParse(row.Cells[3].Value?.ToString(), out decimal chargeorderbyVal) ? chargeorderbyVal : (decimal?)null,
                        chargeid = row.Cells[4].Value?.ToString(),
                        chargedescr = row.Cells[5].Value?.ToString(),
                        chargeratetype = decimal.TryParse(row.Cells[6].Value?.ToString(), out decimal chargeratetypeVal) ? chargeratetypeVal : (decimal?)null,
                        invcqnt = decimal.TryParse(row.Cells[7].Value?.ToString(), out decimal invcqntVal) ? invcqntVal : (decimal?)null,

                        // 🟢 Montos
                        saleamt = decimal.TryParse(row.Cells[8].Value?.ToString(), out decimal saleamtVal) ? saleamtVal : (decimal?)null,
                        chgqnt = decimal.TryParse(row.Cells[9].Value?.ToString(), out decimal chgqntVal) ? chgqntVal : (decimal?)null,
                        chgamt = decimal.TryParse(row.Cells[10].Value?.ToString(), out decimal chgamtVal) ? chgamtVal : (decimal?)null,

                        // 🟢 Descripción del producto
                        gwrproductdescr = row.Cells[11].Value?.ToString(),
                        cmtyinvc = row.Cells[12].Value?.ToString(),
                        vrtyinvc = row.Cells[13].Value?.ToString(),

                        // 🟢 Clasificación
                        styleorderby = decimal.TryParse(row.Cells[14].Value?.ToString(), out decimal styleorderbyVal) ? styleorderbyVal : (decimal?)null,
                        gradeinvc = row.Cells[15].Value?.ToString(),
                        gradeorderby = decimal.TryParse(row.Cells[16].Value?.ToString(), out decimal gradeorderbyVal) ? gradeorderbyVal : (decimal?)null,
                        sizeorderby = decimal.TryParse(row.Cells[17].Value?.ToString(), out decimal sizeorderbyVal) ? sizeorderbyVal : (decimal?)null,

                        // 🟢 Unidad y factores de cargo
                        uom = row.Cells[18].Value?.ToString(),
                        fcchargeidx = row.Cells[19].Value?.ToString(),
                        invcicqnt = decimal.TryParse(row.Cells[20].Value?.ToString(), out decimal invcicqntVal) ? invcicqntVal : (decimal?)null,

                        // 🟢 Información de compañía
                        astitle = row.Cells[21].Value?.ToString(),
                        ascompanyname = row.Cells[22].Value?.ToString(),

                        // 🟢 Fechas
                        reportdate = DateTime.TryParse(row.Cells[23].Value?.ToString(), out DateTime reportVal) ? reportVal : (DateTime?)null,
                        date11 = DateTime.TryParse(row.Cells[24].Value?.ToString(), out DateTime date11Val) ? date11Val : (DateTime?)null,
                        date12 = DateTime.TryParse(row.Cells[25].Value?.ToString(), out DateTime date12Val) ? date12Val : (DateTime?)null,

                        // 🟢 Datos del agricultor
                        growerid = row.Cells[26].Value?.ToString(),
                        growername = row.Cells[27].Value?.ToString(),
                        fecha = dateTimePicker_fecha.Value,
                        // 🟢 Datos del archivo (personaliza según tus controles)
                        Hoja = hojaText,                   // Nombre de hoja Excel
                        NombreExcel = label_nombreExcel.Text,  // Nombre del archivo
                        Ruta = textRuta.Text,              // Ruta completa del archivo

                        // 🟢 Control y auditoría
                        Estado = "S", // Activo por defecto
                        FecCre = ce_usuario.FechaSistema(),
                        UseReg = ce_usuario.usecod,
                        Hostname = ce_usuario.HostName(),
                        FecEdit = ce_usuario.FechaSistema(),
                        UseEdit = ce_usuario.usecod,
                        UseElim = null
                    };

                    lista.Add(entidad);
                }


            }



            return lista;
        }

        private async void GuardarDatosSyncFn()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Mostrar el formulario de carga de manera no modal
            Msbox.frm_guardando frbm = new Msbox.frm_guardando();
            //frbm.StartPosition = FormStartPosition.CenterParent;
            frbm.Show(this); // Mostrar como formulario hijo
            frbm.label1.Text = "🤖 ANALIZANDO Y PROCESANDO..."; // Actualizar el texto del formulario de carga

            try
            {
                // Esperar 1 segundo antes de continuar
                await Task.Delay(600);
                // Cargar datos en segundo plano
                await Task.Run(() =>
                {
                    //GuardarTareoFinal();
                    GuardarReporteLiquidacionesBulkFn();
                });
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frbm.Close(); // Cerrar el formulario de carga
                              // Mostrar mensaje de éxito

            }
        }

        public object GuardarReporteLiquidacionesBulkFn()
        {
            try
            {
                // 1️⃣ Convertir el DataGridView a una lista de entidades ce_liquidaciones
                List<ce_liquidaciones> listaLiquidaciones = ConvertirDataGridViewAListaFn(dataGridView1);

                // 2️⃣ Convertir la lista a un DataTable compatible con el TVP de SQL
                DataTable dt = ConvertirListaADataTable(listaLiquidaciones);

                // 3️⃣ Llamar al método de la capa de datos
                var result = cd_comercial.UpsertLiquidacionesSave(dt);

                bool success = result.IdLiq != null;

                string mensaje = result.Mensaje;
                string titulo = success ? "Éxito" : "Error al Guardar";
                MessageBoxIcon icono = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;

                // Mostrar el MessageBox
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);


                // 5️⃣ Retornar respuesta estructurada (por si quieres usarla en código)
                return new
                {
                    Success = success,
                    Message = result.Mensaje,
                    IdLiq = result.IdLiq
                };
            }

            catch (Exception ex)
            {
                string mensajeError = "Error al realizar el UPSERT: " + ex.Message;
                string titulo = "Error al guardar";

                // Mostrar el MessageBox
                MessageBox.Show(mensajeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new
                {
                    Success = false,
                    Message = "Error al Guardar: " + ex.Message,
                    IdLiq = (int?)null
                };
            }
        }


        public List<ce_liquidaciones> ConvertirDataGridViewAListaFn(DataGridView dgv)
        {

            string hojaText = string.Empty;

            // Obtener el valor de la hojaText
            if (comboBox_Hojas.InvokeRequired)
            {
                comboBox_Hojas.Invoke(new MethodInvoker(() =>
                {
                    hojaText = comboBox_Hojas.Text;
                }));
            }
            else
            {
                hojaText = comboBox_Hojas.Text;
            }

            List<ce_liquidaciones> lista = new List<ce_liquidaciones>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    /*
                    ce_liquidaciones entidad = new ce_liquidaciones
                    {
                        idliq = 0, // SQL Server genera el ID automáticamente

                        // 🟢 Datos de embarque
                        ShipmentCode = hojaText, // Se asigna desde la variable externa

                        // 🟢 Datos del bloque
                        growerblockid = row.Cells[0].Value?.ToString(),
                        blockname = row.Cells[1].Value?.ToString(),

                        // 🟢 Información de transacción
                        trxtype = decimal.TryParse(row.Cells[2].Value?.ToString(), out decimal trxtypeVal) ? trxtypeVal : (decimal?)null,
                        chargeorderby = decimal.TryParse(row.Cells[3].Value?.ToString(), out decimal chargeorderbyVal) ? chargeorderbyVal : (decimal?)null,
                        chargeid = row.Cells[4].Value?.ToString(),
                        chargedescr = row.Cells[5].Value?.ToString(),
                        chargeratetype = decimal.TryParse(row.Cells[6].Value?.ToString(), out decimal chargeratetypeVal) ? chargeratetypeVal : (decimal?)null,
                        invcqnt = decimal.TryParse(row.Cells[7].Value?.ToString(), out decimal invcqntVal) ? invcqntVal : (decimal?)null,

                        // 🟢 Montos
                        saleamt = decimal.TryParse(row.Cells[8].Value?.ToString(), out decimal saleamtVal) ? saleamtVal : (decimal?)null,
                        chgqnt = decimal.TryParse(row.Cells[9].Value?.ToString(), out decimal chgqntVal) ? chgqntVal : (decimal?)null,
                        chgamt = decimal.TryParse(row.Cells[10].Value?.ToString(), out decimal chgamtVal) ? chgamtVal : (decimal?)null,

                        // 🟢 Descripción del producto
                        gwrproductdescr = row.Cells[11].Value?.ToString(),
                        cmtyinvc = row.Cells[12].Value?.ToString(),
                        vrtyinvc = row.Cells[13].Value?.ToString(),

                        // 🟢 Clasificación
                        styleorderby = decimal.TryParse(row.Cells[14].Value?.ToString(), out decimal styleorderbyVal) ? styleorderbyVal : (decimal?)null,
                        gradeinvc = row.Cells[15].Value?.ToString(),
                        gradeorderby = decimal.TryParse(row.Cells[16].Value?.ToString(), out decimal gradeorderbyVal) ? gradeorderbyVal : (decimal?)null,
                        sizeorderby = decimal.TryParse(row.Cells[17].Value?.ToString(), out decimal sizeorderbyVal) ? sizeorderbyVal : (decimal?)null,

                        // 🟢 Unidad y factores de cargo
                        uom = row.Cells[18].Value?.ToString(),
                        fcchargeidx = row.Cells[19].Value?.ToString(),
                        invcicqnt = decimal.TryParse(row.Cells[20].Value?.ToString(), out decimal invcicqntVal) ? invcicqntVal : (decimal?)null,

                        // 🟢 Información de compañía
                        astitle = row.Cells[21].Value?.ToString(),
                        ascompanyname = row.Cells[22].Value?.ToString(),

                        // 🟢 Fechas
                        reportdate = DateTime.TryParse(row.Cells[23].Value?.ToString(), out DateTime reportVal) ? reportVal : (DateTime?)null,
                        date11 = DateTime.TryParse(row.Cells[24].Value?.ToString(), out DateTime date11Val) ? date11Val : (DateTime?)null,
                        date12 = DateTime.TryParse(row.Cells[25].Value?.ToString(), out DateTime date12Val) ? date12Val : (DateTime?)null,

                        // 🟢 Datos del agricultor
                        growerid = row.Cells[26].Value?.ToString(),
                        growername = row.Cells[27].Value?.ToString(),
                        fecha = dateTimePicker_fecha.Value,
                        // 🟢 Datos del archivo (personaliza según tus controles)
                        Hoja = hojaText,                   // Nombre de hoja Excel
                        NombreExcel = label_nombreExcel.Text,  // Nombre del archivo
                        Ruta = textRuta.Text,              // Ruta completa del archivo

                        // 🟢 Control y auditoría
                        Estado = "S", // Activo por defecto
                        FecCre = ce_usuario.FechaSistema(),
                        UseReg = ce_usuario.usecod,
                        Hostname = ce_usuario.HostName(),
                        FecEdit = ce_usuario.FechaSistema(),
                        UseEdit = ce_usuario.usecod,
                        UseElim = null
                    };
                    */

                    ce_liquidaciones entidad = new ce_liquidaciones
                    {
                        idliq = 0,

                        ShipmentCode = hojaText,

                        // 🟢 Datos del bloque
                        growerblockid = row.Cells[0].Value?.ToString(),
                        blockname = row.Cells[1].Value?.ToString(),

                        // 🟢 Información de transacción
                        trxtype = decimal.TryParse(row.Cells[2].Value?.ToString(), out decimal trxtypeVal) ? trxtypeVal : (decimal?)null,
                        chargeorderby = null, // ❌ ya no viene
                        chargeid = row.Cells[3].Value?.ToString(),
                        chargedescr = row.Cells[4].Value?.ToString(),
                        chargeratetype = decimal.TryParse(row.Cells[5].Value?.ToString(), out decimal chargeratetypeVal) ? chargeratetypeVal : (decimal?)null,
                        invcqnt = null, // ❌ ya no viene

                        // 🟢 Montos
                        saleamt = decimal.TryParse(row.Cells[10].Value?.ToString(), out decimal saleamtVal) ? saleamtVal : (decimal?)null,
                        chgqnt = decimal.TryParse(row.Cells[15].Value?.ToString(), out decimal chgqntVal) ? chgqntVal : (decimal?)null,
                        chgamt = decimal.TryParse(row.Cells[17].Value?.ToString(), out decimal chgamtVal) ? chgamtVal : (decimal?)null,

                        // 🟢 Descripción del producto
                        gwrproductdescr = row.Cells[18].Value?.ToString(),
                        cmtyinvc = null,
                        vrtyinvc = null,

                        // 🟢 Clasificación
                        styleorderby = null,
                        gradeinvc = null,
                        gradeorderby = null,
                        sizeorderby = null,

                        // 🟢 Unidad y factores de cargo
                        uom = null,
                        fcchargeidx = null,
                        invcicqnt = decimal.TryParse(row.Cells[19].Value?.ToString(), out decimal invcicqntVal) ? invcicqntVal : (decimal?)null,

                        // 🟢 Información de compañía
                        astitle = row.Cells[20].Value?.ToString(),
                        ascompanyname = row.Cells[21].Value?.ToString(),

                        // 🟢 Fechas
                        reportdate = DateTime.TryParse(row.Cells[22].Value?.ToString(), out DateTime reportVal) ? reportVal : (DateTime?)null,
                        date11 = DateTime.TryParse(row.Cells[23].Value?.ToString(), out DateTime date11Val) ? date11Val : (DateTime?)null,
                        date12 = DateTime.TryParse(row.Cells[24].Value?.ToString(), out DateTime date12Val) ? date12Val : (DateTime?)null,

                        // 🟢 Datos del agricultor
                        growerid = row.Cells[25].Value?.ToString(),
                        growername = row.Cells[26].Value?.ToString(),

                        fecha = dateTimePicker_fecha.Value,

                        Hoja = hojaText,
                        NombreExcel = label_nombreExcel.Text,
                        Ruta = textRuta.Text,

                        Estado = "S",
                        FecCre = ce_usuario.FechaSistema(),
                        UseReg = ce_usuario.usecod,
                        Hostname = ce_usuario.HostName(),
                        FecEdit = ce_usuario.FechaSistema(),
                        UseEdit = ce_usuario.usecod,
                        UseElim = null
                    };

                    lista.Add(entidad);
                }



            }



            return lista;
        }


        public DataTable ConvertirListaADataTable<T>(List<T> lista)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            // Crear columnas
            foreach (var propiedad in propiedades)
            {
                Type tipo = propiedad.PropertyType;

                if (tipo.IsGenericType && tipo.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    tipo = Nullable.GetUnderlyingType(tipo);
                }

                dt.Columns.Add(propiedad.Name, tipo);
            }

            // Llenar filas
            foreach (var entidad in lista)
            {
                DataRow fila = dt.NewRow();

                foreach (var propiedad in propiedades)
                {
                    var valor = propiedad.GetValue(entidad);
                    fila[propiedad.Name] = valor ?? DBNull.Value;
                }

                dt.Rows.Add(fila);
            }

            return dt;
        }

        private void toolStripButton_credenciales_limpiar_Click(object sender, EventArgs e)
        {
            textRuta.Text = "";
            comboBox_Hojas.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            ColumnasDtgv1();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();

            oOpenFileDialog.Filter = "Archivos PDF|*.pdf";
            oOpenFileDialog.Multiselect = false;

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                textRuta.Text = oOpenFileDialog.FileName;
                label_nombreExcel.Text = Path.GetFileName(oOpenFileDialog.FileName);
            }
        }


        private void toolStripButton_eliminar_Click(object sender, EventArgs e)
        {
            frm_EliminarLiquidacion frbm = new frm_EliminarLiquidacion();
            AddOwnedForm(frbm);
            frbm.ShowDialog();
        }
    }


}

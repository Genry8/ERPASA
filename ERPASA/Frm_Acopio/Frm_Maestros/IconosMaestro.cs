using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ERPASA.Frm_Acopio.Frm_Maestros
{
    /// <summary>
    /// Pone los iconos de la barra de acciones en los formularios de maestros.
    ///
    /// Esos formularios no tienen .resx propio, así que los iconos se toman de
    /// los de pantallas que ya los traen. Hacerlo así evita arrastrar 24 copias
    /// del mismo archivo de recursos (unos 190 KB cada una) dentro del
    /// ejecutable.
    /// </summary>
    internal static class IconosMaestro
    {
        private static readonly ComponentResourceManager Barra =
            new ComponentResourceManager(typeof(Frm_RegistrarPesoPresentacion));

        private static readonly ComponentResourceManager Lapiz =
            new ComponentResourceManager(typeof(Frm_Sistema.Frm_AgregarActivo));

        public static void Aplicar(ToolStrip barra)
        {
            Poner(barra, "toolStripButton_buscar", Barra, "toolStripButton_buscar.Image");
            Poner(barra, "toolStripButton_excel", Barra, "toolStripButton_excel.Image");
            Poner(barra, "toolStripButton_nuevo", Barra, "toolStripButton_nuevo.Image");
            Poner(barra, "toolStripButton_editar", Lapiz, "toolStripButton_editar.Image");
            Poner(barra, "toolStripButton_eliminar", Barra, "toolStripButton_eliminar.Image");
            Poner(barra, "toolStripButton_imprimir", Barra, "toolStripButton_imprimir.Image");
        }

        private static void Poner(ToolStrip barra, string nombre,
            ComponentResourceManager recursos, string clave)
        {
            ToolStripItem[] encontrados = barra.Items.Find(nombre, false);
            if (encontrados.Length == 0) return;

            try
            {
                // Sin icono el botón sigue funcionando, solo con su texto.
                encontrados[0].Image = recursos.GetObject(clave) as Image;
            }
            catch
            {
            }
        }
    }
}

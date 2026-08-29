using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUtilidad
{
    public static class HoraTextBoxHelper
    {
        public static void Configurar(TextBox textBox)
        {
            textBox.MaxLength = 5;

            textBox.KeyPress += TextBox_KeyPress;
            textBox.TextChanged += TextBox_TextChanged;
        }

        private static void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control: Backspace, Delete, etc.
            if (char.IsControl(e.KeyChar))
                return;

            // Solo permitir números
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private static void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            int posicion = textBox.SelectionStart;

            // Quitar los dos puntos para trabajar únicamente con números
            string numeros = textBox.Text.Replace(":", "");

            // Limitar a 4 dígitos
            if (numeros.Length > 4)
                numeros = numeros.Substring(0, 4);

            // Validar horas y minutos
            if (numeros.Length >= 2)
            {
                int hora;

                if (int.TryParse(numeros.Substring(0, 2), out hora))
                {
                    if (hora > 23)
                    {
                        numeros = "23" + numeros.Substring(2);
                    }
                }
            }

            if (numeros.Length >= 4)
            {
                int minuto;

                if (int.TryParse(numeros.Substring(2, 2), out minuto))
                {
                    if (minuto > 59)
                    {
                        numeros = numeros.Substring(0, 2) + "59";
                    }
                }
            }

            // Formatear HH:mm
            string resultado = numeros;

            if (numeros.Length > 2)
            {
                resultado = numeros.Insert(2, ":");
            }

            // Evitar ejecutar nuevamente el evento
            if (textBox.Text != resultado)
            {
                textBox.Text = resultado;

                // Mantener el cursor al final
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }
}

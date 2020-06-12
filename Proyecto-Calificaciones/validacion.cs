using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Calificaciones
{
    class validacion
    {
        public static void SoloNumeros(KeyPressEventArgs pe)
        {

            if (char.IsDigit(pe.KeyChar))
            {

                pe.Handled = false;
            }
            else if (char.IsControl(pe.KeyChar))
            {

                pe.Handled = false;
            }
            else
            {
                pe.Handled = true;
            }
        }


        public static void SoloLetras(KeyPressEventArgs pe)
        {

            if (char.IsLetter(pe.KeyChar))
            {

                pe.Handled = false;
            }
            else if (Char.IsControl(pe.KeyChar))
            {

                pe.Handled = false;
            }
            else if (char.IsSeparator(pe.KeyChar))
            {

                pe.Handled = false;
            }
            else
            {

                pe.Handled = true;
            }
        }
    }
}

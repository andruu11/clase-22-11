using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApplication1.metodos
{
    public class validarcamposvacios
    {
        public static void ValidarCamposVacios(Control control, ErrorProvider ErrorProvider)
        {
            
            foreach (Control Item in control.Controls)
            {
                if (Item is TextBox) {

                    TextBox obj = (TextBox)Item;
                    if (string.IsNullOrEmpty(obj.Text.Trim())) {
                        ErrorProvider.SetError(obj, "No puede estar vacio");
                    }
                    else
                    {
                        ErrorProvider.SetError(obj, "No puede estar vacio");
                    }
                }
               
            }
        }
    }
}

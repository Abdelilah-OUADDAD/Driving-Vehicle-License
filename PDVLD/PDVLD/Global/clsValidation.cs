using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Global
{
    public class clsValidation
    {
        public static void ValidationTextBox(TextBox textBox, string Message, ErrorProvider errorProvider, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox, Message);
            }
            else
            {
                errorProvider.SetError(textBox, null);
            }
        }

        public static bool ValidationEmail(string emailAddress)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@gmail+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }
    }
}

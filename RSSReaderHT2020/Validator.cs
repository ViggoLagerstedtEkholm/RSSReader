using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSReader
{
    public class Validator
    {
        public bool StringIsEmpty(string input)
        {
            bool result = false;

            if (input.Equals(""))
            {
                result = true;
            }

            return result;
        }
        public bool URLIsValid(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }

        public bool ListBoxHasSelected(ListBox listBox)
        {
            bool result = true;

            if(listBox.SelectedIndex == -1)
            {
                result = false;
            }

            return result;
        }
        public bool DataGridViewHasSelected(DataGridView table)
        {
            bool result = true;

            if (!(table.SelectedRows.Count > 0))
            {
                result = false;
            }

            return result;
        }
        public bool ComboBoxHasSelected(ComboBox comboBox)
        {
            bool result = true;

            if (!(comboBox.SelectedIndex > -1))
            {
                result = false;
            }

            return result;
        }
        public bool TextBoxisNullorEmpty(TextBox textBox)
        {
            bool result = true;

            if (!String.IsNullOrEmpty(textBox.Text))
            {
                result = false;
            }

            return result;
        }
    }
}

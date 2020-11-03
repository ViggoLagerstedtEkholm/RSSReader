using DAL.Exceptions;
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
        public void StringIsEmpty(string input)
        {
            if (input.Equals(""))
            {
                throw new InvalidStringException();
            }
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
            catch (InvalidURLException)
            {
                throw new InvalidURLException();
            }
        }

        public void ListBoxHasSelected(ListBox listBox)
        {
            if(listBox.SelectedIndex == -1)
            {
                throw new InvalidListBoxException();
            }
        }
        public void DataGridViewHasSelected(DataGridView table)
        {
            if (!(table.SelectedRows.Count > 0))
            {
                throw new InvalidDataGridException();
            }
        }
        public void ComboBoxHasSelected(ComboBox comboBox)
        {
            if (!(comboBox.SelectedIndex > -1))
            {
                throw new InvalidComboBoxException();
            }
        }
        public void TextBoxisNullorEmpty(TextBox textBox)
        {
            if (String.IsNullOrEmpty(textBox.Text))
            {
                throw new InvalidTextException();
            }
        }
    }
}

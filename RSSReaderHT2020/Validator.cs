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
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch (UriFormatException)
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

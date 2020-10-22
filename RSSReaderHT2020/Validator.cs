using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSReader
{
    public class Validator
    {
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

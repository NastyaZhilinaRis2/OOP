using MyCollectionLibrary;

namespace ООП16
{
    public static class FormManager
    {
        public static async Task DisplayDataFromFileTxtAsync (TextBox textBox, FileManager fileManager, string nameFile)
        {
            List<string> strings = new List<string>();
            strings = await fileManager.GetFileTxtAsync(nameFile);

            textBox.Text = "";
            foreach (string str in strings)
            {
                DisplayDataString(textBox, str);
            }
        }
        public static void DisplayDataCollection<TKey, TValue> (TextBox textBox, MyCollection<TKey, TValue> collection)
        {
            textBox.Text = "";
            foreach (var good in collection)
            {
                DisplayDataString(textBox, good.ToString());
            }
        }
        public static void DisplayDataString(TextBox textBox, string str)
        {
            textBox.Text += str + "\r\n";
        }
        public static bool ChekFieldsEmpty(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox textBox)
                    if (textBox.Text == "")
                        return true;
                if (c is ComboBox comboBox)
                    if (comboBox.Text == "")
                        return true;
            }
            return false;
        }
        public static void CleanFields(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TableLayoutPanel tableLayoutPanel)
                {
                    CleanFieldsTLP(c);
                }
                if (c is TextBox textBox)
                    textBox.Text = "";
                if (c is ComboBox comboBox)
                    comboBox.Text = "";
            }
        }
        public static void CleanFieldsTLP(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox textBox)
                    textBox.Text = "";
                if (c is ComboBox comboBox)
                    comboBox.Text = "";
            }
        }
        public static string StringFromDialogBox(string title, string text, string defaultValue = "")
        {
            return Microsoft.VisualBasic.Interaction.InputBox(text, title, defaultValue);
        }
    }
}

namespace ООП16
{
    public static class InputValidator
    {
        public static bool InputInt(string input)
        {
            int number;
            if (int.TryParse(input, out number))
            {
                return true;
            }
            else MessageBox.Show("Некорректный ввод. Введите число!");
            return false;
        }
        public static bool InputInt(string input, int left, int right)
        {
            if (InputInt(input))
            {
                int number = int.Parse(input);
                if (number >= left && number <= right)
                    return true;
                else MessageBox.Show($"Некорректный ввод. Введите число из интервала от {left} до {right}!");
            }
            return false;
        }
        public static bool InputNumbers(string input, int[] validNumbers)
        {
            if (!InputInt(input)) return false;

            int number = int.Parse(input);
            if (validNumbers.Contains(number))
                return true;
            else
            {
                MessageBox.Show($"Некорректный ввод. Могут быть введены только:{string.Join(", ", validNumbers)}!");
                return false;
            }
        }
    }
    public static class InputValidatorInForm
    {
        public static void CorrectInputToControl(Control control, int[] validNumbers = null)
        {
            if (control.Text == "")
                return;
            if (validNumbers != null)
                if (!InputValidator.InputNumbers(control.Text, validNumbers))
                    control.Text = "";
                else if (!InputValidator.InputInt(control.Text))
                    control.Text = "";
        }
    }
}

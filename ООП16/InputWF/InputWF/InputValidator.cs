namespace InputWF
{
    public static class InputValidator
    {
        public static bool InputInt(string input)
        {
            int number;
            bool isCorrect = false;
            if (int.TryParse(input, out number))
                isCorrect = true;
            else MessageBox.Show("Некорректный ввод. Введите число!");
            return isCorrect;
        }
        public static bool InputNumbers(string input, int[] validNumbers)
        {
            if (int.TryParse(input, out int number))
            {
                return validNumbers.Contains(number);
            }
            return false;
        }
    }
}


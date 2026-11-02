using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;

namespace Logic
{
    public class Calc
    {
        public double Display { get; private set; } = 0;
        public enum operType
        {
            _null = '\0',
            sum = '+',
            subtraction = '-',
            multiplication = '*',
            division = '/',
            zero
        }

        public double a { get; private set; } = 0;
        public double b { get; private set; } = 0;
        public operType OperType { get; private set; } = operType._null;
        private bool isCalc = false;
        private bool repeatCalc = false; 
        private bool repeatOper = false;
        private char prevChar = '\0';

        public void InputValue(char value)
        {
            if (repeatCalc)
            {
                Clear();
                Display = double.Parse(value.ToString());
            }
            else if (isCalc || Display == 0)
            {
                isCalc = false;
                Display = double.Parse(value.ToString());
            }
            else
            {
                Display = double.Parse($"{Display}{value}", CultureInfo.InvariantCulture);
            }
            prevChar = Convert.ToChar(value);
        }

        public void InputOperType(char value)
        {
            if (OperType == operType.zero)
                return;
            if (value != '=')
            {
                isCalc = false;

                if (prevChar == value)
                    return;
                else if (value == (Char)OperType && (a != 0 || b != 0))
                {
                    Calculate();
                } else if (Display != 0 && a != 0 && OperType != operType._null)
                {
                    Calculate();
                }

                OperType = (operType)value;

                a = Display;
                b = 0;
                prevChar = value;
                Display = isCalc ? Display : 0;
                repeatOper = 
                    repeatCalc = false;
            }
            else
            {
                Calculate();
            }
        }

        private void Calculate()
        {
            if (repeatCalc || repeatOper)
                a = Display;
            else
                b = Display;
            //Display = 0;
            switch (OperType)
            {
                case operType.sum:
                    Display = a + b;
                    break;

                case operType.subtraction:
                    Display = a - b;
                    break;

                case operType.multiplication:
                    Display = a * b;
                    break;

                case operType.division:
                    if (b != 0)
                        Display = a / b;
                    else OperType = operType.zero;
                    break;
            }
            repeatCalc =
                isCalc = true;
        }
        public void Clear()
        {
            prevChar = '\0';
            repeatCalc = 
                isCalc = false;
            Display = 
                a = 
                b = 0;
            OperType = operType._null;
        }
    }
}

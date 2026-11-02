using Logic;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private Calc _calc = new Calc();
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnNum_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var buttonText = Convert.ToChar(button.Text);

            _calc.InputValue(buttonText);

            updateDisplay();
        }

        private void btn_CalcClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var buttonText = Convert.ToChar(button.Text);

            _calc.InputOperType(buttonText);

            updateDisplay();
        }

        private void btn_ClearClicked(object sender, EventArgs e)
        {
            _calc.Clear();
            updateDisplay();
        }
        private void updateDisplay()
        {
            if (_calc.OperType == Calc.operType.zero)
            {
                Hist.Text = "";
                Display.Text = "На ноль делить нельзя";
            }
            else if (_calc.OperType != Calc.operType._null)
            {
                Hist.Text = $"{_calc.a} {(Char)_calc.OperType} {(_calc.b == 0 ? "" : $"{_calc.b} =")}";
                Display.Text = $"{_calc.Display}";
            }
            else
            {
                Hist.Text = "";
                Display.Text = _calc.Display.ToString();
            }
        }
    }
}

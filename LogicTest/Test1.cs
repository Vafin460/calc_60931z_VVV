using Logic;
using static Logic.Calc;

namespace LogicTest
{
    [TestClass]
    public sealed class Test1
    {
        private Calc _calc = new Calc();
        [TestMethod]
        public void StartDisplayIsZero()
        {
            Assert.AreEqual(0, _calc.Display);
        }
        [TestMethod]
        public void Calc6sum3()
        {
            _calc.InputValue('6');
            _calc.InputOperType('+');
            _calc.InputValue('3');
            _calc.InputOperType('=');
            Assert.AreEqual(9, _calc.Display);
        }
        [TestMethod]
        public void Calc3sum4_3times()
        {
            _calc.InputValue('3');
            _calc.InputOperType('+');
            _calc.InputValue('4');
            _calc.InputOperType('=');
            _calc.InputOperType('=');
            _calc.InputOperType('=');
            Assert.AreEqual(15, _calc.Display);
        }
        [TestMethod]
        public void Calc1Sum5Multiply2Division4()
        {
            _calc.InputValue('1');
            _calc.InputOperType('+');
            _calc.InputValue('5');
            _calc.InputOperType('*');
            _calc.InputValue('2');
            _calc.InputOperType('/');
            _calc.InputValue('4');
            _calc.InputOperType('=');
            Assert.AreEqual(3, _calc.Display);
        }
        [TestMethod]
        public void DivisionZero()
        {
            _calc.InputValue('9');
            _calc.InputOperType('/');
            _calc.InputValue('0');
            _calc.InputOperType('=');
            Assert.AreEqual(Calc.operType.zero, _calc.OperType);
        }
        [TestMethod]
        public void CalcWithoutEqual()
        {
            _calc.InputValue('2');
            _calc.InputOperType('*');
            _calc.InputValue('2');
            _calc.InputOperType('*');
            _calc.InputValue('2');
            _calc.InputOperType('*');
            Assert.AreEqual(8, _calc.Display);
        }
        [TestMethod]
        public void Calc1Sum1AndInput5()
        {
            _calc.InputValue('1');
            _calc.InputOperType('+');
            _calc.InputValue('1');
            _calc.InputOperType('=');
            _calc.InputValue('5');
            Assert.AreEqual(5, _calc.Display);
            Assert.AreEqual(0, _calc.a);
            Assert.AreEqual(0, _calc.b);
        }
        [TestMethod]
        public void Calc2sum2AndClear()
        {
            _calc.InputValue('2');
            _calc.InputOperType('+');
            _calc.InputValue('2');
            _calc.InputOperType('=');
            Assert.AreEqual(4, _calc.Display);
            _calc.Clear();
            Assert.AreEqual(0, _calc.Display);
            Assert.AreEqual(0, _calc.a);
            Assert.AreEqual(0, _calc.b);
            Assert.AreEqual(Calc.operType._null, _calc.OperType);

        }
    }
}
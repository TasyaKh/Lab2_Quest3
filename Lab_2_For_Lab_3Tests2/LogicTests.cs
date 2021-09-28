using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab_2_For_Lab_3.Tests
{
    [TestClass()]
    public class LogicTests
    {
        private const int expressionsSave = 5;

        [TestMethod()]
        public void WitoutLeftNumberTest() //Без левой цифры
        {
            Logic logic = new Logic();
            string txt = "+9";            //Текст, который надо проверить

            logic.startChecking(txt);      //Подать на проверку предложение

            Assert.AreEqual(0, logic.getSum());
        }

        [TestMethod()]
        public void WitoutRightNumberTest()//Без правой цифры 
        {
            Logic logic = new Logic();
            string txt = "6+";            //Текст, который надо проверить

            logic.startChecking(txt);      //Подать на проверку каждый символ в предложении

            Assert.AreEqual(0, logic.getSum());
        }

        [TestMethod()]
        public void WithRightAndLeftNumberTest() //Обычное выражение
        {
            Logic logic = new Logic();
            string txt = "6+6";             //Текст, который надо проверить

            logic.startChecking(txt);       //Подать на проверку каждый символ в предложении

            Assert.AreEqual(12, logic.getSum());
        }

        [TestMethod()]
        public void WithLeftAndRightNumberAndMoreTest() //С выражением с несколькими цифрами
        {
            Logic logic = new Logic();
            string txt = "6+6-8";            //Текст, который надо проверить

            logic.startChecking(txt);         //Подать на проверку каждый символ в предложении

            Assert.AreEqual(4, logic.getSum());
        }

        [TestMethod()]
        public void WithTwoExpressionTest()        //С 2мя выражениями
        {
            Logic logic = new Logic();

            string txt = "6+0 kk 8+8";            //Текст, который надо проверить

            logic.startChecking(txt);             //Подать на проверку каждый символ в предложении

            Assert.AreEqual(0, logic.getSum());
        }

        [TestMethod()]
        public void WithoutExpressionTest()   //Без выражения  
        {
            Logic logic = new Logic();

            string txt = "httb ";            //Текст, который надо проверить

            logic.startChecking(txt);         //Подать на проверку каждый символ в предложении

            Assert.AreEqual(0, logic.getSum());
        }

        [TestMethod()]
        public void WithExpressionTest2()       //С выражением тест1
        {
            Logic logic = new Logic();

            string txt = "3--8+70 ";            //Текст, который надо проверить

            logic.startChecking(txt);            //Подать на проверку каждый символ в предложении

            Assert.AreEqual(0, logic.getSum());
        }

        [TestMethod()]
        public void WithExpressionTest3()      //С выражением тест3
        {
            Logic logic = new Logic();

            string txt = "+3-8-3 ";            //Текст, который надо проверить

            logic.startChecking(txt);           //Подать на проверку каждый символ в предложении

            Assert.AreEqual(0, logic.getSum());
        }

        [TestMethod()]
        public void WithManyExpressionsTest()         //С большим количеством выражений
        {
            Logic logic = new Logic();

            string txt = "1+1-9+0-2+i-1";            //Текст, который надо проверить

            logic.startChecking(txt);                 //Подать на проверку каждый символ в предложении

            Assert.AreEqual(0, logic.getSum());
        }
    }
}
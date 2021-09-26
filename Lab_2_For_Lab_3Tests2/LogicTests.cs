using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_2_For_Lab_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_For_Lab_3.Tests
{
    [TestClass()]
    public class LogicTests
    {
        private const int expressionsSave = 5;
        private void checkMethod(Logic logic,string txt)  //Подает на проверку каждый символ в предложении классу Logic
        {
            for (int i = 0; i < txt.Length; i++)
                logic.checkWord(txt, ref i);
        }

        [TestMethod()]
        public void WitoutLeftNumberTest() //Без левой цифры
        {
            Logic logic = new Logic(expressionsSave);

            string txt = "+9";            //Текст, который надо проверить
            string answer = "";           //На выходе не будет элементов

            checkMethod(logic, txt);      //Подать на проверку каждый символ в предложении

            Assert.AreEqual(logic.getOutputArr(), answer);
        }

        [TestMethod()]
        public void WitoutRightNumberTest()//Без правой цифры 
        {
            Logic logic = new Logic(expressionsSave);

            string txt = "6+";            //Текст, который надо проверить
            string answer = "";           //На выходе не будет элементов

            checkMethod(logic, txt);      //Подать на проверку каждый символ в предложении

            Assert.AreEqual(logic.getOutputArr(), answer);
        }

        [TestMethod()]
        public void WithRightAndLeftNumberTest() //Обычное выражение
        {
            Logic logic = new Logic(expressionsSave);

            string txt = "6+6";             //Текст, который надо проверить
            string answer = "12";           //На выходе не будет элементов

            checkMethod(logic, txt);        //Подать на проверку каждый символ в предложении

            Assert.AreEqual(logic.getOutputArr(), answer);
        }

        [TestMethod()]
        public void WithLeftAndRightNumberAndMoreTest() //С выражением с несколькими цифрами
        {
            Logic logic = new Logic(expressionsSave);

            string txt = "6+6-8";            //Текст, который надо проверить
            string answer = "4";             //На выходе не будет элементов

            checkMethod(logic, txt);         //Подать на проверку каждый символ в предложении

            Assert.AreEqual(logic.getOutputArr(), answer);
        }

        [TestMethod()]
        public void WithTwoExpressionTest()        //С 2мя выражениями
        {
            Logic logic = new Logic(expressionsSave);

            string txt = "6+0 kk 8+8";            //Текст, который надо проверить
            string answer = "6, 16";              //На выходе не будет элементов

            checkMethod(logic, txt);              //Подать на проверку каждый символ в предложении

            Assert.AreEqual(logic.getOutputArr(), answer);
        }

        [TestMethod()]
        public void WithoutExpressionTest()   //Без выражения  
        {
            Logic logic = new Logic(expressionsSave);

            string txt = "httb ";            //Текст, который надо проверить
            string answer = "";              //На выходе не будет элементов

            checkMethod(logic, txt);         //Подать на проверку каждый символ в предложении

            Assert.AreEqual(logic.getOutputArr(), answer);
        }

        [TestMethod()]
        public void WithExpressionTest2()       //С выражением тест1
        {
            Logic logic = new Logic(expressionsSave);

            string txt = "3--8+70 ";            //Текст, который надо проверить
            string answer = "78";               //На выходе не будет элементов

            checkMethod(logic, txt);            //Подать на проверку каждый символ в предложении

            Assert.AreEqual(logic.getOutputArr(), answer);
        }

        [TestMethod()]
        public void WithExpressionTest3()      //С выражением тест3
        {
            Logic logic = new Logic(expressionsSave);

            string txt = "+3-8-3 ";            //Текст, который надо проверить
            string answer = "-8";              //На выходе не будет элементов

            checkMethod(logic, txt);           //Подать на проверку каждый символ в предложении

            Assert.AreEqual(logic.getOutputArr(), answer);
        }

        [TestMethod()]
        public void WithManyExpressionsTest()                                                //С большим количеством выражений
        {
            Logic logic = new Logic(expressionsSave);

            string txt = "1+1 hh 2+2 ju +3-4 9+o 0+pl - 3+3 5+70 6 + 9 9+9 5+5 ";            //Текст, который надо проверить
            string answer = "2, 4, -1, 6, ...10";                                            //На выходе не будет элементов

            checkMethod(logic, txt);                                                         //Подать на проверку каждый символ в предложении

            Assert.AreEqual(logic.getOutputArr(), answer);
        }
    }
}
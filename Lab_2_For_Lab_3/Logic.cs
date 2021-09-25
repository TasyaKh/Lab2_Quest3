using System;

namespace Lab_2_For_Lab_3
{
    class Logic
    {
        private int sum;      //Хранит сумму элементов
        private int?[] keepAllExpress; //
        private int positKeeper; //

        private int leftNum;  //Хранит левый номер
        private int rightNum; //Хранит правый номер
        private bool leftExist; //Сужествует ли левый номер
        private bool rightExist; //Сужествует ли левый номер
        private char saveSign; //Определен ли знак

        public Logic()
        {
            sum = 0;
            keepAllExpress = new int?[5];
            positKeeper = 0;

            leftNum = 0;
            rightNum = 0;
            leftExist = false;
            rightExist = true;
            saveSign = '?';
        }
        private int summa(char sign, int leftNum, int rightNum) //Найти сумму левый+-правый элементы
        {
            int result = 0;

            switch (sign)
            {
                case '+':
                    result = leftNum + rightNum;
                    break;
                case '-':
                    result = leftNum - rightNum;
                    break;
            }
            return result;
        }

        private int getNum(in String express, ref int posit)//Собрать номер, если он состоит больше, чем из 2х символов(например 234)
        {
            int number = 0;

            for (int i = posit; i < express.Length; i++, posit++)
            {
                if (Char.IsDigit(express[i])) //Определить является ли символ номером
                    number = number * 10 + Convert.ToInt32(express[i].ToString()); //Если да, то сохранить цифру
                else //Если не номер,то
                {
                    posit--; //Вычитаем шаг проверки на одну позицию, чтобы проверить в последующем не является ли этот шаг пробелом или знаком +-
                    break;   //Завершаем сбор цифры 
                }

            }
            return number;
        }

        private bool isSign(char express)//является ли express знаком +-
        {
            if (express.Equals('+') || express.Equals('-'))
            {
                return true;
            }
            return false;
        }

        private void rewriteLeft()//Обнулить выражение: левое, правое значения и знак +- и найти сумму
        {
            // Console.WriteLine("here");

            leftNum = sum; //Теперь левое значение равно выражению справа
            saveSign = '?';
            rightNum = 0;
            //rightExist = false;

        }
        private void resetAll()
        {
            leftNum = rightNum = 0;
            leftExist = rightExist = false;
            saveSign = '?';
        }

        public void checkWord(String express, ref int i) //Проверить слово на наличие выражения(выражение, позиция с которой ищем)
        {//Тип string нужен, чтобы учесть номера вида 20, 300 и т.д, т.е те, которые содержать более одной цифры
            if (Char.IsDigit(express[i]))               //Если цифра найдена, то
            {
                if (leftExist && !saveSign.Equals('?'))  //Если левое значение существует и найден знак +-, то находим правую цифру
                {
                    rightExist = true;

                    rightNum = getNum(express, ref i);

                    sum = summa(saveSign, leftNum, rightNum);//Получаем сумму найденного выражения
                    rewriteLeft();                                 // обнуляем правую цифру и знак
                    keepAllExpress[positKeeper] = sum;
                }
                else if (!leftExist)                 //Если левой цифры нет, то находим левую
                {
                    leftNum = getNum(express, ref i);
                    leftExist = true;
                    //Console.WriteLine(" leftNum: " + leftNum);
                }
            }
            else if (isSign(express[i]))//Если знак+-,то
            {
                saveSign = express[i];
            }
            else         //Если знак не+- ,не цифра,то обнуляем собранные значения
            {
                if (rightExist && positKeeper<keepAllExpress.Length - 1) positKeeper++;//Если правое значение существует, это говорит о том,
                resetAll();                                     // что знак и левое тоже существую, а значит сумма была произведена
            }
        }

        public int?[] getSumAll()//Получить сумму
        {
            return keepAllExpress;
        }
    }
}

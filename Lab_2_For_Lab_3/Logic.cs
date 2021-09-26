using System;

namespace Lab_2_For_Lab_3
{
    public class Logic
    {
        private int? sum;              //Хранит сумму элементов
        private int?[] keepAllExpress; //Содержит суммы нескольких найденных выражений
        private int countNumExpressions;       //Содержит текущую позицию массива, который содежит суммы

        private int leftNum;           //Хранит левый номер
        private int rightNum;          //Хранит правый номер

        private bool leftExist;        //Сужествует ли левый номер
        private char saveSign;         //Определен ли знак
        private int lengthKeepExpress;

        public Logic(int expressionsSave) //(Количество сохраняемых найденых выражений)
        {
            this.lengthKeepExpress = expressionsSave;

            sum = null;
            keepAllExpress = new int?[expressionsSave];
            countNumExpressions = 0;

            leftNum = 0;
            rightNum = 0;
            leftExist = false;
            saveSign = '?';
        }
        private int? summa(char sign, int leftNum, int rightNum) //Найти сумму левый+-правый элементы
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
                if (Char.IsDigit(express[i]))             //Определить является ли символ номером
                    number = number * 10 + Convert.ToInt32(express[i].ToString()); //Если да, то сохранить цифру
                else                                     //Если не номер,то
                {
                    break;                                //Завершаем сбор цифры 
                }

            }
            posit--;//Вычитаем шаг проверки на одну позицию, чтобы проверить в последующем не является ли этот шаг пробелом или знаком +-

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

        private void rewriteLeft()      //Обнулить выражение: левое, правое значения и знак +- и найти сумму
        {
            leftNum = (int)sum;              //Теперь левое значение равно выражению справа
            saveSign = '?';
            rightNum = 0;

        }
        private void resetAll()
        {
            leftNum = rightNum = 0;
            leftExist = false;
            saveSign = '?';
        }

        public void checkWord(String express, ref int i)           //Проверить слово на наличие выражения(выражение, позиция с которой ищем)
        {//Тип string нужен, чтобы учесть номера вида 20, 300 и т.д, т.е те, которые содержать более одной цифры
            if (Char.IsDigit(express[i]))                          //Если цифра найдена, то
            {
                if (leftExist && !saveSign.Equals('?'))            //Если левое значение существует и найден знак +-, то находим правую цифру
                {
                    rightNum = getNum(express, ref i);             //Собрать правую цифру

                    sum = summa(saveSign, leftNum, rightNum);      //Получаем сумму найденного выражения
                    rewriteLeft();                                 //Обнуляем правую цифру и знак

                    if (countNumExpressions < keepAllExpress.Length)      //Если количество найденных выражений < размера этого массива, то
                        keepAllExpress[countNumExpressions] = sum;        //сохраняем текущую найденную сумму выражения
                    else keepAllExpress[keepAllExpress.Length - 1] = sum; //Если выражений слишком много, то заменяем последний элемент на найденное последнее выражение
                    

                    if (i + 1 == express.Length)                   //Если это конец, учесть последнее выражение
                        countNumExpressions++;    
                    //sum = null;
                }
                else if (!leftExist)                               //Если левой цифры нет, то находим левую
                {
                    leftNum = getNum(express, ref i);
                    leftExist = true;
                    //Console.WriteLine(" leftNum: " + leftNum);
                }
            }
            else if (saveSign.Equals('?') && leftExist && isSign(express[i]))          //Если знак+- и, если он не найден и левое значение существует
            {
                saveSign = express[i];
            }
            else                                              //Если знак не+- ,не цифра,то обнуляем собранные значения
            {
                if(sum.HasValue)countNumExpressions++;        //Если сумма существует, значит, увеличиваем счетчик выражений                                             
                sum = null;
                resetAll();                                   //Обнуляем все значения(лево, право и знак)
            }
        }

        public int?[] getSumAll()//Получить сумму
        {
            return keepAllExpress;
        }

        public string getOutputArr()
        {
            string elems = "";
            for(int i = 0; i < keepAllExpress.Length; i++)
            {
                if (i == keepAllExpress.Length - 1 && getNumsExpressions() > keepAllExpress.Length)
                    elems += "...";                //Если количество выражений велико, то пишем такой знак
                if (keepAllExpress[i].HasValue)                  //Т.к этот массив содержит ограниченное количество элементов, то
                    elems += keepAllExpress[i];           // нам нужно проверить наличие этих элементов(может быть и null значение)
                if (i + 1 < keepAllExpress.Length && keepAllExpress[i + 1].HasValue) elems += ", "; //Чтобы не было лишних запятых

            }
            return elems;
        }
        public int getNumsExpressions() //Получить позицию массива, который содержит найденные суммы
        {
            return countNumExpressions;
        }
    }
}

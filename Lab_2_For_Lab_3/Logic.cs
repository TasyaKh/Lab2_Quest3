using System;

namespace Lab_2_For_Lab_3
{
    //Дан текст, имеющий вид: d1+d2−d3+...−dn, где di — цифры(n > 1). Вычислить записанную в тексте сумму
    public class Logic
    {
        private int sum;               //Хранит сумму элементов
        private int? leftNum;          //Хранит левый номер

        private char saveSign;         //Определен ли знак
        private string messageError;   //Хранит сообщение об ошибке
        public Logic()
        {
            messageError = "Поле ввода пусто"; //Сделать по умолчанию сообщение о том, что в поле ничего не введено
            sum = 0;                           //Начальная сумма = 0

            leftNum = null;                    //Левого значения не существует
            saveSign = '-';                    //Первый знак - т.к он противоположен плюсу
        }

        public string startChecking(string txt) //Начать перебор введенного текста
        {
            bool findNum = true;                //Первым делом находим номер(переключает нахождение номера и знака)

            foreach (char symb in txt.ToCharArray())
            {
                if (findNum)
                {
                    findNum = false;
          
                    if ((messageError = saveNumber(symb)) != "") //Если сообщение об ошибке не сформировано, значит все хорошо
                    {
                        sum = 0;
                        break;
                    }
                }
                else
                {
                    findNum = true;

                    if ((messageError = saveCorrectSymbol(symb)) != "") //Если сообщение об ошибке не сформировано, значит все хорошо
                    {
                        sum = 0;
                        break;
                    }
                }
            }
            return messageError;

            // else messageError = $"Ошибка!Введено некорректное значение: {txt[0]}. Допустимый ввод: цифры и знаки +-";
        }

        private void Sum(int rightNum) //Вычислить сумму
        {
            if (saveSign == '+')       //В соостветствии с текущим знаком
                sum = (int)leftNum + rightNum;
            else
                sum = (int)leftNum - rightNum;
        }
        private string saveNumber(char symb) //Найти номер и сохранить его
        {
            string msg = "";

            if (Char.IsDigit(symb))          //Если символ цифра, то
            {   
                if (leftNum.HasValue)        //Если левое значение существует, то
                {              //Если первая цифра была найдена и знак тоже, то найти сумму
                    int rightNum = (int)Char.GetNumericValue(symb);
                    Sum(rightNum);
                    leftNum = sum;           //Теперь левое значение равно сумме элементов
                }
                else
                    leftNum = (int)Char.GetNumericValue(symb); //Если левого не существвует, то присвоить ему найденное значение
            }
            else                            //Если значение поля цифры не является цифрой, то сообщение об ошибке
            {
                msg = $"Ошибка!Введено некорректное значение: {symb}. Допустимый ввод: цифры";
            }
            return msg;
        }

        private string saveCorrectSymbol(char symb) //Проверить на наличие корректного символа +-
        {
            string msg = "";

            switch (symb)
            {
                case '+':                 
                    if (saveSign == '-') //Если имеющийся на данный момент символ является -, то следующий знак будет +
                        saveSign = '+';
                    else msg = $"Ошибка!Введен некорректный знак: '{symb}'. Допустимый ввод: '-'";
                    break;
                case '-':
                    if (saveSign == '+')
                        saveSign = '-';
                    else msg = $"Ошибка!Введен некорректный знак: '{symb}'. Допустимый ввод: '+'";
                    break;
                default:
                    msg = $"Ошибка!Введен некорректный знак: '{symb}'. Допустимый ввод: '+' или '-'";
                    break;
            }

            return msg;
        }

        public int getSum() //Вывести сумму
        {
            return sum; 
        }
    }
}

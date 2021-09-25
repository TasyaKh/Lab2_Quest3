using System;
using System.Windows.Forms;

namespace Lab_2_For_Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startChecking(Logic logic)
        {
            string txt = textBox1.Text;                //Получем текст с бокса

            for (int i = 0; i < txt.Length; i++)       //Проверяем каждый символ в этом тексте
            {
                logic.checkWord(textBox1.Text, ref i); //Вызываем метод проверки этого символа
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logic logic = new Logic();

            label3.Text = "";                         //Этот лейбл выводит полученные суммы нескольких выражений
            startChecking(logic);                     //Начать проверку слова

            int?[] sumAll = logic.getSumAll();        //Получить найденне суммы

            for (int i = 0; i < sumAll.Length; i++)
            {
                if (i == sumAll.Length - 1 && logic.getNumsExpressions() > sumAll.Length)
                    label3.Text += " ...";                //Если количество выражений велико, то пишем такой знак
                if (sumAll[i].HasValue)                  //Т.к этот массив содержит ограниченное количество элементов, то
                    label3.Text += sumAll[i];           // нам нужно проверить наличие этих элементов(может быть и null значение)
                if (i + 1 < sumAll.Length && sumAll[i + 1].HasValue) label3.Text += ", "; //Чтобы не было лишних запятых
            }
        }
    }
}

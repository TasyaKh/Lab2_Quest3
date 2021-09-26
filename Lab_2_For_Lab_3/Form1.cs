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
            Logic logic = new Logic(5);

            label3.Text = "";                         //Этот лейбл выводит полученные суммы нескольких выражений
            startChecking(logic);                     //Начать проверку слова

            int?[] sumAll = logic.getSumAll();        //Получить найденне суммы

            label3.Text = logic.getOutputArr();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Windows.Forms;

namespace Lab_2_For_Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "Ответ: ";                                   //Этот лейбл выводит полученную сумму

            Logic logic = new Logic();
            string msgError = "";
                                 
            msgError = logic.startChecking(textBox1.Text);       //Начать поиск

            if (msgError != "") MessageBox.Show(msgError);
            else
            {
                label2.Text += Convert.ToString(logic.getSum());
                Properties.Settings.Default.Text = textBox1.Text;
                Properties.Settings.Default.Save();
            }  
        }

        private void заданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "Дан текст, имеющий вид: d1+d2−d3+...−dn," +
                " где di — цифры(n > 1). Вычислить записанную в тексте сумму";
            MessageBox.Show(txt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}

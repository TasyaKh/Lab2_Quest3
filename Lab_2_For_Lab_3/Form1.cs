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
            label3.Text = "";                                   //Этот лейбл выводит полученную сумму

            Logic logic = new Logic();
            string msgError = "";
                                 
            msgError = logic.startChecking(textBox1.Text);       //Начать поиск

            if (msgError != "") MessageBox.Show(msgError);
            else
            {
                label3.Text = Convert.ToString(logic.getSum());
                Properties.Settings.Default.Text = textBox1.Text;
                Properties.Settings.Default.Save();
            }  
        }

    }
}

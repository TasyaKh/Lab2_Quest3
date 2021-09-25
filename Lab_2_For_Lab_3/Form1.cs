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
            string txt = textBox1.Text;

            for (int i = 0; i < txt.Length; i++)
            {
                logic.checkWord(textBox1.Text, ref i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logic logic = new Logic();

            label3.Text = "";
            startChecking(logic);

            int?[] sumAll = logic.getSumAll();
            foreach (int? expr in sumAll){
                if(expr.HasValue)
                    label3.Text += expr + " ";
            }
        }
    }
}

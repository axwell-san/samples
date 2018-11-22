using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form : System.Windows.Forms.Form
    {
        bool _isPrevNum;
        string _prOperation;
        int? _operand;

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            input.Text = 0.ToString();
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Operate(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Operate(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Operate(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Operate(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Operate(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Operate(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Operate(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Operate(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Operate(button9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Operate(button0);
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Operate(buttonPlus);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            Operate(buttonMinus);
        }

        private void buttonMulti_Click(object sender, EventArgs e)
        {
            Operate(buttonMulti);
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            Operate(buttonDiv);
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            Operate(buttonResult);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Operate(buttonReset);
        }

        private void Operate(Button button)
        {
            if (button.Text.ToCharArray().All(_ => char.IsNumber(_)))
            {
                if (_isPrevNum)
                {
                    if (!(button.Text.Equals("0") && input.Text.Equals("0")))
                    {
                        input.Text = input.Text.Equals("0") ? button.Text : input.Text + button.Text;
                    }
                }
                else
                {
                    input.Text = button.Text;
                }

                _isPrevNum = true;
            }
            else
            {
                if (button.Text.Equals("C"))
                {
                    input.Text = 0.ToString();
                    _operand = null;
                    _isPrevNum = false;
                }
                else
                {
                    if (_operand.HasValue && !_prOperation.Equals("="))
                    {
                        Calc(_operand.Value, int.Parse(input.Text), _prOperation);
                    }

                    _operand = int.Parse(input.Text);
                    _prOperation = button.Text;
                    _isPrevNum = false;
                }
            }  
        }

        private void Calc(int a, int b, string op)
        {
            switch (op)
            {
                case "+":
                    input.Text = (a + b).ToString();
                    break;
                case "-":
                    input.Text = (a - b).ToString();
                    break;
                case "*":
                    input.Text = (a * b).ToString();
                    break;
                case "/":

                    try
                    {
                        input.Text = (a / b).ToString();
                    }
                    catch(DivideByZeroException e)
                    {
                        MessageBox.Show("CAN'T DEVIDE BY ZERO");
                    }

                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

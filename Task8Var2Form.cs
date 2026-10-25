using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace WinFormsPractice
{
    public class Task8Var2Form : Form
    {
        private TextBox txtDisplay;
        private const string Operators = "+-*/";

        public Task8Var2Form()
        {
            Text = "Калькулятор (вариант 2)";
            ClientSize = new Size(420, 420);
            StartPosition = FormStartPosition.CenterScreen;

            txtDisplay = new TextBox();
            txtDisplay.Left = 15; txtDisplay.Top = 15; txtDisplay.Width = 390;
            txtDisplay.Font = new Font("Segoe UI", 20);
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            txtDisplay.ReadOnly = true;
            Controls.Add(txtDisplay);

            for (int i = 1; i <= 9; i++)
            {
                int row = (i - 1) / 3;
                int col = (i - 1) % 3;
                AddButton(i.ToString(), 15 + col * 70, 90 + row * 65, Digit_Click);
            }
            AddButton("0", 85, 285, Digit_Click);
            AddButton(".", 155, 285, Digit_Click);

            // действия
            string[] ops = { "+", "-", "*", "/" };
            for (int i = 0; i < ops.Length; i++)
            {
                AddButton(ops[i], 240, 90 + i * 65, Operator_Click);
            }

            AddButton("Стереть", 310, 90, Erase_Click);
            AddButton("=", 310, 155, Equals_Click);
        }

        private void AddButton(string text, int x, int y, EventHandler handler)
        {
            Button b = new Button();
            b.Text = text;
            b.Left = x; b.Top = y; b.Width = 60; b.Height = 55;
            b.Click += handler;
            Controls.Add(b);
        }

        private int FindOperator(string s)
        {
            if (s.Length < 2) return -1;
            return s.IndexOfAny(Operators.ToCharArray(), 1);
        }

        private void Digit_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += ((Button)sender).Text;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            string op = ((Button)sender).Text;
            string s = txtDisplay.Text;

            if (s == "")
            {
                if (op == "-") txtDisplay.Text = "-"; 
                return;
            }
            if (s == "-") return;

            if (Operators.IndexOf(s[s.Length - 1]) >= 0)
            {
                txtDisplay.Text = s.Substring(0, s.Length - 1) + op;
                return;
            }

            if (FindOperator(s) >= 0)
            {
                if (!Calculate()) return;
            }

            txtDisplay.Text += op;
        }

        private void Erase_Click(object sender, EventArgs e)
        {
            string s = txtDisplay.Text;
            if (s.Length > 0)
                txtDisplay.Text = s.Substring(0, s.Length - 1); 
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            Calculate();
        }
        private bool Calculate()
        {
            string s = txtDisplay.Text;
            int opIndex = FindOperator(s);

            if (opIndex < 0) return true;

            string leftText = s.Substring(0, opIndex);
            char op = s[opIndex];
            string rightText = s.Substring(opIndex + 1);

            double a, b, result;
            if (!double.TryParse(leftText, NumberStyles.Float, CultureInfo.InvariantCulture, out a) ||
                !double.TryParse(rightText, NumberStyles.Float, CultureInfo.InvariantCulture, out b))
            {
                MessageBox.Show("Некорректное выражение!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            switch (op)
            {
                case '+': result = a + b; break;
                case '-': result = a - b; break;
                case '*': result = a * b; break;
                default: // '/'
                    if (b == 0)
                    {
                        MessageBox.Show("На ноль делить нельзя!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDisplay.Clear();
                        return false;
                    }
                    result = a / b;
                    break;
            }

            txtDisplay.Text = result.ToString(CultureInfo.InvariantCulture);
            return true;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using CompactCalculator.Commands;

namespace CompactCalculator.UI
{
    public class CalculatorForm : Form
    {
        private readonly Calculator calculator;
        private readonly CommandHistory commandHistory;
        private TextBox display = null!;
        private string input = "";
        private double firstNum = 0;
        private string operation = "";
        private bool altMode = false;

        public CalculatorForm()
        {
            calculator = new Calculator();
            commandHistory = new CommandHistory();
            InitializeUI();
        }

        private void InitializeUI()
        {
            Text = "Калькулятор";
            Size = new Size(290, 450);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            display = new TextBox
            {
                Location = new Point(10, 10),
                Size = new Size(250, 30),
                Font = new Font("Consolas", 14, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Right,
                ReadOnly = true,
                Text = "0",
                BackColor = Color.White
            };
            Controls.Add(display);

            string[] buttons = {
                "ALT", "↶", "C", "CE",
                "7", "8", "9", "÷",
                "4", "5", "6", "×",
                "1", "2", "3", "-",
                "0", ".", "=", "+"
            };

            int x = 10, y = 50;
            for (int i = 0; i < buttons.Length; i++)
            {
                var btn = new Button
                {
                    Text = buttons[i],
                    Location = new Point(x, y),
                    Size = new Size(60, 50),
                    Font = new Font("Arial", 11, FontStyle.Bold)
                };

                string text = buttons[i];
                if ("0123456789".Contains(text))
                    btn.Click += (s, e) => { input += text; display.Text = input; };
                else if (text == ".") 
                    btn.Click += (s, e) => { if (!input.Contains(".")) { input += "."; display.Text = input; } };
                else if ("÷×-+".Contains(text))
                    btn.Click += (s, e) => { if (input != "") { firstNum = double.Parse(input); operation = text; input = ""; } };
                else if (text == "=")
                    btn.Click += (s, e) => Calculate();
                else if (text == "C")
                    btn.Click += (s, e) => { calculator.Value = 0; input = ""; firstNum = 0; operation = ""; commandHistory.Clear(); display.Text = "0"; };
                else if (text == "CE")
                    btn.Click += (s, e) => { input = ""; display.Text = "0"; };
                else if (text == "↶")
                    btn.Click += (s, e) => { commandHistory.Undo(); display.Text = calculator.Value.ToString(); input = calculator.Value.ToString(); };
                else if (text == "ALT")
                {
                    btn.Click += (s, e) => { altMode = !altMode; btn.BackColor = altMode ? Color.Orange : SystemColors.Control; UpdateCustomButtons(); };
                    btn.Name = "btnAlt";
                }

                Controls.Add(btn);

                x += 65;
                if ((i + 1) % 4 == 0) { x = 10; y += 55; }
            }

            // Настраиваемые кнопки
            y += 10;
            var custom1 = AddCustom("x²", 10, y, (s, e) => Custom1());
            var custom2 = AddCustom("√", 95, y, (s, e) => Custom2());
            var custom3 = AddCustom("%", 180, y, (s, e) => Custom3());
        }

        private Button AddCustom(string text, int x, int y, EventHandler handler)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(75, 50),
                Font = new Font("Arial", 11, FontStyle.Bold),
                BackColor = Color.LightSteelBlue,
                Name = text
            };
            btn.Click += handler;
            Controls.Add(btn);
            return btn;
        }

        private void Calculate()
        {
            if (operation == "" || input == "") return;
            calculator.Value = firstNum;
            double second = double.Parse(input);

            Func<double, double, double>? op = operation switch 
            {
                "+" => (a, b) => a + b,
                "-" => (a, b) => a - b,
                "×" => (a, b) => a * b,
                "÷" => (a, b) => b != 0 ? a / b : a,
                _ => null
            };

            if (op != null)
            {
                commandHistory.Execute(new OperationCommand(calculator, second, op));
                display.Text = calculator.Value.ToString();
                input = calculator.Value.ToString();
                operation = "";
            }
        }

        private void Custom1()
        {
            if (!altMode)
            {
                // x²
                if (input != "")
                {
                    calculator.Value = double.Parse(input);
                    commandHistory.Execute(new UnaryCommand(calculator, x => x * x));
                    display.Text = calculator.Value.ToString();
                    input = calculator.Value.ToString();
                }
            }
            else
            {
                // M+
                if (input != "") calculator.Memory = double.Parse(input);
            }
        }

        private void Custom2()
        {
            if (!altMode)
            {
                // √
                if (input != "")
                {
                    calculator.Value = double.Parse(input);
                    commandHistory.Execute(new UnaryCommand(calculator, x => Math.Sqrt(x)));
                    display.Text = calculator.Value.ToString();
                    input = calculator.Value.ToString();
                }
            }
            else
            {
                // MR
                display.Text = calculator.Memory.ToString();
                input = calculator.Memory.ToString();
            }
        }

        private void Custom3()
        {
            if (!altMode)
            {
                // %
                if (input != "" && firstNum != 0)
                {
                    calculator.Value = double.Parse(input);
                    commandHistory.Execute(new OperationCommand(calculator, firstNum, (v, b) => b * (v / 100)));
                    display.Text = calculator.Value.ToString();
                    input = calculator.Value.ToString();
                }
            }
            else
            {
                // MC
                calculator.Memory = 0;
            }
        }

        private void UpdateCustomButtons()
        {
            foreach (Control c in Controls)
            {
                if (c is Button btn)
                {
                    if (btn.Name == "x²") btn.Text = altMode ? "M+" : "x²";
                    else if (btn.Name == "√") btn.Text = altMode ? "MR" : "√";
                    else if (btn.Name == "%") btn.Text = altMode ? "MC" : "%";
                }
            }
        }
    }
}

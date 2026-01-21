using System;
using System.Drawing;
using System.Windows.Forms;

namespace DialogFactory.Products
{
    public class BasicDialog : UserDialog
    {
        private TextBox txtName = null!;
        private NumericUpDown numAge = null!;

        public BasicDialog()
        {
            InitBase("Базовая регистрация");

            Controls.Add(new Label 
            { 
                Text = "ФИО:", 
                Location = new Point(20, 20), 
                AutoSize = true 
            });
            txtName = new TextBox 
            { 
                Location = new Point(100, 20), 
                Width = 220 
            };
            Controls.Add(txtName);

            Controls.Add(new Label 
            { 
                Text = "Возраст:", 
                Location = new Point(20, 60), 
                AutoSize = true 
            });
            numAge = new NumericUpDown 
            { 
                Location = new Point(100, 60), 
                Width = 220, 
                Minimum = 18, 
                Maximum = 100 
            };
            Controls.Add(numAge);

            var btnOk = AddButton("OK", 180, 160, DialogResult.OK);
            btnOk.Click += BtnOk_Click;
            AddButton("Отмена", 260, 160, DialogResult.Cancel);
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            userData = $"ФИО: {txtName.Text}, Возраст: {numAge.Value}";
        }
    }
}

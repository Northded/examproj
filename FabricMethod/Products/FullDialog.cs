using System;
using System.Drawing;
using System.Windows.Forms;

namespace DialogFactory.Products
{
    public class FullDialog : UserDialog
    {
        private TextBox txtName = null!;
        private NumericUpDown numAge = null!;
        private TextBox txtAddress = null!;

        public FullDialog()
        {
            InitBase("Полная анкета", 300);

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

            Controls.Add(new Label 
            { 
                Text = "Адрес:", 
                Location = new Point(20, 100), 
                AutoSize = true 
            });
            txtAddress = new TextBox 
            { 
                Location = new Point(100, 100), 
                Width = 220, 
                Multiline = true, 
                Height = 60 
            };
            Controls.Add(txtAddress);

            var btnOk = AddButton("OK", 180, 200, DialogResult.OK);
            btnOk.Click += BtnOk_Click;
            AddButton("Отмена", 260, 200, DialogResult.Cancel);
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            userData = $"ФИО: {txtName.Text}, Возраст: {numAge.Value}, Адрес: {txtAddress.Text}";
        }
    }
}

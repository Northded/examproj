using System;
using System.Drawing;
using System.Windows.Forms;

namespace DialogFactory.Products
{
    public class ExtendedDialog : UserDialog
    {
        private TextBox txtName = null!;
        private ComboBox cmbGender = null!;
        private ComboBox cmbEducation = null!;

        public ExtendedDialog()
        {
            InitBase("Расширенный профиль");

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
                Text = "Пол:", 
                Location = new Point(20, 60), 
                AutoSize = true 
            });
            cmbGender = new ComboBox 
            { 
                Location = new Point(100, 60), 
                Width = 220, 
                DropDownStyle = ComboBoxStyle.DropDownList 
            };
            cmbGender.Items.AddRange(new[] { "Мужской", "Женский" });
            Controls.Add(cmbGender);

            Controls.Add(new Label 
            { 
                Text = "Образование:", 
                Location = new Point(20, 100), 
                AutoSize = true 
            });
            cmbEducation = new ComboBox 
            { 
                Location = new Point(100, 100), 
                Width = 220, 
                DropDownStyle = ComboBoxStyle.DropDownList 
            };
            cmbEducation.Items.AddRange(new[] { "Среднее", "Высшее", "Ученая степень" });
            Controls.Add(cmbEducation);

            var btnOk = AddButton("OK", 180, 160, DialogResult.OK);
            btnOk.Click += BtnOk_Click;
            AddButton("Отмена", 260, 160, DialogResult.Cancel);
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            userData = $"ФИО: {txtName.Text}, Пол: {cmbGender.Text}, Образование: {cmbEducation.Text}";
        }
    }
}

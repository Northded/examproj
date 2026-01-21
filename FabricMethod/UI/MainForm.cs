using System;
using System.Drawing;
using System.Windows.Forms;
using DialogFactory.Factories;

namespace DialogFactory.UI
{
    public class MainForm : Form
    {
        public MainForm()
        {
            Text = "Фабрика Диалогов - Factory Method Pattern";
            Size = new Size(420, 220);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            AddButton("Базовая регистрация", 20, () => new BasicFactory());
            AddButton("Расширенный профиль", 70, () => new ExtendedFactory());
            AddButton("Полная анкета", 120, () => new FullFactory());
        }

        private Button AddButton(string text, int y, Func<Factories.DialogFactory> factoryCreator)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(50, y),
                Size = new Size(200, 35),
                Font = new Font("Arial", 10)
            };
            
            btn.Click += (sender, e) =>
            {
                var factory = factoryCreator();
                string data = factory.ShowDialog();
                
                if (!string.IsNullOrEmpty(data))
                {
                    MessageBox.Show(data, "Результат регистрации", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            
            Controls.Add(btn);
            return btn;
        }
    }
}

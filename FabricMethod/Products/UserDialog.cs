using System.Drawing;
using System.Windows.Forms;

namespace DialogFactory.Products
{
    public abstract class UserDialog : Form
    {
        protected string userData = "";
        public string GetData() => userData;

        protected void InitBase(string title, int height = 250)
        {
            Text = title;
            Size = new Size(350, height);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

        protected Button AddButton(string text, int x, int y, DialogResult result)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(70, 30),
                DialogResult = result
            };
            Controls.Add(btn);
            return btn;
        }
    }
}

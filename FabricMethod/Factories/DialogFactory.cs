using System.Windows.Forms;
using DialogFactory.Products;

namespace DialogFactory.Factories
{
    public abstract class DialogFactory
    {
        public abstract UserDialog CreateDialog();
        public string ShowDialog()
        {
            var dialog = CreateDialog();
            return dialog.ShowDialog() == DialogResult.OK ? dialog.GetData() : "";
        }
    }
}

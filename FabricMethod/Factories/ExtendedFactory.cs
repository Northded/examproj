using DialogFactory.Products;

namespace DialogFactory.Factories
{
    public class ExtendedFactory : DialogFactory
    {
        public override UserDialog CreateDialog()
        {
            return new ExtendedDialog();
        }
    }
}

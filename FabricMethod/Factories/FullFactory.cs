using DialogFactory.Products;

namespace DialogFactory.Factories
{
    public class FullFactory : DialogFactory
    {
        public override UserDialog CreateDialog()
        {
            return new FullDialog();
        }
    }
}

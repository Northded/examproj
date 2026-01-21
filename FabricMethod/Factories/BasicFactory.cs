using DialogFactory.Products;

namespace DialogFactory.Factories
{
    public class BasicFactory : DialogFactory
    {
        public override UserDialog CreateDialog()
        {
            return new BasicDialog();
        }
    }
}

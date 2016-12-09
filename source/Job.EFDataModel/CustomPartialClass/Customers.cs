namespace Job.EFDataModel
{
    public partial class Customers
    {

        public static Customers Create() 
        {
            
            Customers r = new Customers();
            r.IsInternal = false;
            r.IsActive = true;
            r.CustomerId = -1;
            r.Salutation = "Spett.le";
            return r;
        }
    }
}

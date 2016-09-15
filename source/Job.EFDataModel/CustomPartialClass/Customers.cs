namespace Job.EFDataModel
{
    public partial class Customers
    {
        public const byte STATUS_ACTIVE = 0;
        public const byte STATUS_ARCHIVED = 1;
        public const byte STATUS_INTERNAL = 125;

        public static Customers Create() 
        {
            Customers r = new Customers();
            r.Status = Customers.STATUS_ACTIVE;
            r.CustomerId = -1;
            return r;
        }
    }
}

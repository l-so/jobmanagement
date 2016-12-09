namespace Job.EFDataModel
{
    public partial class TravelExpenses
    {
        public const byte STATUS_BOZZA = 0;
        public const byte STATUS_REGISTRATA = 1;
        public const int CATEGORY_RIMBKM = 50;
        public string getStatusDescription()
        {
            switch (this.Status)
            {
                case STATUS_BOZZA:
                    return "Bozza";
                default:
                    return "Confermata";
            }

        }
    }
}

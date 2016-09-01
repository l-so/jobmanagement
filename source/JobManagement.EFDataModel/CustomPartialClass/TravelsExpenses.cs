namespace JobManagement.EFDataModel
{
    public partial class TravelExpenses
    {
        public const byte STATUS_BOZZA = 0;
        public const byte STATUS_CONFERMATA = 1;
        public const byte STATUS_POSTED = 100;
        public const string POST_ACCOUNT = "63.01.01";
        public string getStatusDescription(byte _state)
        {
            switch (_state)
            {
                case STATUS_BOZZA:
                    return "Bozza";
                default:
                    return "Confermata";
            }

        }
    }
}

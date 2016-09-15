namespace Job.EFDataModel
{
    public partial class Jobs
    {
        public const byte STATE_BOZZA = 0;
        public const byte STATE_OPERATIVA = 10;
        public const byte STATE_CHIUSA = 20;
        public const byte STATE_ARCHIVIATA = 30;
        public const byte STATE_INTERNA = 125;

        public string getStateDescription(byte _state)
        {
            switch (_state)
            {
                case STATE_BOZZA:
                    return "Bozza";
                case STATE_OPERATIVA:
                    return "Operativa";
                case STATE_CHIUSA:
                    return "Chiusa";
                case STATE_ARCHIVIATA:
                    return "Archiviata";
                default:
                    return "Interna";
            }

        }
    }
}

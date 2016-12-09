namespace Job.EFDataModel
{
    public partial class Jobs
    {
        public const byte STATE_OFFERTA = 10;
        public const byte STATE_OPERATIVA = 100;
        public const byte STATE_CHIUSA = 110;
        public const byte STATE_ARCHIVIATA = 255;
        public const byte STATE_INTERNA = 3;

        public string getStateDescription(byte _state)
        {
            switch (_state)
            {
                case STATE_OFFERTA:
                    return "Offerta";
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

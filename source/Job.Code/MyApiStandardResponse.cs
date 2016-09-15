namespace Job.Code
{
    public class MyApiStandardResponse
    {
        public string ResultStatus { get; set; } // OK o KO
        public string Error { get; set; } // Tipo di errore (Exception Type)
        public string ErrorMessage { get; set; } // Messaggio di errore
        public string Data { get; set; } // Oggetti in risposta se OK
    }
}

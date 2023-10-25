namespace SystemPag.Models
{
    public class ErrorViewModel
    {
        // A propriedade RequestId é usada para armazenar o ID da solicitação.
        public string RequestId { get; set; }

        // A propriedade ShowRequestId retorna um valor booleano que indica se RequestId não é nulo ou vazio.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

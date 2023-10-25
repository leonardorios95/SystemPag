namespace SystemPag.Models
{
    public class ErrorViewModel
    {
        // A propriedade RequestId � usada para armazenar o ID da solicita��o.
        public string RequestId { get; set; }

        // A propriedade ShowRequestId retorna um valor booleano que indica se RequestId n�o � nulo ou vazio.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

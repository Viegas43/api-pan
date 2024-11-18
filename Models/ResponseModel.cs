namespace PROJETO_PAN.Models
{
    public class ResponseModel<T>
    {
        public T? dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;    
        public bool Status { get; set; } = true;
    }
}

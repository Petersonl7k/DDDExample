namespace Domain.Entidades
{
    public class ClienteCommand
    {
        public int ClienteId { get; set; }
        public string primeiroNome { get; set; }
        public string nomeMeio { get; set; }
        public string ultimoNome { get; set; }
        public string nascimento { get; set; }
        public string habilitacao { get; set; }
        public string estado { get; set; }
        public string cpf { get; set; }
        public string contato { get; set; }
    }
}

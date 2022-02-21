namespace API.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string cidade { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string cpf { get; set; } = string.Empty;
    }
}
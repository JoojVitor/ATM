namespace ATM.Models
{
    public enum Titularidade{
        Titular = 1,
        Agregado = 2,
    }

    public class Cliente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string SenhaPessoal { get; set; }
        public Titularidade Titularidade { get; set; }
    }
}

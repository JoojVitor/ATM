namespace ATM.Models
{
    public enum Tipo
    {
        C,  // Crédito
        D   // Débito
    }

    public class Lancamento
    {
        public string Numero {  get; set; }
        public Tipo Tipo { get; set; }
        public float Valor { get; set; }
    }
}

namespace ATM.Models
{
    public class Transacao
    {
        public string Numero { get; set; }
        public int Tipo { get; set; }
        public DateTime DataHorario { get; set; }
        public float Valor { get; set; }
        public int QtdCedulas2 { get; set; }
        public int QtdCedulas5 { get; set; }
        public int QtdCedulas10 { get; set; }
        public int QtdCedulas20 { get; set; }
        public int QtdCedulas50 { get; set; }
        public int QtdCedulas100 { get; set; }
    }
}

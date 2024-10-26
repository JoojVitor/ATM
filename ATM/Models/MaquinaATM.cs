namespace ATM.Models
{
    public class MaquinaATM
    {
        public string Codigo { get; set; }
        public float Saldo { get; set; }
        public int QtdCedulas2 {  get; set; }
        public int QtdCedulas5 {  get; set; }
        public int QtdCedulas10 {  get; set; }
        public int QtdCedulas20 {  get; set; }
        public int QtdCedulas50 {  get; set; }
        public int QtdCedulas100 {  get; set; }
    }
}

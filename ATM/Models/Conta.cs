using System.ComponentModel;

namespace ATM.Models
{
    public class Conta
    {
        public int Codigo { get; set; }
        public float Saldo { get; set; }
        [DisplayName("Senha")]
        public string Senha { get; set; }
        public float LimiteDiaSaque { get; set; }
    }
}

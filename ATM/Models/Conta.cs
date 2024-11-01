using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class Conta
    {
        [Key]
        public int Codigo { get; set; }
        public float Saldo { get; set; }
        [DisplayName("Senha")]
        public string Senha { get; set; }
        public float LimiteDiaSaque { get; set; }
    }
}

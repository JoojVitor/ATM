using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class Saque
    {
        [Key]
        public Guid Id { get; set; }
        public Cartao Cartao { get; set; }
        public Conta Conta { get; set; }
        [DisplayName("Valor do saque")]
        public float Valor { get; set; }
    }
}

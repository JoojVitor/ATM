using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class Cartao
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Número")]
        public int Numero { get; set; }
        [DisplayName("Validade")]
        public DateOnly DataValidade { get; set; }
        public int CodConta { get; set; }
    }
}

using System.ComponentModel;

namespace ATM.Models
{
    public class Cartao
    {
        [DisplayName("Número")]
        public int Numero { get; set; }
        [DisplayName("Validade")]
        public DateOnly DataValidade { get; set; }
    }
}

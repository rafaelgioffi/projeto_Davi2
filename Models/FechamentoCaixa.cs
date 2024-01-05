using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class FechamentoCaixa
    {
        public int FechamentoID { get; set; }

        [Display(Name = "Data")]
        public DateTime DataFechamento { get; set; }

        [Display(Name = "Abertura")]
        public decimal ValorInicial { get; set; }

        [Display(Name = "Fechamento")]
        public decimal ValorFinal { get; set; }

        //public ICollection<Compra> Compras { get; set; }
        public int CompraID { get; set; }
        virtual public Compra Compra { get; set; }
    }
}

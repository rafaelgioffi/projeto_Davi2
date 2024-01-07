using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Compra
    {
        [Key]
        public int CompraID { get; set; }

        [Required]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }

        [Display(Name = "Comprado")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public DateTime DataCompra { get; set; }

        [Required]
        [Display(Name = "Pagamento")]
        public string? FormaPagamento { get; set; }

    }
}

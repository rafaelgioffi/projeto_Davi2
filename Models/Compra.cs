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

        public DateTime DataCompra { get; set; }

        [Required]
        public string? FormaPagamento { get; set; }

    }
}

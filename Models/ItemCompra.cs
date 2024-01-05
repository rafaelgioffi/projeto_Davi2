using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class ItemCompra
    {
        public int ItemCompraID { get; set; }
        public int ProdutoID { get; set; }
        virtual public Produto Produto { get; set; }
        [Required]
        public int Qtd { get; set; }
        [Column(TypeName = "decimal(18,2)"), Required]
        public decimal ValorTotal { get; set; }
        [Column(TypeName = "decimal(18,2)"), Required]
        public decimal ValorUnit {  get; set; }
        public int CompraID { get; set; }
        virtual public Compra Compra { get; set; }
    }
}

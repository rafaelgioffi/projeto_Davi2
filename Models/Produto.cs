using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }

        public string Nome { get; set; }

        [Range(0, 300, ErrorMessage = "A descrição deve ter entre {2} e {1} caracteres")]
        public string? Descricao { get; set; }

        [Column(TypeName = "decimal(18,2)"), Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal PrecoUnit { get; set; }

    }
}

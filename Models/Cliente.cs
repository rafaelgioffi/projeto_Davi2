using Microsoft.Data.SqlClient.Server;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        public string? Telefone { get; set; }

        public string? CEP { get; set; }

        public string? Rua { get; set; }

        public string? Numero { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? Estado { get; set; }

        [Display(Name = "Data de nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Nascimento { get; set; }

        public int? Idade { get; set; }

        //virtual public ICollection<Compra>? Compras { get; set; }
        public string MostrarCPF()
        {
            if (CPF.Length < 14)
            {
                return "CPF Inválido";
            }
            string cpf1 = CPF.Substring(0, 3);
            string cpf2 = CPF.Substring(CPF.Length - 2);

            return $"{cpf1}.***.***-{cpf2}";
        }
    }
}

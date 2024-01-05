using Microsoft.EntityFrameworkCore;

namespace ProjetoFinal.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<ItemCompra> ItemCompras { get; set; }
        public DbSet<Compra> Compras { get; set; }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            //Relação Compra - ItemCompra
            //modelBuilder.Entity<Compra>()
            //            .HasMany(cr => cr.Itens)
            //            .WithOne(ic => ic.Compra);

            ////Relação Compra - Cliente
            //modelBuilder.Entity<Compra>()
            //            .HasOne(cr => cr.Cliente)
            //            .WithMany(c => c.Compras)
            //            .HasPrincipalKey(c => c.ClienteID)
            //            .HasForeignKey(cr => cr.ClienteID)
            //            .OnDelete(DeleteBehavior.Restrict);

            ////Relação ItemCompra - Produto
            //modelBuilder.Entity<ItemCompra>()
            //            .HasOne(ic => ic.Produto);

            //Aqui eu digo que o CPF é único, ou seja, não tem como cadastrar 2 CPF's iguais.
            //modelBuilder.Entity<Cliente>()
            //            .HasIndex(c => c.CPF)
            //            .IsUnique();

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    ClienteID = 1,
                    Nome = "Uílha de Souza",
                    CPF = "123.456.789-10"
                },
                new Cliente
                {
                    ClienteID = 2,
                    Nome = "Britinei Ispirs",
                    CPF = "123.456.789-11"
                });

            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    ProdutoID = 1,
                    Nome = "PNY Geforce RTX 3060 12GB GDDR6",
                    PrecoUnit = 2099.90M
                },
                new Produto
                {
                    ProdutoID = 2,
                    Nome = "EVGA Gerforce RTX 4090 24GB GDDR6",
                    PrecoUnit = 12999.99M
                });
            modelBuilder.Entity<Compra>().HasData(
                new Compra
                {
                    CompraID = 1,
                    ClienteID = 2,
                    ProdutoID = 2,
                    DataCompra = new DateTime(2023-12-25-21-57-10),
                    FormaPagamento = "PIX"
                });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Prova2_APS.Models;

namespace democsharp.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<NotaVenda> NotasVenda { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Transporte> Transportes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<TipoPagamento> TiposPagamento { get; set; }
        public DbSet<PagamentoCheque> PagamentosComCheque { get; set; }
        public DbSet<PagamentoCartao> PagamentosCartao { get; set; }
    }

}

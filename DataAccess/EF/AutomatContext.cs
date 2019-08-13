using System.Data.Entity;
using WebAutomat.DataAccess.Entity;

namespace WebAutomat.DataAccess.EF
{
    public class AutomatContext : DbContext
    {
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Drink> Drinks { get; set; }
    }
}
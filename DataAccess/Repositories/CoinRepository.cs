using System.Collections.Generic;
using System.Linq;
using WebAutomat.DataAccess.EF;
using WebAutomat.DataAccess.Entity;
using WebAutomat.DataAccess.Interfaces;

namespace WebAutomat.DataAccess.Repositories
{
    public class CoinRepository: ICoinRepository //Репозиторий для монет
    {
        public IEnumerable<Coin> Coins
        {
            get
            {
                using (var context = new AutomatContext())
                    return context.Coins.ToList();
            }
        }

        public IEnumerable<Coin> CoinsDesc
        {
            get
            {
                using (var context = new AutomatContext())
                    return context.Coins.OrderByDescending(p => p.Cost).ToList();
            }
        }

        public Coin GetCoin(int coinId)
        {
            using (var context = new AutomatContext())
            {
                return context.Coins.Find(coinId);
            }
        }

        public void AddCoin(Coin coin)
        {
            using (var context = new AutomatContext())
            {
                context.Coins.Add(coin);
                context.SaveChanges();
            }
        }

        public void EditCoin(Coin coin)
        {
            using (var context = new AutomatContext())
            {
                Coin dbEntry = context.Coins.Find(coin.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = coin.Name;
                    dbEntry.Cost = coin.Cost;
                    dbEntry.Count = coin.Count;
                    dbEntry.Block = coin.Block;
                    context.SaveChanges();
                }
            }
        }

        public Coin DeleteCoin(int coinId)
        {
            using (var context = new AutomatContext())
            {
                Coin dbEntry = context.Coins.Find(coinId);
                if (dbEntry != null)
                {
                    context.Coins.Remove(dbEntry);
                    context.SaveChanges();
                }
                return dbEntry;
            }
        }
    }
}
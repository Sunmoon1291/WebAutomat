using System.Collections.Generic;
using WebAutomat.BusinessLogic.Interfaces;
using WebAutomat.DataAccess.Entity;
using WebAutomat.DataAccess.Interfaces;

namespace WebAutomat.BusinessLogic.Services
{
    public class CoinService: ICoinService
    {
        ICoinRepository Repos;

        public CoinService(ICoinRepository r)
        {
            Repos = r;
        }

        public IEnumerable<Coin> GetAll()
        {
            return Repos.Coins;
        }

        public void EditCoin(int CoinId, int newCount, bool DoBlock) //Изменение блокировки и кол-ва монет
        {
            Coin coin = Repos.GetCoin(CoinId);
            if (coin != null)
            {
                coin.Count = newCount;
                coin.Block = DoBlock;
                Repos.EditCoin(coin);
            }
        }

        public int AddCoin(int CoinId) //Добавление монеты в репозиторий
        {
            Coin coin = Repos.GetCoin(CoinId);
            if (coin != null)
            {
                coin.Count += 1;
                Repos.EditCoin(coin);
                return coin.Cost;
            }
            else
                return 0;
        }

        public Dictionary<string, int> GetChange(int sum) //Получение сдачи
        {
            var Costs = Repos.CoinsDesc;
            Dictionary<string,int> Wallet = new Dictionary<string, int>();

            foreach (var cost in Costs)
            {
                var num = sum / cost.Cost;
                if (num > cost.Count)
                    num = cost.Count;
                if (num > 0)
                {
                    sum -= num * cost.Cost;

                    Coin dbEntry = Repos.GetCoin(cost.ID);
                    if ((dbEntry != null) && (dbEntry.Count >= num))
                    {
                        dbEntry.Count -= num;
                        Wallet.Add(cost.Name, num);
                    }
                }
            }

            Wallet.Add("$remain", sum); //Сумма, на котору не хватило монет добавляется в конец

            return Wallet;
        }
    }
}
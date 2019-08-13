using System.Collections.Generic;
using WebAutomat.DataAccess.Entity;

namespace WebAutomat.BusinessLogic.Interfaces
{
    public interface ICoinService
    {
        IEnumerable<Coin> GetAll();
        void EditCoin(int CoinId, int newCount, bool DoBlock); //Изменение блокировки и кол-ва монет
        int AddCoin(int CoinId); //Добавление монеты в репозиторий
        Dictionary<string, int> GetChange(int sum); //Получение сдачи
    }
}

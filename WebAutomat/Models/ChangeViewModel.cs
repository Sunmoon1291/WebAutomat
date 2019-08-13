using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAutomat.Models
{
    public class ChangeViewModel
    {
        public int Status; //1 - успешно, 0 - не хватает монет для сдачи
        public Dictionary<string, int> Wallet;

        public ChangeViewModel()
        {
            Wallet = new Dictionary<string, int>();
        }
    }
}
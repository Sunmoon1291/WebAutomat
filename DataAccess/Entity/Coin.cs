namespace WebAutomat.DataAccess.Entity
{
    public class Coin
    {
        public int ID { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public bool Block { get; set; } //1 - заблокировано, 0 - нет
    }
}
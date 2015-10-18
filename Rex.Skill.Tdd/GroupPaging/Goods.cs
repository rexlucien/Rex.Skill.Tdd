namespace Rex.Skill.Tdd.GroupPaging
{
    public class Goods
    {
        public Goods(int id, int cost, int revenue, decimal sellPrice)
        {
            Id = id;
            Cost = cost;
            Revenue = revenue;
            SellPrice = sellPrice;
        }

        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public decimal SellPrice { get; set; }
    }
}
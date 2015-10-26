using System.Collections.Generic;

namespace Rex.Skill.Tdd.PotterShoppingCart
{
    public class PotterShoppingCart
    {
        public decimal Caculate(List<Book> books)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
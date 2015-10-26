using System.Collections.Generic;
using System.Linq;

namespace Rex.Skill.Tdd.PotterShoppingCart
{
    public interface IShoppingCart
    {
        decimal Caculate(List<Book> books);
    }

    public class PotterShoppingCart : IShoppingCart
    {
        public decimal Caculate(List<Book> books)
        {
            return books.Sum(x => x.Price);
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
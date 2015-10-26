using System;
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
            int disconut = books.Count >= 4 ? books.Count + 1 : books.Count;
            return Convert.ToDecimal(books.Sum(x => (double)x.Price) * (1.05 - disconut * 0.05));
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
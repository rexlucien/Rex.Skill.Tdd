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
            List<Book> source = books;

            decimal total = 0;

            while (source.Any())
            {
                var ids = source.GroupBy(x => x.Id).Select(x => x.Key);

                List<Book> sub = new List<Book>();

                foreach (var temp in ids.Select(key => source.FirstOrDefault(x => x.Id == key)))
                {
                    if (temp != null) sub.Add(temp);
                    source.Remove(temp);
                }

                int disconut = sub.Count >= 4 ? sub.Count + 1 : sub.Count;
                total += Convert.ToDecimal(sub.Sum(x => (double)x.Price) * (1.05 - disconut * 0.05));
            }

            return total;
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
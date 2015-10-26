using System.Collections.Generic;

namespace Rex.Skill.Tdd.PotterShoppingCart
{
    public interface IShoppingCart
    {
        decimal Caculate(List<Book> books);
    }
}
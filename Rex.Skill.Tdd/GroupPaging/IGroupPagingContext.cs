using System.Collections.Generic;

namespace Rex.Skill.Tdd.GroupPaging
{
    public interface IGroupPagingContext
    {
        List<Goods> Goodies { get; set; }
    }
}
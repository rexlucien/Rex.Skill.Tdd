using System.Collections.Generic;

namespace Rex.Skill.Tdd.GroupPaging
{
    public interface IGroupPagingService
    {
        IEnumerable<int> SumGoods(GroupPagingType groupPagingType, int groupingCount);
    }
}
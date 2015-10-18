using System.Collections.Generic;

namespace Rex.Skill.Tdd.GroupPaging
{
    public interface IGroupPagingService
    {
        IEnumerable<int> SumGoodsCost(int groupingCount);

        IEnumerable<decimal> SumGoodsRevenue(int groupingCount);
    }
}
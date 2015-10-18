using System.Collections.Generic;
using System.Linq;

namespace Rex.Skill.Tdd.GroupPaging
{
    public class GroupPagingService : IGroupPagingService
    {
        private readonly IGroupPagingContext _context;

        public GroupPagingService(IGroupPagingContext context)
        {
            _context = context;
        }

        public IEnumerable<int> SumGoods(GroupPagingType groupPagingType, int groupingCount)
        {
            switch (groupPagingType)
            {
                case GroupPagingType.Cost:
                    return SumGoodsCost(groupingCount);

                case GroupPagingType.Revenue:
                    return SumGoodsRevenue(groupingCount);

                default:
                    throw new System.NotImplementedException();
            }
        }

        private IEnumerable<int> SumGoodsCost(int groupingCount)
        {
            List<Goods> source = _context.Goodies.ToList();

            List<int> result = new List<int>();

            int len = source.Count / groupingCount + 1;

            for (int i = 0; i < len; i++)
            {
                int sum = source.Skip(i * groupingCount).Take(groupingCount).Sum(g => g.Cost);
                result.Add(sum);
            }

            return result;
        }

        private IEnumerable<int> SumGoodsRevenue(int groupingCount)
        {
            List<Goods> source = _context.Goodies.ToList();

            List<int> result = new List<int>();

            int len = source.Count / groupingCount + 1;

            for (int i = 0; i < len; i++)
            {
                int sum = source.Skip(i * groupingCount).Take(groupingCount).Sum(g => g.Revenue);
                result.Add(sum);
            }

            return result;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Rex.Skill.Tdd.GroupPaging
{
    public class GroupPagingService : IGroupPagingService
    {
        public GroupPagingService(IGroupPagingContext context)
        {
            Goods = context.Goodies.ToList();
        }

        private List<Goods> Goods { get; }

        /// <summary>
        /// Sum Goods
        /// </summary>
        /// <param name="groupPagingType"></param>
        /// <param name="groupingCount"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sum By Cost
        /// </summary>
        /// <param name="groupingCount"></param>
        /// <returns></returns>
        private IEnumerable<int> SumGoodsCost(int groupingCount)
        {
            int len = Goods.Count / groupingCount + 1;

            for (int i = 0; i < len; i++)
            {
                int sum = Goods.Skip(i * groupingCount).Take(groupingCount).Sum(g => g.Cost);
                yield return sum;
            }
        }

        /// <summary>
        /// Sum By Revenue
        /// </summary>
        /// <param name="groupingCount"></param>
        /// <returns></returns>
        private IEnumerable<int> SumGoodsRevenue(int groupingCount)
        {
            int len = Goods.Count / groupingCount + 1;

            for (int i = 0; i < len; i++)
            {
                int sum = Goods.Skip(i * groupingCount).Take(groupingCount).Sum(g => g.Revenue);
                yield return sum;
            }
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Rex.Skill.Tdd.GroupPaging;
using System.Collections.Generic;
using System.Linq;

namespace Rex.Skill.Tdd.Tests.GroupPaging
{
    [TestClass]
    public class GroupPagingServiceTests
    {
        // target 這個命名建議給測試目標用，如果是 List<Godds>, 建議就命成 goods 即可
        private List<Goods> _target;

        [TestInitialize]
        public void Init()
        {
            _target = new List<Goods>()
            {
                // 建議不要使用多參數的 constructor, 因為這個 homework 是要練習怎麼用 test case 來描述需求跟 context
                // 建議直接使用 property setter, 例如：new Goods {Id=1, Cost=1, Revenue=11, SellPrice=21}，原因是讓看的人一目了然
                new Goods( 1,  1, 11 , 21),
                new Goods( 2,  2, 12 , 22),
                new Goods( 3,  3, 13 , 23),
                new Goods( 4,  4, 14 , 24),
                new Goods( 5,  5, 15 , 25),
                new Goods( 6,  6, 16 , 26),
                new Goods( 7,  7, 17 , 27),
                new Goods( 8,  8, 18 , 28),
                new Goods( 9,  9, 19 , 29),
                new Goods(10, 10, 20 , 30),
                new Goods(11, 11, 21 , 31),
            };
        }

        [TestCleanup]
        public void Cleanup()
        {
            _target = null;
        }

        [TestMethod]
        public void SumGoodsCostTest_3筆一組_取Cost總和()
        {
            List<int> expected = new List<int>() { 6, 15, 24, 21 };
            
            IGroupPagingContext context = Substitute.For<IGroupPagingContext>();
            context.Goodies.Returns(_target);
            
            // 既然是測試 GroupPagingService，建議宣告的部分就不要用 IGroupPagingService，在所有的單元測試中，測試目標的宣告都不需要用 interface, 因為我要測的就是測試目標，而不是介面。
            IGroupPagingService service = new GroupPagingService(context);
            
            // SumGoodsCost(int pageSize)的方法比較沒有彈性，需求是希望用同一個方法，就可以讓呼叫端決定這一次要「幾筆一組」，「取哪個欄位的總和」
            List<int> actual = service.SumGoodsCost(3).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SumGoodsRevenueTest_4筆一組_取Revenue總和()
        {
            List<decimal> expected = new List<decimal>() { 50, 66, 60 };

            IGroupPagingContext context = Substitute.For<IGroupPagingContext>();
            context.Goodies.Returns(_target);

            IGroupPagingService service = new GroupPagingService(context);
            List<decimal> actual = service.SumGoodsRevenue(4).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

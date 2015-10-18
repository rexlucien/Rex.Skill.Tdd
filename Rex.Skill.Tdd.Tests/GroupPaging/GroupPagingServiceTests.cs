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
        private List<Goods> _target;

        [TestInitialize]
        public void Init()
        {
            _target = new List<Goods>()
            {
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

            IGroupPagingService service = new GroupPagingService(context);
            List<int> actual = service.SumGoodsCost(3).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SunGoodsRevenueTest_4筆一組_取Revenue總和()
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
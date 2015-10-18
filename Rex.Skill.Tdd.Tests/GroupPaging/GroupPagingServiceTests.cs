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
        private List<Goods> _goods;

        [TestInitialize]
        public void Init()
        {
            _goods = new List<Goods>()
            {
                new Goods {Id =  1, Cost= 1, Revenue = 11, SellPrice = 21},
                new Goods {Id =  2, Cost= 2, Revenue = 12, SellPrice = 22},
                new Goods {Id =  3, Cost= 3, Revenue = 13, SellPrice = 23},
                new Goods {Id =  4, Cost= 4, Revenue = 14, SellPrice = 24},
                new Goods {Id =  5, Cost= 5, Revenue = 15, SellPrice = 25},
                new Goods {Id =  6, Cost= 6, Revenue = 16, SellPrice = 26},
                new Goods {Id =  7, Cost= 7, Revenue = 17, SellPrice = 27},
                new Goods {Id =  8, Cost= 8, Revenue = 18, SellPrice = 28},
                new Goods {Id =  9, Cost= 9, Revenue = 19, SellPrice = 29},
                new Goods {Id = 10, Cost=10, Revenue = 20, SellPrice = 30},
                new Goods {Id = 11, Cost=11, Revenue = 21, SellPrice = 31},
            };
        }

        [TestCleanup]
        public void Cleanup()
        {
            _goods = null;
        }

        [TestMethod]
        public void SumGoodsCostTest_3筆一組_取Cost總和()
        {
            List<int> expected = new List<int> { 6, 15, 24, 21 };

            IGroupPagingContext context = Substitute.For<IGroupPagingContext>();
            context.Goodies.Returns(_goods);

            GroupPagingService service = new GroupPagingService(context);

            List<int> actual = service.SumGoods(GroupPagingType.Cost, 3).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SumGoodsRevenueTest_4筆一組_取Revenue總和()
        {
            List<int> expected = new List<int> { 50, 66, 60 };

            IGroupPagingContext context = Substitute.For<IGroupPagingContext>();
            context.Goodies.Returns(_goods);

            GroupPagingService service = new GroupPagingService(context);

            List<int> actual = service.SumGoods(GroupPagingType.Revenue, 4).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
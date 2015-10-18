using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Rex.Skill.Tdd.Authentication;



namespace Rex.Skill.Tdd.Tests.Authentication
{
    [TestClass]
    public class AuthenticationServiceTests
    {

        [TestMethod]
        public void IsValidTest()
        {
            IProfile mockProfileDao = Substitute.For<IProfile>();
            mockProfileDao.GetPassword("joey").Returns("91");

            IToken mockRsaTokenDao = Substitute.For<IToken>();
            mockRsaTokenDao.GetRandom("").ReturnsForAnyArgs("000000");

            AuthenticationService target = new AuthenticationService(mockProfileDao, mockRsaTokenDao);

            bool actual = target.IsValid("joey", "91000000");

            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void LogReceivedTest()
        {
            IProfile profile = Substitute.For<IProfile>();
            profile.GetPassword("Joey").Returns("91");

            IToken tokenDao = Substitute.For<IToken>();
            tokenDao.GetRandom("Joey").Returns("abc");

            ILog log = Substitute.For<ILog>();

            AuthenticationService target = new AuthenticationService(profile, tokenDao, log);

            bool actual = target.IsValid("Joey", "Worng PassWord");

            Assert.IsFalse(actual);

            log.ReceivedWithAnyArgs();

            //log.Received(1).Save(Arg.Is<string>(x => x.Contains("Joey")));
        }
    }
}
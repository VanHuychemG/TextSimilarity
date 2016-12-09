using NUnit.Framework;
using TextSimilarity.Common.Extensions.String;

namespace TextSimilarity.Common.Tests.Extensions.String
{
    [TestFixture]
    public class WordCountExtensionTests
    {
        [Test]
        public void WordCountTest()
        {
            //Arrange
            const string text = "The quickest way to double your money is to fold it over and put it back in your pocket";

            //Act
            var result = text.WordCount();

            //Assert
            Assert.AreEqual(16, result.Count);
        }
    }
}
using NUnit.Framework;
using TextSimilarity.Common.Extensions.String;

namespace TextSimilarity.Common.Tests.Extensions.String
{
    [TestFixture]
    public class ShinglesExtensionTests
    {
        [Test]
        public void CharacterShinglesTest()
        {
            //Arrange
            const string text = "The quickest way to double your money is to fold it over and put it back in your pocket";

            //Act
            var result = text.CharacterShingles();

            //Assert
            Assert.AreEqual(62, result.Count);
        }

        [Test]
        public void WordShinglesTest()
        {
            //Arrange
            const string text = "The quickest way to double your money is to fold it over and put it back in your pocket";

            //Act
            var result = text.WordShingles();

            //Assert
            Assert.AreEqual(18, result.Count);
        }
    }
}
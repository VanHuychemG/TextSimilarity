using NUnit.Framework;
using TextSimilarity.Common.Extensions.String;

namespace TextSimilarity.Common.Tests.Extensions.String
{
    [TestFixture]
    public class CharacterCountExtensionTests
    {
        [Test]
        public void CharacterCountTest()
        {
            //Arrange
            const string text = "The quickest way to double your money is to fold it over and put it back in your pocket";

            //Act
            var result = text.CharacterCount();

            //Assert
            Assert.AreEqual(24, result.Count);
        }
    }
}
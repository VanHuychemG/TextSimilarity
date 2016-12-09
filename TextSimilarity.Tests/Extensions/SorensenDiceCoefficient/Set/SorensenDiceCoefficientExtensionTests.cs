using NUnit.Framework;
using TextSimilarity.Common.Extensions.String;
using TextSimilarity.Extensions.SorensenDiceCoefficient.Set;

namespace TextSimilarity.Tests.Extensions.SorensenDiceCoefficient.Set
{
    [TestFixture]
    public class SorensenDiceCoefficientExtensionTests
    {
        [Test]
        public void GivenTwoSimilarStrings_WhenICalculateDiceCoeffiecient_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "The fastest way to double your money is to fold it over and put it back in your pocket";
            //Act
            var result = text1.CharacterShingles().SorensenDiceCoefficient(text2.CharacterShingles());
            //Assert
            Assert.AreEqual(0.93, result, 0.01);
        }

        [Test]
        public void GivenTwoDistinctStrings_WhenICalculateDiceCoeffiecient_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "Even if you’re on the right track, you’ll get run over if you just sit there";
            //Act
            var result = text1.CharacterShingles().SorensenDiceCoefficient(text2.CharacterShingles());
            //Assert
            Assert.AreEqual(0.32, result, 0.01);
        }
    }
}
using NUnit.Framework;
using TextSimilarity.Common.Extensions.String;
using TextSimilarity.Extensions.OverlapCoefficient.Set;

namespace TextSimilarity.Tests.Extensions.OverlapCoefficient.Set
{
    [TestFixture]
    public class OverlapCoefficientExtensionTests
    {
        [Test]
        public void GivenTwoSimilarStrings_WhenICalculateOverlapCoeffiecient_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "The fastest way to double your money is to fold it over and put it back in your pocket";
            //Act
            var result = text1.CharacterShingles().OverlapCoefficient(text2.CharacterShingles());
            //Assert
            Assert.AreEqual(0.95, result, 0.01);
        }

        [Test]
        public void GivenTwoSimilarStringsWhereOneIsASubsetOfTheOther_WhenICalculateOverlapCoeffiecient_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "The quickest way to double your money is to put them back in your pocket";
            //Act
            var result = text1.CharacterShingles().OverlapCoefficient(text2.CharacterShingles());
            //Assert
            Assert.AreEqual(0.96, result, 0.01);
        }

        [Test]
        public void GivenTwoDistinctStrings_WhenICalculateOverlapCoeffiecient_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "Even if you’re on the right track, you’ll get run over if you just sit there";
            //Act
            var result = text1.CharacterShingles().OverlapCoefficient(text2.CharacterShingles());
            //Assert
            Assert.AreEqual(0.4, result, 0.01);
        }
    }
}
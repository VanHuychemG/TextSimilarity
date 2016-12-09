using NUnit.Framework;
using TextSimilarity.Common.Extensions.String;
using TextSimilarity.Extensions.Jaccard.Set;

namespace TextSimilarity.Tests.Extensions.Jaccard.Set
{
    [TestFixture]
    public class JaccardDistanceExtensionTests
    {
        [Test]
        public void GivenTwoSimilarStrings_WhenICalculateJaccardIndex_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "The fastest way to double your money is to fold it over and put it back in your pocket";
            //Act
            var result = text1.CharacterShingles().JaccardIndex(text2.CharacterShingles());
            //Assert
            Assert.AreEqual(0.89, result, 0.01);
        }

        [Test]
        public void GivenTwoSimilarStrings_WhenICalculateJaccardDistance_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "The fastest way to double your money is to fold it over and put it back in your pocket";
            //Act
            var result = text1.CharacterShingles().JaccardDistance(text2.CharacterShingles());
            //Assert
            Assert.AreEqual(0.11, result, 0.01);
        }


        [Test]
        public void GivenTwoDistinctStrings_WhenICalculateJaccardIndex_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "Even if you’re on the right track, you’ll get run over if you just sit there";
            //Act
            var result = text1.CharacterShingles().JaccardIndex(text2.CharacterShingles());
            //Assert
            Assert.AreEqual(0.21, result, 0.01);
        }

        [Test]
        public void GivenTwoDistinctStrings_WhenICalculateJaccardDistance_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "Even if you’re on the right track, you’ll get run over if you just sit there";
            //Act
            var result = text1.CharacterShingles().JaccardDistance(text2.CharacterShingles());
            //Assert
            Assert.AreEqual(0.78, result, 0.01);
        }
    }
}
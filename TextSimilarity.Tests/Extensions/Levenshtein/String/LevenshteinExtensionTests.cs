using System;

using NUnit.Framework;

using TextSimilarity.Extensions.Levenshtein.String;

namespace TextSimilarity.Tests.Extensions.Levenshtein.String
{
    [TestFixture]
    public class LevenshteinExtensionTests
    {
        [Test]
        public void GivenTwoSimilarStrings_WhenICalculateLevenshteinDistanceIndex_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "The fastest way to double your money is to fold it over and put it back in your pocket";
            //Act
            var levDis = text1.LevenshteinDistance(text2);
            var bigger = Math.Max(text1.Length, text2.Length);
            var pct = (double)(bigger - levDis) / bigger;
            //Assert
            Assert.AreEqual(5, levDis, 0.01);
        }

        [Test]
        public void GivenTwoSimilarStrings_WhenICalculateDamerauLevenshteinDistanceIndex_ThenIGetTheSimilarityIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "The fastest way to double your money is to fold it over and put it back in your pocket";
            //Act
            var levDis = text1.LevenshteinDistance(text2);
            var bigger = Math.Max(text1.Length, text2.Length);
            var pct = (double)(bigger - levDis) / bigger;
            //Assert
            Assert.AreEqual(5, levDis, 0.01);
        }
    }
}

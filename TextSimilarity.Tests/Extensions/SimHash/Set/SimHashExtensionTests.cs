using System;
using NUnit.Framework;

using TextSimilarity.Common.Extensions.String;
using TextSimilarity.Extensions.SimHash.Integer;
using TextSimilarity.Extensions.SimHash.Set;

namespace TextSimilarity.Tests.Extensions.SimHash.Set
{
    [TestFixture]
    public class SimHashExtensionTests
    {
        [Test]
        public void GivenTwoSimilarStrings_WhenICalculateTheSimHashWithWordShingles_ThenIGetTheCorrectIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "The best way to save your money is to fold it over and put it back in your pocket";
            //Act

            Console.WriteLine("text1: {0}", string.Join(",", text1.WordShingles()));
            Console.WriteLine("text1.SimHash: {0}", string.Join(",", text1.WordShingles().SimHash(x => x.GetHashCode())));

            Console.WriteLine("text2: {0}", string.Join(",", text2.WordShingles()));
            Console.WriteLine("text2.SimHash: {0}", string.Join(",", text2.WordShingles().SimHash(x => x.GetHashCode())));

            var result = text1.WordShingles()
                                .SimHash(x => x.GetHashCode())
                                .HammingDistance(text2.WordShingles()
                                                             .SimHash(x => x.GetHashCode()));
            //Assert
            Assert.AreEqual(4, result, 0.01);
        }

        [Test]
        public void GivenTwoDistinctStrings_WhenICalculateTheSimHashWithWordShingles_ThenIGetTheCorrectIndex()
        {
            //Arrange
            const string text1 = "The quickest way to double your money is to fold it over and put it back in your pocket";
            const string text2 = "Even if you’re on the right track, you’ll get run over if you just sit there";
            //Act
            var result = text1.WordShingles()
                                .SimHash(x => x.GetHashCode())
                                .HammingDistance(text2.WordShingles()
                                                             .SimHash(x => x.GetHashCode()));
            //Assert
            Assert.AreEqual(14, result);
        }


        [Test]
        public void GivenTwoSimilarStrings_WhenICalculateTheSimHashWithCharShingles_ThenIGetTheCorrectIndex()
        {
            //Arrange
            const string text1 = "the cat sat on the mat";
            const string text2 = "the cat sat on a mat";
            //Act
            var result = text1.CharacterShingles().SimHash(x => x.GetHashCode()).HammingDistance(text2.CharacterShingles().SimHash(x => x.GetHashCode()));
            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void GivenTwoDistinctStrings_WhenICalculateTheSimHashWithCharShingles_ThenIGetTheCorrectIndex()
        {
            //Arrange
            const string text1 = "the cat sat on the mat";
            const string text2 = "we all scream for ice cream";
            //Act
            var result = text1.CharacterShingles().SimHash(x => x.GetHashCode()).HammingDistance(text2.CharacterShingles().SimHash(x => x.GetHashCode()));
            //Assert
            Assert.AreEqual(3, result);
        }
    }
}
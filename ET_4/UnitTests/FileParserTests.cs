using System;
using System.IO;
using System.Text;

using ET_4_FileParser.Logics;
using Xunit;

namespace ET_4_UnitTests
{
    public class FileParserTests
    {
        [Fact]
        public void FindLines_EmptyFile_EmptyArr()
        {
            //arrange
            string[] lines = { };
            string fileText = String.Join("\n", lines);
            string target = "Match";

            MemoryStream stream = new MemoryStream(
                Encoding.Default.GetBytes(fileText));

            //act
            FileParser file = new FileParser();
            string[] actual = file.FindLines(
                new StreamReader(stream), target);

            //assert
            Assert.Empty(actual);
        }

        [Fact]
        public void FindLines_2Matches_Length2()
        {
            //arrange
            string[] lines = { "Match. Test string"
                 , "Match. Test string"
                 , "Without. Lorem"};
            string fileText = String.Join("\n", lines);
            string target = "Match";
            int expected = 2;

            MemoryStream stream = new MemoryStream(
                Encoding.Default.GetBytes(fileText));

            //act
            FileParser file = new FileParser();
            string[] actual = file.FindLines(
                new StreamReader(stream), target);

            //assert
            Assert.Equal(expected, actual.Length);
        }

        [Fact]
        public void FindLines_2Matches_FirstLineCorrect()
        {
            //arrange
            string[] lines = { "Match. Test string"
                 , "Match. Test string"
                 , "Without. Lorem"};
            string fileText = String.Join("\n", lines);
            string target = "Match";

            MemoryStream stream = new MemoryStream(
                Encoding.Default.GetBytes(fileText));

            //act
            FileParser file = new FileParser();
            string[] actual = file.FindLines(
                new StreamReader(stream), target);

            //assert
            Assert.Equal(lines[0], actual[0]);
        }

        [Fact]
        public void FindLines_2Matches_SecondLineCorrect()
        {
            //arrange
            string[] lines = { "Match. Test string"
                 , "Match. Lorem lipsum string"
                 , "Without. Lorem"};
            string fileText = String.Join("\n", lines);
            string target = "Match";

            MemoryStream stream = new MemoryStream(
                Encoding.Default.GetBytes(fileText));

            //act
            FileParser file = new FileParser();
            string[] actual = file.FindLines(
                new StreamReader(stream), target);

            //assert
            Assert.Equal(lines[1], actual[1]);
        }

    }
}

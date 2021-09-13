using LinqChallengesFivePack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LinqChallenge.Test
{
    [TestClass]
    public class LinqTests
    {
        [TestMethod]
        public void PlayerRosterJerseyCorrect()
        {
            var challenges = new LinqChallenges();
            List<string> results = new List<string>()
            {
                "1. Smith",
                "2. Robinson",
                "3. Saenz",
                "4. Cabanig",
                "5. Jefferson"
            };

            var sut = challenges.PlayerAssignJersey();

            CollectionAssert.AreEqual(results, sut);
        }

        [TestMethod]
        public void PlayersWithBirthdayAndAgeSorted()
        {
            var challenges = new LinqChallenges();
            List<Player> players = new List<Player>()
            {
                new Player(){ Name = "Jos Sagan", Birthday = new System.DateTime(1983, 4, 22)},
                new Player(){ Name = "James Hansen", Birthday = new System.DateTime(1983, 10, 5)},
                new Player(){ Name = "Mariah Davis", Birthday = new System.DateTime(1985, 09, 08)},
                new Player(){ Name = "Jeff Prosise", Birthday = new System.DateTime(1986, 04, 01)},
                new Player() {Name = "Hector Ramirez", Birthday = new System.DateTime(1991, 02, 12)},
                new Player(){ Name = "Ally Shaw", Birthday = new System.DateTime(1995, 12, 22)}
            };

            var sut = challenges.PlayerAgeSort();

            // without a custom comparer this was originally using Object.Equals which does not properly
            // compare the 2 player objects and was causing the test to fail.
            CollectionAssert.AreEqual(players, sut, new PlayerComparer());
        }

        [TestMethod]
        public void CalculateAlbumTrackLengthSeconds()
        {
            var challenges = new LinqChallenges();
            var sut = challenges.CalculateAlbumDurationSeconds();
            Assert.AreEqual(sut, 2303);
        }

        [TestMethod]
        public void CalcuateGridPoints()
        {
            var challenges = new LinqChallenges();
            var sut = challenges.CalculateMatrixPoints3x3();
            var gridpoints = new List<string>()
            {
                "0,0",
                "0,1",
                "0,2",
                "1,0",
                "1,1",
                "1,2",
                "2,0",
                "2,1",
                "2,2"
            };

            CollectionAssert.AreEqual(sut, gridpoints);
        }

        [TestMethod]
        public void GetRangesFromString()
        {
            var challenges = new LinqChallenges();
            var answer = new List<int>()
            {
                2, 5, 7, 8, 9, 10, 11, 17, 18
            };

            var sut = challenges.GetRangesFromString();
            CollectionAssert.AreEqual(answer, sut);
        }

        //[TestMethod]
        //public void EnsureLambdaLinqCalls()
        //{
        //    var file = CSharpSyntaxTree.ParseText(File.ReadAllText($"{ProjectSourcePath.Value}..\\LinqChallengesFivePack\\LinqChallenges.cs"));
        //    var methodBody = file.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().Where(m => m.Identifier.Text == "PlayerAssignJersey").Select(i => i.Body);
        //    var lambdaStatements = file.GetRoot().DescendantNodes().OfType<LambdaExpressionSyntax>();

        //    var statements = string.Join("", methodBody.Select(s => s.Statements.ToFullString()));
        //    Assert.IsTrue(statements.Contains("Split"));
        //}


    }
}

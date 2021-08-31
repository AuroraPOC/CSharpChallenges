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
                new Player(){ Name =  "Mariah Davis", Birthday = new System.DateTime(1985, 09, 08)},
                new Player(){ Name = "Jeff Prosise", Birthday = new System.DateTime(1986, 04, 01)},
                new Player(){ Name = "Ally Shaw", Birthday = new System.DateTime(1995, 12, 22)}
            };

            var sut = challenges.PlayerAgeSort();

            CollectionAssert.AreEqual(players, sut);
        }

        [TestMethod]
        public void CalculateAlbumTrackLengthSeconds()
        {
            var challenges = new LinqChallenges();
            var sut = challenges.CalculateAlbumDuration();
            Assert.AreEqual(sut, 100);
        }


    }
}

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
    }
}

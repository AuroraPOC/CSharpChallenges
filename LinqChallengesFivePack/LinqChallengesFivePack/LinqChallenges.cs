using System;
using System.Collections.Generic;

namespace LinqChallengesFivePack
{
    public class LinqChallenges
    {
        public List<string> PlayerAssignJersey()
        {
            var players = GetPlayerRoster();
            //Assign jersey numbers here.
            return new List<string>();
        }

        private List<string> GetPlayerRoster()
        {
            return new List<string>()
            {
                "Smith",
                "Robinson",
                "Saenz",
                "Cabanig",
                "Jefferson"
            };
        }


    }
}

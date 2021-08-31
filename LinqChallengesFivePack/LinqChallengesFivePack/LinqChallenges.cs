using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqChallengesFivePack
{
    public class LinqChallenges
    {
        public List<string> PlayerAssignJersey()
        {
            var players =  "Smith, Robinson, Saenz, Cabanig, Jefferson";
            int index = 0;
            //Assign jersey numbers here.

            return new List<string>();
            
        }


        public List<Player> PlayerAgeSort()
        {
            var players = "Jeff Prosise, 04/01/1986; Jos Sagan, 04/22/1983; Mariah Davis, 09/08/1985; Ally Shaw, 12/22/1995; Hector Ramirez, 02/12/1991; James Hansen, 10/05/1983";
            //Return list of players, sorted oldest to youngest
            return new List<Player>();
        }


        public int CalculateAlbumDurationSeconds()
        {
            string albumTrackLengths = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            //Calculate how long the album is, in seconds, given each track length
            return 0;
        }

    }

    public class Player
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}

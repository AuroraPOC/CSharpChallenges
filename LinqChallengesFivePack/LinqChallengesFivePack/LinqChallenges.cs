using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqChallengesFivePack
{
    public class LinqChallenges
    {
        //All these challenges are designed to be solved via Linq statements.  

        public List<string> PlayerAssignJersey()
        {
            var players =  "Smith, Robinson, Saenz, Cabanig, Jefferson";
            int index = 0;
            //Assign jersey numbers here.

            return new List<string>();
            
        }


        public List<Player> PlayerAgeSort()
        {
            //string represents a person and their date of birth
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

        public List<string> CalculateMatrixPoints3x3()
        {
            //Imagine a 3x3 grid, with points of x,y.
            //Return a string collection representing all the grid points, starting at 0,0 and going up, then right
            //Output should be: "0,0 0,1 0,2 1,0 1,1 1,2 2,0 2,1 2,2"
            return new List<string>();
        }

        public List<int> GetRangesFromString()
        {
            //Given the input, return a collection of integers with the ranges filled in
            //Solution should be: 2 5 7 8 9 10 11 17 18
            var input = "2,5,7-10,11,17-18";

            return new List<int>();
        }

    }

    public class Player
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqChallengesFivePack
{
    public class LinqChallenges
    {
        //All these challenges are designed to be solved via Linq statements.  
        //To qualify to win Linq must be used, otherwise they're too easy :)

        #region HINT
        //Some handy methods: String.Split(","), Enumerable.Range, Aggregate, SelectMany
        #endregion

        //Challenge: Given a string of player names give each player a jersey # starting at 1 and return back in a List i.e. "1. Smith", "2. Robinson" etc..
        public List<string> PlayerAssignJersey()
        {
            var players =  "Smith, Robinson, Saenz, Cabanig, Jefferson";
            var numberedPlayers = players.Split(',').Select((x, index) => $"{index+1}. {x.Trim()}").ToList();

            return numberedPlayers;
            
        }

        //Return list of Players, sorted oldest to youngest
        public List<Player> PlayerAgeSort()
        {
            var players = "Jeff Prosise, 04/01/1986; Jos Sagan, 04/22/1983; Mariah Davis, 09/08/1985; Ally Shaw, 12/22/1995; Hector Ramirez, 02/12/1991; James Hansen, 10/05/1983";
            var xPlayers = players.Split(';').Select(x => x.Split(',')).Select(x => new Player() { Name = x[0], Birthday = DateTime.Parse(x[1].Trim()) }).OrderBy(x => x.Birthday).ToList();
            return xPlayers;
        }

        //Calculate how long the album is, in seconds, given track lengths
        public double CalculateAlbumDurationSeconds()
        {
            string albumTrackLengths = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            var x = albumTrackLengths.Split(',').Select(x => x.Split(':')).Select(x => int.Parse(x[0]) * 60 + int.Parse(x[1])).Sum();
            return x;
        }


        //Imagine a 3x3 grid, with points of x,y.
        //Return a string collection representing all the grid points, starting at 0,0 and going up, then right
        //Output should be: "0,0" "0,1" "0,2" "1,0" "1,1" "1,2" "2,0" "2,1" "2,2"
        public List<string> CalculateMatrixPoints3x3()
        {
            
            return new List<string>();
        }

        //Given the input, return a collection of integers with the ranges filled in
        //Solution should be: 2, 5, 7, 8, 9, 10, 11, 17, 18
        public List<int> GetRangesFromString()
        {
            var input = "2,5,7-10,11,17-18";
            //var x = input.Split(',').Select(x => x.Contains('-')
            //? Enumerable.Range(int.Parse(x.Substring(0, x.IndexOf('-'))), int.Parse(x.Substring(x.IndexOf('-') + 1)) - int.Parse(x.Substring(0, x.IndexOf('-')))).Select(x=>x.ToString()).Aggregate((concat, str) => $"{concat},{str}")
            //: x
            //).Aggregate((concat, str) => $"{concat},{str}"); 

            var x = input.Split(',').Select(x => x.Split('-')).Select(x => Enumerable.Range(int.Parse(x[0]), x.Length == 1 ? 1 : int.Parse(x[1]) - int.Parse(x[0]) + 1)).SelectMany(x => x).ToList();      
                  
            return x;
        }

    }

    public class Player
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}

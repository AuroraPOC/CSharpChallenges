using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            var assignedPlayers = players.Split(@", ").ToList().Select((player, index) => $"{index + 1}. {player}").ToList();

            return assignedPlayers;
            
        }

        //Return list of Players, sorted oldest to youngest
        public List<Player> PlayerAgeSort()
        {
            var players = "Jeff Prosise, 04/01/1986; Jos Sagan, 04/22/1983; Mariah Davis, 09/08/1985; Ally Shaw, 12/22/1995; Hector Ramirez, 02/12/1991; James Hansen, 10/05/1983";
            var sortedPlayers = players.Split("; ").ToList().Select(x => { var playerData = x.Split(", "); return new Player() { Name = playerData[0], Birthday = DateTime.Parse(playerData[1]) }; }).OrderBy(player => player.Birthday).ToList();
            return sortedPlayers;
        }

        //Calculate how long the album is, in seconds, given track lengths
        public double CalculateAlbumDurationSeconds()
        {
            string albumTrackLengths = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            var totalLength = albumTrackLengths.Split(",").Select(duration => TimeSpan.ParseExact(duration,"m':'ss",null)).Aggregate(new TimeSpan(0), (total, next) => total += next).TotalSeconds;
            return totalLength;
        }


        //Imagine a 3x3 grid, with points of x,y.
        //Return a string collection representing all the grid points, starting at 0,0 and going up, then right
        //Output should be: "0,0" "0,1" "0,2" "1,0" "1,1" "1,2" "2,0" "2,1" "2,2"
        public List<string> CalculateMatrixPoints3x3()
        {
            var coords = Enumerable.Range(0, 3).Select(xmap => (X: xmap, Y: Enumerable.Range(0, 3))).SelectMany(coord => coord.Y, (coord, Y) => $"{coord.X},{Y}").ToList();
            return coords;
        }

        //Given the input, return a collection of integers with the ranges filled in
        //Solution should be: 2, 5, 7, 8, 9, 10, 11, 17, 18
        public List<int> GetRangesFromString()
        {  
            var input = "2,5,7-10,11,17-18";            
            var intList = input.Split(",").ToList().Select(x => { var range = x.Split("-").ToList().Select(x => int.Parse(x)); return Enumerable.Range(range.First(), range.Last() - range.First() + 1); }).SelectMany(x => x).ToList();
            return intList;
        }

    }

    public class Player
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public override bool Equals(object obj)
        {
            var player = obj as Player;
            if (player == null)
            {
                return false;
            }

            return player.Name == Name && player.Birthday == Birthday;
        }
    }
}

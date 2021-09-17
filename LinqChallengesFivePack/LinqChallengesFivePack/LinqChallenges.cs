using System;
using System.Collections.Generic;
using System.Globalization;
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

            var result = players.Split(", ").Select((player, index) => $"{index + 1}. {player}").ToList();

            return result;
        }

        //Return list of Players, sorted oldest to youngest
        public List<Player> PlayerAgeSort()
        {
            var players = "Jeff Prosise, 04/01/1986; Jos Sagan, 04/22/1983; Mariah Davis, 09/08/1985; Ally Shaw, 12/22/1995; Hector Ramirez, 02/12/1991; James Hansen, 10/05/1983";

            var result = 
                from tuple in players.Split("; ")
                let separatorIndex = tuple.IndexOf(',', StringComparison.Ordinal)
                select new Player
                {
                    Name = tuple[..separatorIndex],
                    Birthday = DateTime.Parse(tuple[(separatorIndex + 1)..], CultureInfo.InvariantCulture)
                }
                into player
                orderby player.Birthday
                select player;

            return result.ToList();
        }

        //Calculate how long the album is, in seconds, given track lengths
        public double CalculateAlbumDurationSeconds()
        {
            string albumTrackLengths = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";

            var times = 
                from tuple in albumTrackLengths.Split(',')
                let separatorIndex = tuple.IndexOf(':', StringComparison.Ordinal)
                let minutes = int.Parse(tuple[..separatorIndex])
                let seconds = int.Parse(tuple[(separatorIndex + 1)..])
                select (double)minutes * 60 + seconds;

            return times.Sum();
        }


        //Imagine a 3x3 grid, with points of x,y.
        //Return a string collection representing all the grid points, starting at 0,0 and going up, then right
        //Output should be: "0,0" "0,1" "0,2" "1,0" "1,1" "1,2" "2,0" "2,1" "2,2"
        public List<string> CalculateMatrixPoints3x3()
        {
            var result =
                from x in Enumerable.Range(0, 3)
                from y in Enumerable.Range(0, 3)
                select $"{x},{y}";

            return result.ToList();
        }

        //Given the input, return a collection of integers with the ranges filled in
        //Solution should be: 2, 5, 7, 8, 9, 10, 11, 17, 18
        public List<int> GetRangesFromString()
        {  
            var input = "2,5,7-10,11,17-18";

            var pairs =
                from element in input.Split(',')
                let separatorIndex = element.IndexOf('-')
                let first = int.Parse(separatorIndex == -1 ? element : element[..separatorIndex])
                let last = separatorIndex == -1 ? (int?)null : int.Parse(element[(separatorIndex + 1)..])
                select last != null ? Enumerable.Range(first, last.Value - first + 1) : new[] { first };

            var result = pairs.SelectMany(x => x).ToList();

            return result;
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

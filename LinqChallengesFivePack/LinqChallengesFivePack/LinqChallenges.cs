using System;
using System.Collections.Generic;
using System.Linq;
// Submission for Tommy English
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
            var players = "Smith, Robinson, Saenz, Cabanig, Jefferson";
            var answer = players.Split(", ")
                .Select((n, i) => $"{i + 1}. {n}")
                .ToList();
            return answer;

        }

        //Return list of Players, sorted oldest to youngest
        public List<Player> PlayerAgeSort()
        {
            var players = "Jeff Prosise, 04/01/1986; Jos Sagan, 04/22/1983; Mariah Davis, 09/08/1985; Ally Shaw, 12/22/1995; Hector Ramirez, 02/12/1991; James Hansen, 10/05/1983";
            var answer = players.Split("; ")
                .Select(p => new Player { Name = p.Split(", ")[0], Birthday = DateTime.Parse(p.Split(", ")[1]) })
                .OrderBy(p => p.Birthday)
                .ToList();
            return answer;
        }

        //Calculate how long the album is, in seconds, given track lengths
        public double CalculateAlbumDurationSeconds()
        {
            string albumTrackLengths = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            var answer = albumTrackLengths.Split(',')
                .SelectMany(tl => tl.Split(':'))
                .Select((tt, i) => i % 2 == 0 ? double.Parse(tt) * 60 : double.Parse(tt))
                .Sum();
            return answer;
        }


        //Imagine a 3x3 grid, with points of x,y.
        //Return a string collection representing all the grid points, starting at 0,0 and going up, then right
        //Output should be: "0,0" "0,1" "0,2" "1,0" "1,1" "1,2" "2,0" "2,1" "2,2"
        public List<string> CalculateMatrixPoints3x3()
        {
            int n = 3; // 3 x 3;
            var answer = Enumerable.Range(0, n)
                .SelectMany(x => Enumerable.Range(0, n).Select(y => $"{x},{y}"))
                .ToList();
            return answer;
        }

        //Given the input, return a collection of integers with the ranges filled in
        //Solution should be: 2, 5, 7, 8, 9, 10, 11, 17, 18
        public List<int> GetRangesFromString()
        {
            var input = "2,5,7-10,11,17-18";
            var answer = input.Split(',')
                .SelectMany(i => i.Split('-').Length == 1 
                ? new List<int> { int.Parse(i) }
                : Enumerable.Range(int.Parse(i.Split('-')[0]), 1 + int.Parse(i.Split('-')[1]) - int.Parse(i.Split('-')[0])))
                .ToList();
            return answer;
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

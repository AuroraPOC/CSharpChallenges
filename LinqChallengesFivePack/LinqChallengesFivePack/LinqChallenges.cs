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
            var players = "Smith, Robinson, Saenz, Cabanig, Jefferson";

            return players
                .Split(",")
                .Select((player, index) => $"{index + 1}. {player.Trim()}")
                .ToList();
        }

        //Return list of Players, sorted oldest to youngest
        public List<Player> PlayerAgeSort()
        {
            var players = "Jeff Prosise, 04/01/1986; Jos Sagan, 04/22/1983; Mariah Davis, 09/08/1985; Ally Shaw, 12/22/1995; Hector Ramirez, 02/12/1991; James Hansen, 10/05/1983";

            return players
                .Split(";")
                .Select(playerInfo =>
                {
                    var details = playerInfo.Split(",");
                    return new Player { Name = details[0].Trim(), Birthday = DateTime.Parse(details[1]) };
                })
                .OrderBy(player => player.Birthday)
                .ToList();
        }

        //Calculate how long the album is, in seconds, given track lengths
        public double CalculateAlbumDurationSeconds()
        {
            string albumTrackLengths = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";

            return albumTrackLengths
                .Split(",")
                .Select(track => TimeSpan.Parse($"00:{track}"))
                .Sum(ts => ts.TotalSeconds);
        }


        //Imagine a 3x3 grid, with points of x,y.
        //Return a string collection representing all the grid points, starting at 0,0 and going up, then right
        //Output should be: "0,0" "0,1" "0,2" "1,0" "1,1" "1,2" "2,0" "2,1" "2,2"
        public List<string> CalculateMatrixPoints3x3()
        {

            var values = Enumerable.Range(0, 3)
                .Select(x => Enumerable.Range(0, 3).Select(y => new { Row = x, Column = y }))
                .Select(row => row.Select(p => $"{p.Row},{p.Column}"))
                .SelectMany(p => p);

            return values.ToList();
        }

        //Given the input, return a collection of integers with the ranges filled in
        //Solution should be: 2, 5, 7, 8, 9, 10, 11, 17, 18
        public List<int> GetRangesFromString()
        {
            var input = "2,5,7-10,11,17-18";
            return input.Split(",")
                .Select(r => r.Split("-"))
                .Select(range =>
                    range.Length == 1
                        ? new { Start = int.Parse(range[0]), End = int.Parse(range[0]) }
                        : new { Start = int.Parse(range[0]), End = int.Parse(range[1]) }
                )
                .Select(r => Enumerable.Range(r.Start, r.End - r.Start + 1))
                .SelectMany(r => r)
                .ToList();
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

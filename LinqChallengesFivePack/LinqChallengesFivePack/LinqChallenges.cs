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

            var playerList = players
                .Split(',')                                                     //Split the input to get each name
                .Select((x, index) => $"{index + 1}. {x.Trim()}")               //Add an index variable inside the lambda, return a formatted string
                .ToList();                                                      //Return a list

            return playerList;
            
        }

        //Return list of Players, sorted oldest to youngest
        public List<Player> PlayerAgeSort()
        {
            var players = "Jeff Prosise, 04/01/1986; Jos Sagan, 04/22/1983; Mariah Davis, 09/08/1985; Ally Shaw, 12/22/1995; Hector Ramirez, 02/12/1991; James Hansen, 10/05/1983";

            var playerList = players
                .Split(';')                                                                                                 //Split the input to get each name
                .Select(x => new Player() { Birthday = DateTime.Parse(x.Split(',')[1]), Name = x.Split(',')[0].Trim() })    //Parse each string into a Player object
                .OrderBy(x => x.Birthday)                                                                                   //Order by birthday to get oldest player first
                .ToList();                                                                                                  //Return a list

            return playerList;
        }

        //Calculate how long the album is, in seconds, given track lengths
        public double CalculateAlbumDurationSeconds()
        {
            string albumTrackLengths = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";

            var totalSeconds = albumTrackLengths
                .Split(',')                                                                         //Split the input to get each value
                .Select(x => Double.Parse(x.Split(':')[1]) + (Double.Parse(x.Split(':')[0]) * 60))  //Parse each value by adding the seconds to minutes*60
                .Sum();                                                                             //Sum up the seconds
            
            return totalSeconds;
        }


        //Imagine a 3x3 grid, with points of x,y.
        //Return a string collection representing all the grid points, starting at 0,0 and going up, then right
        //Output should be: "0,0" "0,1" "0,2" "1,0" "1,1" "1,2" "2,0" "2,1" "2,2"
        public List<string> CalculateMatrixPoints3x3()
        {
            var min = 0;
            var max = 2;

            var list = Enumerable.Range(min, max + 1).ToList();     //Create a list of the min - max values, 0-2

            var output = list
                .SelectMany(x => list.Select(y => $"{x},{y}"))      //Cross join the list to itself, return a formatted string
                .ToList();                                          //Return a list
                
            return output;
        }

        //Given the input, return a collection of integers with the ranges filled in
        //Solution should be: 2, 5, 7, 8, 9, 10, 11, 17, 18
        public List<int> GetRangesFromString()
        {  
            var input = "2,5,7-10,11,17-18";

            var output = input
                .Split(',')                                                                                     //Split the input to get each value
                .Select(x =>                                                                                    //Parse each value as follows...
                    {
                        var num = x.Split('-');                                                                 //Split the string to see if it's a discrete value or a range

                        if (num.Length == 1) { return new List<int>() { int.Parse(num[0]) }; }                  //For discreet values, return that number

                        return Enumerable.Range(int.Parse(num[0]), int.Parse(num[1]) - int.Parse(num[0]) + 1);  //For ranges, use Enumerable.Range to expand it
                    })
                .SelectMany(x => x)                                                                             //Select Many flattens the List of Lists into a single list
                .OrderBy(x => x)                                                                                //Ensure the numbers returned are in ascending order
                .ToList();                                                                                      //Return a list

            return output;
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

        public override int GetHashCode()
        {
            return (Name + Birthday.ToString()).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} / {Birthday}";
        }
    }
}

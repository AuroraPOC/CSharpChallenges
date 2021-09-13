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
			string players = "Smith, Robinson, Saenz, Cabanig, Jefferson";

			return players.Split(", ")
				.Select((p, index) => $"{index + 1}. {p}")
				.ToList();
		}

		//Return list of Players, sorted oldest to youngest
		public List<Player> PlayerAgeSort()
		{
			string players = "Jeff Prosise, 04/01/1986; Jos Sagan, 04/22/1983; Mariah Davis, 09/08/1985; Ally Shaw, 12/22/1995; Hector Ramirez, 02/12/1991; James Hansen, 10/05/1983";

			return players.Split("; ")
				.Select(p => new Player
				{
					Name = p.Split(", ")[0],
					Birthday = DateTime.Parse(p.Split(", ")[1])
				})
				.OrderBy(p => p.Birthday)
				.ToList();
		}

		//Calculate how long the album is, in seconds, given track lengths
		public double CalculateAlbumDurationSeconds()
		{
			string albumTrackLengths = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";

			return (from track in albumTrackLengths.Split(',')
					let indexOfColon = track.IndexOf(":")
					let seconds = Int32.Parse(track[(indexOfColon + 1)..])
					let minutes = Int32.Parse(track.Substring(0, indexOfColon))
					select (minutes * 60) + seconds).Sum();
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
			string input = "2,5,7-10,11,17-18";

			return (from range in input.Split(",")
					let containsDash = range.Contains("-")
					let indexOfDash = range.IndexOf("-")
					let start = containsDash ? Int32.Parse(range.Substring(0, indexOfDash)) : Int32.Parse(range)
					let end = containsDash ? Int32.Parse(range[(indexOfDash + 1)..]) : Int32.Parse(range)
					select Enumerable.Range(start, (start == end ? 1 : (end + 1) - start)))
					.SelectMany(n => n)
					.Distinct()
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

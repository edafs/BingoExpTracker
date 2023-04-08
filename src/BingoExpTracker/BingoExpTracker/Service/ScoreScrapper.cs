using System;
using System.Net;
using System.Reflection.PortableExecutable;
using BingoExpTracker.Models;

namespace BingoExpTracker.Service
{
	public class ScoreScrapper
	{
		public ScoreScrapper()
		{
		}

		/// <summary>
		///		Gets the highscore for a user.
		/// </summary>
		public async Task<UserHiscore> GetScore(string rsn)
		{
			UserHiscore score = new UserHiscore();

			using (var client = new HttpClient())
			{
				string uri = HighScoreUri(rsn);
				var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

				response.EnsureSuccessStatusCode();

				using (var stream = await response.Content.ReadAsStreamAsync())
				using (var streamReader = new StreamReader(stream))
				{
                    string firstLine = streamReader.ReadLine();
                    if (string.IsNullOrWhiteSpace(firstLine) || firstLine.Contains("404"))
                    {
                        throw new WebException(rsn + " not found!");
                    }

					score.User = rsn;
					score.Attack = ParseForExp(streamReader.ReadLine());
					score.Defence = ParseForExp(streamReader.ReadLine());
					score.Strength = ParseForExp(streamReader.ReadLine());
					score.Hitpoints = ParseForExp(streamReader.ReadLine());
					score.Ranged = ParseForExp(streamReader.ReadLine());
					score.Prayer = ParseForExp(streamReader.ReadLine());
					score.Magic = ParseForExp(streamReader.ReadLine());
					score.Cooking = ParseForExp(streamReader.ReadLine());
					score.Woodcutting = ParseForExp(streamReader.ReadLine());
					score.Fletching = ParseForExp(streamReader.ReadLine());
					score.Fishing = ParseForExp(streamReader.ReadLine());
					score.Firemaking = ParseForExp(streamReader.ReadLine());
					score.Crafting = ParseForExp(streamReader.ReadLine());
					score.Smithing = ParseForExp(streamReader.ReadLine());
					score.Mining = ParseForExp(streamReader.ReadLine());
					score.Herblore = ParseForExp(streamReader.ReadLine());
					score.Agility = ParseForExp(streamReader.ReadLine());
					score.Thieving = ParseForExp(streamReader.ReadLine());
					score.Slayer = ParseForExp(streamReader.ReadLine());
					score.Farming = ParseForExp(streamReader.ReadLine());
					score.Runecrafting = ParseForExp(streamReader.ReadLine());
					score.Hunter = ParseForExp(streamReader.ReadLine());
					score.Construction = ParseForExp(streamReader.ReadLine());

                }

				return score;
			}
		}

		private int ParseForExp(string stream)
		{
			if (string.IsNullOrWhiteSpace(stream))
			{
				string[] line = stream.Split(",");
				int.TryParse(line[2], out int exp);
				return exp;
			}

			return 0;
		}

		/// <summary>
		///		Construct the URI to get the user's highscore.
		/// </summary>
        private string HighScoreUri(string rsn) => string.Format(
                "http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player={0}"
                , rsn);
    }
}


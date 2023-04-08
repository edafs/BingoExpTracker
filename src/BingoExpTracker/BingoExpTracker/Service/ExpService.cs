using System;
using System.Linq;
using System.Text.Json;
using BingoExpTracker.Models;

namespace BingoExpTracker.Service
{
	public class ExpService
	{

		public readonly List<UserHiscore> _startUsersExp;
		public List<UserHiscore> _AllHiscores;

		public ExpService()
		{
			this._startUsersExp = LoadStartExp();
		}

		/// <summary>
		///		Gets the start exp of everyone.
		/// </summary>
		public List<UserHiscore> LoadStartExp()
		{
			List<UserHiscore> userScores = new List<UserHiscore>();
			using (StreamReader r = new StreamReader("Start.json"))
			{
				string json = r.ReadToEnd();
                UserHiscoreJson usersJson = JsonSerializer.Deserialize<UserHiscoreJson>(json);

				if (usersJson != null
					&& usersJson.Peeps != null
					&& usersJson.Peeps.Count > 1)
				{
					userScores = usersJson.Peeps;
				}
			}

			if (userScores == null)
			{
				return new List<UserHiscore>();
			}

			return userScores;
		}

		public async Task CumilativeExpTracker()
		{
			List<UserHiscore> userHiscores = new List<UserHiscore>();

			List<string> allUsers = _startUsersExp
				.Select(users => users.User)
				.ToList();

			foreach (string rsn in allUsers)
			{
				ScoreScrapper scrapper = new ScoreScrapper();
				UserHiscore hiscore = await scrapper.GetScore(rsn);

				if (hiscore != null)
				{
                    _AllHiscores.Add(hiscore);
				}
			}
		}
	}
}
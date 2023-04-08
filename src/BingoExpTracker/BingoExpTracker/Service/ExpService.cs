using System;
using System.Text.Json;
using BingoExpTracker.Models;

namespace BingoExpTracker.Service
{
	public class ExpService
	{
		public ExpService()
		{
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
	}
}
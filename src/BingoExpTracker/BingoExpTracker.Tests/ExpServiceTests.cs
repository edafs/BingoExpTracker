using System;
using BingoExpTracker.Models;
using BingoExpTracker.Service;

namespace BingoExpTracker.Tests;

public class ExpServiceTests
{
	[Fact]
	public async Task LoadStartExp()
	{
		ExpService expService = new ExpService();
		List<UserHiscore> users = expService.LoadStartExp();

		Assert.True(users.Count > 1);
	}
}


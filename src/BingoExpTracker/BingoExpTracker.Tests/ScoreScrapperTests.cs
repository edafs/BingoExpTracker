using System.Net;
using BingoExpTracker.Models;
using BingoExpTracker.Service;

namespace BingoExpTracker.Tests;

public class ScoreScrapperTests
{
    [Fact]
    public async Task UserNotFound_Test()
    {
        ScoreScrapper scrapper = new ScoreScrapper();

        await Assert.ThrowsAsync<WebException>(
            () => scrapper.GetScore("asdfasdfe392398r32i")
        );
    }

    [Fact]
    public async Task CanParse_E2E()
    {
        ScoreScrapper scrapper = new ScoreScrapper();
        UserHiscore score = await scrapper.GetScore("Ruijen");

        Assert.Equal("Ruijen", score.User);
        Assert.True(score.Attack > 13000000, "Wrong att");
        Assert.True(score.Defence > 13000000, "Wrong def");
        Assert.True(score.Strength > 13000000, "wrong str");
        Assert.True(score.Hitpoints > 24000000, "wrong hp");
        Assert.True(score.Ranged > 19000000, "wrong ranged");
        Assert.True(score.Prayer > 3700000, "wrong prayer");
        Assert.True(score.Magic > 14700000, "wrong magic");
        Assert.True(score.Cooking > 6700000, "wrong cooking");
        Assert.True(score.Woodcutting > 4400000, "wrong wc");
        Assert.True(score.Fletching > 5900000, "wrong fletching");
        Assert.True(score.Fishing > 7100000, "wrong fishing");
        Assert.True(score.Firemaking > 5200000, "wrong firemaking");
        Assert.True(score.Crafting > 3300000, "wrong crafting");
        Assert.True(score.Smithing > 4500000, "wrong smithing");
        Assert.True(score.Mining > 3300000, "wrong mining");
        Assert.True(score.Herblore > 5500000, "wrong herblore");
        Assert.True(score.Agility > 3600000, "wrong agility");
        Assert.True(score.Thieving > 6100000, "wrong theiving");
        Assert.True(score.Slayer > 16000000, "wrong slayer");
        Assert.True(score.Farming > 13000000, "wrong farming");
        Assert.True(score.Runecrafting > 3900000, "wrong rc");
        Assert.True(score.Hunter > 1700000, "wrong hunter");
        Assert.True(score.Construction > 3700000, "wrong construction");
    }
}
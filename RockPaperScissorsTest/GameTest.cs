using RockPaperScissors;

namespace RockPaperScissorsTest;

[TestClass]
public class GameTest
{
    [TestMethod]
    public void Game_TestSetupCorrectly()
    {
        // Arrange
        var winMatchups = new Dictionary<Choice, Choice[]>
        {
            { Choice.Rock, [Choice.Scissors, Choice.Lizard] },
            { Choice.Paper, [Choice.Rock, Choice.Spock] },
        };

        Game game = new Game(winMatchups);

        // Act 

        // Assert
        Assert.AreEqual(0, game.PlayerWins);
        Assert.AreEqual(0, game.ComputerWins);
        Assert.AreEqual(1, game.CurrentRound);
    }

    [TestMethod]
    public void Game_PlayRound_PlayerWins()
    {
        // Arrange
        var winMatchups = new Dictionary<Choice, Choice[]>
        {
            { Choice.Rock, [Choice.Scissors, Choice.Lizard] },
            { Choice.Paper, [Choice.Rock, Choice.Spock] },
        };

        Game game = new Game(winMatchups);

        // Act 
        game.PlayRound(Choice.Paper, Choice.Rock);

        // Assert
        Assert.AreEqual(1, game.PlayerWins);
        Assert.AreEqual(0, game.ComputerWins);
        Assert.AreEqual(2, game.CurrentRound);
    }

    [TestMethod]
    public void Game_PlayRound_ComputerWins()
    {
        // Arrange
        var winMatchups = new Dictionary<Choice, Choice[]>
        {
            { Choice.Rock, [Choice.Scissors, Choice.Lizard] },
            { Choice.Paper, [Choice.Rock, Choice.Spock] },
        };

        Game game = new Game(winMatchups);

        // Act 
        game.PlayRound(Choice.Rock, Choice.Paper);

        // Assert
        Assert.AreEqual(0, game.PlayerWins);
        Assert.AreEqual(1, game.ComputerWins);
        Assert.AreEqual(2, game.CurrentRound);
    }

    [TestMethod]
    public void Game_PlayRound_Tie()
    {
        // Arrange
        var winMatchups = new Dictionary<Choice, Choice[]>
        {
            { Choice.Rock, [Choice.Scissors, Choice.Lizard] },
            { Choice.Paper, [Choice.Rock, Choice.Spock] },
        };

        Game game = new Game(winMatchups);

        // Act 
        game.PlayRound(Choice.Rock, Choice.Rock);

        // Assert
        Assert.AreEqual(0, game.PlayerWins);
        Assert.AreEqual(0, game.ComputerWins);
        Assert.AreEqual(2, game.CurrentRound);
    }

    [TestMethod]
    public void Game_PlayRound_HasWinner()
    {
        // Arrange
        var winMatchups = new Dictionary<Choice, Choice[]>
        {
            { Choice.Rock, [Choice.Scissors, Choice.Lizard] },
            { Choice.Paper, [Choice.Rock, Choice.Spock] },
        };

        Game game = new Game(winMatchups);

        // Act 
        game.PlayRound(Choice.Rock, Choice.Paper);
        game.PlayRound(Choice.Rock, Choice.Paper);
        game.PlayRound(Choice.Rock, Choice.Paper);

        // Assert
        Assert.IsTrue(game.HasWinner());
    }
}

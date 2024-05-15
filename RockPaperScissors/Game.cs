namespace RockPaperScissors;

public enum Choice
{
    Rock = 0,
    Paper,
    Scissors,
    Lizard,
    Spock
}

public class Game
{
    private readonly Dictionary<Choice, Choice[]> _winMatchups;

    public Game(Dictionary<Choice, Choice[]> winMatchups)
    {
        _winMatchups = winMatchups;
    }

    public int CurrentRound { get; private set; } = 1;
    public int PlayerWins { get; private set; }
    public int ComputerWins { get; private set; }

    public void PlayRound(Choice playerChoice, Choice computerChoice)
    {
        if (_winMatchups.ContainsKey(playerChoice) && _winMatchups[playerChoice].Contains(computerChoice))
        {
            Console.WriteLine($"{playerChoice} beats {computerChoice} so you win this round!");
            PlayerWins++;
        }
        else if (_winMatchups.ContainsKey(computerChoice) && _winMatchups[computerChoice].Contains(playerChoice))
        {
            Console.WriteLine($"{computerChoice} beats {playerChoice} so the computer wins this round.");
            ComputerWins++;
        }
        else
        {
            Console.WriteLine("This round was a tie: no points awarded.");
        }
        CurrentRound++;
    }

    public bool HasWinner()
    {
        /* Assuming Best of 5 for now */
        return PlayerWins >= 3 || ComputerWins >= 3;
    }

    public IList<Choice> GetChoices()
    {
        return _winMatchups.Keys.ToList();
    }
}

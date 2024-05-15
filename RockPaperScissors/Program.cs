namespace RockPaperScissors;

internal class Program
{
    static void Main(string[] args)
    {
        var standardMatchups = new Dictionary<Choice, Choice[]>
        {
            { Choice.Rock, [Choice.Scissors] },
            { Choice.Paper, [Choice.Rock] },
            { Choice.Scissors, [Choice.Paper] },
        };

        var lizardSpockMatchups = new Dictionary<Choice, Choice[]>
        {
            { Choice.Rock, [Choice.Scissors, Choice.Lizard] },
            { Choice.Paper, [Choice.Rock, Choice.Spock] },
            { Choice.Scissors, [Choice.Paper, Choice.Lizard] },
            { Choice.Lizard, [Choice.Paper, Choice.Spock] },
            { Choice.Spock, [Choice.Rock, Choice.Scissors] }
        };

        Game game = new Game(lizardSpockMatchups);

        Console.WriteLine("Welcome to Rock Paper Scissors");
        Console.WriteLine("You are playing a Best of 5 against the computer.");

        IList<Choice> choices = game.GetChoices();

        while (!game.HasWinner())
        {
            NextScreen();

            Console.WriteLine($"Best of 5 | Round {game.CurrentRound} | {game.PlayerWins}-{game.ComputerWins}");
            Console.WriteLine("Please choose an option from below.");
            for (int i = 0; i < choices.Count; i++)
            {
                Choice choice = choices[i];
                Console.WriteLine($"{i + 1}. {choice}");
            }

            string? selection = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(selection) || !int.TryParse(selection, out int result))
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }

            if (result <= 0 || result > choices.Count)
            {
                Console.WriteLine("Not a valid option. Try again.");
                continue;
            }

            Choice playerChoice = choices[result - 1];
            Choice computerChoice = choices[Random.Shared.Next(choices.Count)];

            Console.WriteLine($"\nYou chose {playerChoice} and the computer chose {computerChoice}");

            game.PlayRound(playerChoice, computerChoice);
        }

        Console.WriteLine();
        if (game.PlayerWins > game.ComputerWins)
        {
            Console.WriteLine("Congratulations! You won this game.");
        }
        else
        {
            Console.WriteLine("You lost. Better luck next time.");
        }
    }

    static void NextScreen()
    {
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }
}

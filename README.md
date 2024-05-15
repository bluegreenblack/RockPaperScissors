## Rock Paper Scissors Technical Test

Requires .NET 8 to build.

To build `dotnet build`

To run use `dotnet run --project RockPaperScissors`

To run tests use `dotnet test`

### Design and assumptions made.

Choose mappings for calculating matchups - more flexible for both standard and lizard spock game modes.

Chose a best of 5 game mode.

### Possible further work

Abstract the opponent choice strategy into an interface class
e.g. RandomChoiceStrategy or PreviousMoveStrategy


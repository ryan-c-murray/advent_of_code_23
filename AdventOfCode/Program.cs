// See https://aka.ms/new-console-template for more information


using AdventOfCode;


const string DayRunner="DayTwo";

int answer;

switch (DayRunner) 
{
    case "DayOne":
        DayOne dayOne = new();
        answer= dayOne.GetAnswer();
        break;
    case "DayTwo":
        DayTwo dayTwo = new();
        answer = dayTwo.GetAnswer();
        break;
    case "DayThree":
        DayThree dayThree = new();

        break;
}

Console.WriteLine(answer);






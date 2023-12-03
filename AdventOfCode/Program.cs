// See https://aka.ms/new-console-template for more information


using AdventOfCode;


const string DayRunner="DayTwo";

int answer;

switch (DayRunner) 
{
    case "DayOne":
        DayOne dayOne = new DayOne();
        answer= dayOne.GetAnswer();
        break;
    case "DayTwo":
        DayTwo dayTwo = new DayTwo();
        answer = dayTwo.GetAnswer();
        break;
    case "DayThree":
        DayThree dayThree = new DayThree();
}

Console.WriteLine(answer);






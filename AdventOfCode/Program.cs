// See https://aka.ms/new-console-template for more information


using AdventOfCode.Day1;
using AdventOfCode.Day2;

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
}

Console.WriteLine(answer);






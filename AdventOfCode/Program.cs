// See https://aka.ms/new-console-template for more information


using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;


const string DayRunner="DayThree";

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
        answer = 00;
        break;
}

Console.WriteLine(answer);






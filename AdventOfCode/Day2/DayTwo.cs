using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day2
{
    public class DayTwo
    {      
        public Dictionary<string,List<Dictionary<string,int>>> InputData = new();


        public DayTwo()
        {
            DayTwoInputParse inputParser = new DayTwoInputParse();
            InputData = inputParser.GetInput();

            Console.WriteLine("done");
        }

    }
}
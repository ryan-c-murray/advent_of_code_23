using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3
{
    public class DayThreeInputParse
    {

        const string InputPath = "C:\\Users\\rcmur\\source\\repos\\AdventOfCode\\AdventOfCode\\Day3\\Day3PuzzleInput.txt";

        public readonly List<string> InputParsedData;

        public DayThreeInputParse()
        {
            InputParsedData = ParseInputFile();
        }

        private static List<string> ParseInputFile()
        {
            List<string> inputL = new();

            StreamReader streamReader = new(InputPath);

            string fileLine;

            while((fileLine = streamReader.ReadLine())!= null)
            {
                inputL.Add(fileLine);
            }

            return inputL;
        }
    }
}

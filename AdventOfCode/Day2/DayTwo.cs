using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day2
{
    public class DayTwo
    {      
        public Dictionary<string,List<Dictionary<string,int>>> InputData = new();

        public Dictionary<string,Dictionary<string,int>> SumData = new();


        public DayTwo()
        {
            DayTwoInputParse inputParser = new DayTwoInputParse();
            InputData = inputParser.GetInput();

            SumData = getSumData(InputData);

            Console.WriteLine("done");
        }

        private Dictionary<string,Dictionary<string,int>> getSumData(Dictionary<string,List<Dictionary<string,int>>> m_inputData)
        {
            Dictionary<string,Dictionary<string,int>> sumData = new();

            foreach (var gamePair in m_inputData)
            {
                sumData[gamePair.Key] = addList(gamePair.Value);
            }
            
            return sumData;
        }

        private Dictionary<string,int> addList(List<Dictionary<string,int>> roundList)
        {
            Dictionary<string,int> roundSum = new()
            {
                {"red",0},
                {"green",0},
                {"blue",0}
            };
            foreach (Dictionary<string,int> round in roundList)
            {
                foreach (var colorDictPair in round)
                {
                    roundSum[colorDictPair.Key] += colorDictPair.Value;
                }
            }

            return roundSum;
        }
    }
}
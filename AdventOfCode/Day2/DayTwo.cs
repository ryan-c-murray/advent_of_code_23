using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day2
{
    public class DayTwo
    {      
        public Dictionary<string,List<Dictionary<string,int>>> InputData = new();

        public Dictionary<string,Dictionary<string,int>> SumData = new();

        public List<int> ValidGames = new();

        public Dictionary<string,int> puzzleDict = new()
        {
            {"red",12},
            {"green",13},
            {"blue",14}
        };


        public DayTwo()
        {
            DayTwoInputParse inputParser = new DayTwoInputParse();
            InputData = inputParser.GetInput();

            SumData = getSumData(InputData);

            ValidGames = getValidGames();



            Console.WriteLine("done");
        }

        public int GetAnswer()
        {
            return ValidGames.Sum();
        }
        private List<int> getValidGames()
        {
            List<int> validGames = new();

            foreach (var gameResults in InputData)
            {
                if (gameIsValid(gameResults.Value))
                {
                    validGames.Add(int.Parse(gameResults.Key));
                }   
            }

            return validGames;
        }

        private bool gameIsValid(List<Dictionary<string,int>> rounds)
        {

            foreach (var round in rounds)
            {
                if (round["red"] >puzzleDict["red"]) { return false; }
                
                if (round["blue"] > puzzleDict["blue"]) { return false; }
                
                if (round["green"] > puzzleDict["green"]) { return false; }
            }
            
            return true;
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
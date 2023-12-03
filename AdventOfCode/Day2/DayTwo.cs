using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    public class DayTwo
    {      
        public Dictionary<string,List<Dictionary<string,int>>> InputData = new();

        public Dictionary<string,Dictionary<string,int>> MaxData = new();

        public List<int> ValidGames = new();

        public List<int> CubedGames = new();

        public Dictionary<string,int> puzzleDict = new()
        {
            {"red",12},
            {"green",13},
            {"blue",14}
        };


        public DayTwo()
        {
            DayTwoInputParse inputParser = new();
            InputData = DayTwoInputParse.GetInput();

            MaxData = GetMaxData(InputData);

            ValidGames = GetValidGames();

            CubedGames = CubeMaxGames();

            Console.WriteLine("done");
        }

        public int GetAnswer()
        {
            return CubedGames.Sum();
        }

        private List<int> CubeMaxGames()
        {
            List<int> cubedGameValues = new();
            
            foreach (var keyValuePair in MaxData)
            {
                Dictionary<string,int> gameResult = keyValuePair.Value;

                cubedGameValues.Add((gameResult["red"] * gameResult["blue"] * gameResult["green"]));

            } 

            return cubedGameValues;
        }

        private List<int> GetValidGames()
        {
            List<int> validGames = new();

            foreach (var gameResults in InputData)
            {
                if (GameIsValid(gameResults.Value))
                {
                    validGames.Add(int.Parse(gameResults.Key));
                }   
            }

            return validGames;
        }

        private bool GameIsValid(List<Dictionary<string, int>> rounds)
        {
            foreach (var round in rounds)
            {
                if (round["red"] >puzzleDict["red"]) { return false; }
                
                if (round["blue"] > puzzleDict["blue"]) { return false; }
                
                if (round["green"] > puzzleDict["green"]) { return false; }
            }
            
            return true;
        }

        private static Dictionary<string, Dictionary<string, int>> GetMaxData(Dictionary<string, List<Dictionary<string, int>>> m_inputData)
        {
            Dictionary<string,Dictionary<string,int>> sumData = new();

            foreach (var gamePair in m_inputData)
            {
                sumData[gamePair.Key] = MaxList(gamePair.Value);
            }
            
            return sumData;
        }

        private static Dictionary<string, int> MaxList(List<Dictionary<string, int>> roundList)
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
                    if (colorDictPair.Value> roundSum[colorDictPair.Key])
                    {
                        roundSum[colorDictPair.Key] = colorDictPair.Value;
                    }
                }
            }

            return roundSum;
        }
    }
}
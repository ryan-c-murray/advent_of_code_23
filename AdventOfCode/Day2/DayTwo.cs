using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day2
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
            DayTwoInputParse inputParser = new DayTwoInputParse();
            InputData = inputParser.GetInput();

            MaxData = getMaxData(InputData);

            ValidGames = getValidGames();

            CubedGames = cubeMaxGames();

            Console.WriteLine("done");
        }

        public int GetAnswer()
        {
            return CubedGames.Sum();
        }

        private List<int> cubeMaxGames()
        {
            List<int> cubedGameValues = new();
            
            foreach (var keyValuePair in MaxData)
            {
                Dictionary<string,int> gameResult = keyValuePair.Value;

                cubedGameValues.Add((gameResult["red"] * gameResult["blue"] * gameResult["green"]));

            } 

            return cubedGameValues;
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

        private Dictionary<string,Dictionary<string,int>> getMaxData(Dictionary<string,List<Dictionary<string,int>>> m_inputData)
        {
            Dictionary<string,Dictionary<string,int>> sumData = new();

            foreach (var gamePair in m_inputData)
            {
                sumData[gamePair.Key] = maxList(gamePair.Value);
            }
            
            return sumData;
        }

        private Dictionary<string,int> maxList(List<Dictionary<string,int>> roundList)
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
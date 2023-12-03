using System.Collections.Generic;

namespace AdventOfCode
{
    public class DayTwoInputParse
    {
        private const string inputPath = "/Users/Ryan/csharp_scrips/AdventOfCode/advent_of_code_23/AdventOfCode/Day2/Day2PuzzleInput.txt";

        public static Dictionary<string,List<Dictionary<string,int>>> GetInput()
        {
            StreamReader streamReader = new(inputPath);

            Dictionary<string,List<Dictionary<string,int>>> gamesDict = new();


            string fileLine;
            
            while ((fileLine = streamReader.ReadLine()) != null)
            {
                Dictionary<string,List<Dictionary<string,int>>> addDict = ParseFileLine(fileLine);

                foreach (var keyValuePair in addDict)
                {
                    gamesDict.Add(keyValuePair.Key,keyValuePair.Value);
                }
            }

            return gamesDict;
        }

        private static Dictionary<string,List<Dictionary<string,int>>> ParseFileLine(string m_fileLine)
        {
            Dictionary<string,List<Dictionary<string,int>>> output = new();

            string[] gameSplit = m_fileLine.Split(':');
            
            string gameNum = gameSplit[0].Replace("Game ",string.Empty);

            string[] roundSplit = gameSplit[gameSplit.Length-1].Split(';');


            List<Dictionary<string,int>> roundList = new();

            foreach (var round in roundSplit)
            {
                string[] resultsSplit = round.Split(',');
                roundList.Add(GetRoundResults(resultsSplit));
            }

            output[gameNum] = roundList;
            
            return output;
        }

        private static Dictionary<string,int> GetRoundResults(string[] m_round)
        {
            Dictionary<string,int> roundDict = new() 
            {
                {"red",0},
                {"green",0},
                {"blue",0}
            };

            foreach (string result in m_round)
            {
                string[] colorSplit = result.Trim().Split(' ');
                roundDict[colorSplit[1]] += int.Parse(colorSplit[0]);
            }

            return roundDict;
        }

    }
}
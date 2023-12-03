using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day2
{
    public class DayTwo
    {   
        private const string inputPath = "/Users/Ryan/csharp_scrips/AdventOfCode/advent_of_code_23/AdventOfCode/Day2/Day2PuzzleInput.txt";
        
        private Dictionary<string,List<Dictionary<string,int>>> inputData = new();

        public DayTwo()
        {
            inputData = getInput();

            Console.WriteLine("done");
        }

        private Dictionary<string,List<Dictionary<string,int>>> getInput()
        {
            StreamReader streamReader = new StreamReader(inputPath);

            Dictionary<string,List<Dictionary<string,int>>> gamesDict = new();


            string fileLine;
            
            while ((fileLine = streamReader.ReadLine()) != null)
            {
                Dictionary<string,List<Dictionary<string,int>>> addDict = parseFileLine(fileLine);

                foreach (var keyValuePair in addDict)
                {
                    gamesDict.Add(keyValuePair.Key,keyValuePair.Value);
                }
            }

            return gamesDict;
        }

        private Dictionary<string,List<Dictionary<string,int>>> parseFileLine(string m_fileLine)
        {
            Dictionary<string,List<Dictionary<string,int>>> output = new();

            string[] gameSplit = m_fileLine.Split(':');
            
            string gameNum = gameSplit[0].Replace("Game ",string.Empty);

            string[] roundSplit = gameSplit[gameSplit.Length-1].Split(';');


            List<Dictionary<string,int>> roundList = new();

            foreach (var round in roundSplit)
            {
               string[] resultsSplit = round.Split(',');
               roundList.Add(getRoundResults(resultsSplit));
            }

            output[gameNum] = roundList;
            
            return output;
        }

        private Dictionary<string,int> getRoundResults(string[] m_round)
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
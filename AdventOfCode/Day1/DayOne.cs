using System;
using System.IO;

namespace AdventOfCode.Day1
{
    public class DayOne
    {
        private const string inputPath = "/Users/Ryan/csharp_scrips/AdventOfCode/advent_of_code_23/AdventOfCode/Day1/PuzzleInput.txt";

        private readonly List<string> puzzleInput;

        private List<int> puzzleOutput;

        private readonly int answer;

        public DayOne()
        {
            puzzleInput = GetPuzzleInput(inputPath);
            puzzleOutput = GetPuzzleOutput(puzzleInput);

            answer = GetAnswer();
        }

        private static List<string> GetPuzzleInput(string m_inputPath)
        {
            StreamReader m_streamReader = new(m_inputPath);

            List<string> m_puzzleInput = new();

            string line;

            while ((line = m_streamReader.ReadLine()) != null)
            {
                m_puzzleInput.Add(line);
            }

            return m_puzzleInput;
        }

        private static List<int> GetPuzzleOutput(List<string> m_puzzleInput)
        {
            List<int> m_puzzleOutput = new();

            for (int i = 0; i < m_puzzleInput.Count; i++)
            {
                string word = m_puzzleInput[i];

                CalibrationValue calibration = new(word);

                int calibratedValue = calibration.ReturnNum;

                m_puzzleOutput.Add(calibratedValue);
            }

            return m_puzzleOutput;
        }

        public int GetAnswer()
        {
            List<int> m_puzzleOutput = puzzleOutput;

            int m_answer;

            m_answer = m_puzzleOutput.Sum();

            return m_answer;
        }
    }
}

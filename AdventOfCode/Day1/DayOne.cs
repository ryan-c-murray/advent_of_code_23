using System;
using System.IO;

namespace AdventOfCode.Day1
{
    public class DayOne
    {
        private const string inputPath = "C:\\Users\\rcmur\\source\\repos\\AdventOfCode\\AdventOfCode\\Day1\\PuzzleInput - Copy.txt";

        private readonly List<string> puzzleInput;

        private List<int> puzzleOutput;

        private int answer;

        public DayOne()
        {
            puzzleInput = getPuzzleInput(inputPath);
            puzzleOutput = getPuzzleOutput(puzzleInput);

            answer = GetAnswer();
        }

        private List<string> getPuzzleInput(string m_inputPath)
        {
            StreamReader m_streamReader = new StreamReader(m_inputPath);

            List<string> m_puzzleInput = new List<string>();

            string line;

            while ((line = m_streamReader.ReadLine()) != null)
            {
                m_puzzleInput.Add(line);
            }

            return m_puzzleInput;
        }

        private List<int> getPuzzleOutput(List<string> m_puzzleInput)
        {
            List<int> m_puzzleOutput = new List<int>();

            for (int i = 0; i < m_puzzleInput.Count; i++)
            {
                string word = m_puzzleInput[i];

                CalibrationValue calibration = new CalibrationValue(word);

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

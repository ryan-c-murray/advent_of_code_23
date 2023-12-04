using System.IO;
using System.Collections.Generic;

namespace AdventOfCode.Day3
{
    public class DayThree
    {
        private readonly List<string> inputData;

        private Dictionary<int,List<int>> symbolData = new(); 

        private Dictionary<int, List<int>> digitData = new();

        public DayThree() 
        {
            DayThreeInputParse parseDayThree = new DayThreeInputParse();
            inputData = parseDayThree.InputParsedData;

            GetIndices();

            Console.WriteLine("done");
        }

        public void GetIndices()
        {
            string checkString = string.Empty;

            Dictionary<int,List<int>> m_symbolDict = new();

            Dictionary<int,List<int>> m_digitDict = new();

            List<char> symbolChars = new List<char>()
                {
                    '-',
                    '&',
                    '/',
                    '*',
                    '@',
                    '#',
                    '%',
                    '$',
                    '*',
                    '+',
                    '=',
                };

            for (int i = 0; i < inputData.Count; i++) 
            {
                checkString = inputData[i];

                List<int> rowSymbols = new();

                List<int> rowDigits = new();

                for (int j = 0; j < checkString.Length; j++)
                {
                    char c = checkString[j];

                    if (IsSymbol(symbolChars, c)) { rowSymbols.Add(j); }

                    if (char.IsDigit(c)) { rowDigits.Add(j); }
                }
                m_symbolDict.Add(i, rowSymbols);

                m_digitDict.Add(i, rowDigits);
            }

            symbolData = m_symbolDict;

            digitData = m_digitDict;
        }

        public int FirstPartAnswer()
        {
            int output = 0;

            foreach (var rowDigitIndices in digitData)
            {
                int row = rowDigitIndices.Key;
                List<int> digitIndex = rowDigitIndices.Value;

                num

                for (int i = 0; i< digitIndex.Count;i++)
                {
                    if (i == 0) { continue; }

                    if (i == )

                }
            }
        }

        private bool IsSymbol(List<char> chars, char m_c) => chars.Contains(m_c);
        
    }
}

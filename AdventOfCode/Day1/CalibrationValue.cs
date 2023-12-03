
using System.Text.RegularExpressions;

namespace AdventOfCode.Day1
{
    public class CalibrationValue
    {

        private readonly string word;

        public int ReturnNum;

        private readonly Dictionary<string, string> charMap = new Dictionary<string, string>()
        {
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"},
        };

        public CalibrationValue(string m_word)
        {
            word = m_word;

            string charMappedWord = stringDigitParser(word);

            ReturnNum = firstLastNum(charMappedWord);

        }


        private string stringDigitParser(string m_word)
        {
            string output=string.Empty;
            
            Regex regex = new Regex(@"(\d)");

            string[] splitWord = regex.Split(m_word);

            foreach (string wordPart in splitWord)
            {
                if (wordPart.Length == 1)
                {
                    var isNumeric = int.TryParse(wordPart, out _);

                    if (isNumeric) { output += wordPart; }

                }
                else
                {
                    output+=replaceStringDigits(wordPart);
                }
            }

            return output;
        }

        private string replaceStringDigits(string loopStr)
        {

            string returnString = string.Empty;

            Dictionary<string,int> digitIndex = new Dictionary<string,int>();

            foreach (var mapper in charMap)
            {
                if (loopStr.Contains(mapper.Key))
                {
                    if (loopStr.IndexOf(mapper.Key) == loopStr.LastIndexOf(mapper.Key))
                    {
                        digitIndex.Add(mapper.Value, loopStr.IndexOf(mapper.Key));
                    }
                    
                }
            }

            var sortedDigitIndex = from entry in digitIndex orderby int.Parse(entry.Value.ToString()) ascending select entry.Key;

            foreach (var item in sortedDigitIndex)
            {
                returnString += item;
            }

            return returnString;
        }

        private int firstLastNum(string m_word)
        {

            int outputNum;

            
            outputNum = int.Parse(m_word[0].ToString() + m_word[m_word.Length - 1].ToString());
            

            return outputNum;
        }
    }
}


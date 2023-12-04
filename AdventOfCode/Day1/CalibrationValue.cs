﻿
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day1
{
    public class CalibrationValue
    {

        private readonly string word;

        public int ReturnNum;

        private readonly Dictionary<string, string> charMap = new()
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

            string charMappedWord = StringDigitParser(word);

            ReturnNum = FirstLastNum(charMappedWord);

        }


        private string StringDigitParser(string m_word)
        {
            string output=string.Empty;
            
            Regex regex = new(@"(\d)");

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
                    output+=StringDigitParse(wordPart);
                }
            }

            return output;
        }

        private string StringDigitParse(string loopStr)
        {

            string returnString = string.Empty;

            Dictionary<int,string> digitIndex = new();

            foreach (var mapper in charMap)
            {
                List<int> foundIndexes = DigitReplace(mapper.Key,loopStr);
                if (foundIndexes.Count != 0)
                {
                    foreach (int indexes in foundIndexes){
                        
                        digitIndex.Add(indexes,mapper.Value);
                    }
                }
            }
            

            var sortedDigitIndex = from entry in digitIndex orderby int.Parse(entry.Key.ToString()) ascending select entry.Value;

            foreach (var item in sortedDigitIndex)
            {
                returnString += item;
            }

            return returnString;
        }

        private static List<int> DigitReplace(string m_mapper, string m_loopStr)
        {
            List<int> foundIndexes = new();

            for (int i=0;;i+=m_mapper.Length)
            {
                i = m_loopStr.IndexOf(m_mapper,i);

                if (i==-1)
                {
                    return foundIndexes;
                }

                foundIndexes.Add(i);
            }
        }

        private static int FirstLastNum(string m_word)
        {
            int outputNum;

            outputNum = int.Parse(m_word[0].ToString() + m_word[^1].ToString());

            return outputNum;
        }
    }
}


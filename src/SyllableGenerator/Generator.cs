using System;
using System.Collections.Generic;

namespace SyllableGenerator
{
    /// <summary>
    /// Syllable generator for Uyghur Language
    /// </summary>
    /// <author>Eli Erkin</author>
    public class Generator
    {

        string[] Vowels = { "ا", "ە", "ې", "ى", "و", "ۇ", "ۆ", "ۈ" };
        string[] Consonants = { "ب", "پ", "ت", "ج", "چ", "خ", "د", "ر", "ۋ", "ز", "ژ", "س", "ش", "غ", "ف", "ق", "ك", "گ", "ڭ", "ي", "ھ", "ل", "م", "ن" };
        List<string> FinalResult = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        public Generator()
        {

        }


        /// <summary>
        /// generate syllable Recursion Method
        /// </summary>
        /// <param name="lst">Latter ararys List</param>
        /// <param name="level">Recursion Method Level, equals list length</param>
        /// <param name="tmp">temporary result length equals level</param>
        private void Generate(List<string[]> lst, int level, string[] tmp)
        {
            for (int i = 0; i < lst[level].Length; i++)
            {
                tmp[level] = lst[level][i];
                if (level < lst.Count - 1)
                {
                    tmp[level] = lst[level][i];
                    Generate(lst, level + 1, tmp);
                }
                if (level == lst.Count - 1)
                {
                    FinalResult.Add(normalize(string.Join("", tmp)));
                }
            }
        }


        /// <summary>
        /// Initialize list and frist time call Recursion Method
        /// </summary>
        /// <param name="syllableType">syllable Type eg: CVC,VCV...</param>
        /// <returns>Generated Syllable List</returns>
        public List<string> Generate(SyllableType syllableType)
        {
            FinalResult.Clear();
            List<string[]> lst = new List<string[]>();
            lst = makeList(syllableType.ToString("g"));
            string[] tmp = new string[lst.Count];
            Generate(lst, 0, tmp);
            //List<string> tempResult = new List<string>(FinalResult);
            
            //FinalResult.Clear();
            return FinalResult;
        }

        /// <summary>
        /// fill list by syllable pattern
        /// </summary>
        /// <param name="patteren">patteren</param>
        /// <returns></returns>
        private List<string[]> makeList(string patteren)
        {
            List<string[]> lst = new List<string[]>();
            foreach (Char item in patteren.ToCharArray())
            {
                if (item == 'V' || item == 'C')
                {
                    if (item == 'V')
                    {
                        lst.Add(Vowels);
                    }
                    else
                    {
                        lst.Add(Consonants);
                    }
                }
                else
                {
                    return
                          null;
                }

            }

            return lst;
        }

        /// <summary>
        /// add Hemze if frist latter is vowel of syllable
        /// </summary>
        /// <param name="str">syllable</param>
        /// <returns></returns>
        private string normalize(string str)
        {
            foreach (var item in Vowels)
            {
                if (str[0].ToString() == item)
                {
                    return "ئ" + str;
                }
            }
            return str;
        }
    }
}

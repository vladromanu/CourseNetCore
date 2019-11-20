using System;
using System.Collections.Generic;
using System.Text;

namespace Homework6
{
    class WordCountHard : IWordCountStrategy
    {
        public int GetLastWordCount(string s)
        {
            string[] words = s.Split(' ');

            if (words.Length == 0)
            {
                return 0;
            }

            int idx = words.Length - 1;
            string? validWord = null;

            do
            {
                words[idx] = words[idx].Trim();

                if (!String.IsNullOrWhiteSpace(words[idx]))
                {
                    validWord = words[idx];
                    break;
                }

                idx--;

            } while (idx >= 0 || validWord != null);

            return validWord == null ? 0 : validWord.Length;
        }
    }
}

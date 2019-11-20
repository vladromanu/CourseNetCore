using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework6
{
    class WordCountLinq : IWordCountStrategy
    {
        public int GetLastWordCount(string s)
        {
            var lastWord = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Last();
            return lastWord.Length > 0 ? lastWord.Length : 0;
        }
    }
}

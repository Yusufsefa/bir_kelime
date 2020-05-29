using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelime
{
    public class Result
    {

        private static Result instance = null;

        public static Result getInstance()
        {
            if(instance == null)
            {
                instance = new Result(); 
            }

            return instance;
        }


        public List<String> findWords(List<String> dict,char[] letters)
        {
            int[] avail = new int[26];

            foreach (var c in letters)
            {
                int index = c - 'a';
                avail[index]++;
            }

            List<String> result = new List<string>();

            foreach (var word in dict)
            {
                int[] count = new int[26];
                Boolean ok = true;
                foreach (var c in word.ToCharArray())
                {
                    int index = c - 'a';
                    count[index]++;

                    if (count[index] > avail[index])
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    result.Add(word);
                }
            }

            return result;
        }

    }

    
}

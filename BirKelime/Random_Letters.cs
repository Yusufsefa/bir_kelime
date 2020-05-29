using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelime
{
    public class Random_Letters
    {

        private static Random_Letters instance = null;

        private Random rnd;

        static readonly String alphabet="abcdefghijklmnopqrstuvwxyz";
        static readonly String consonant_letters = "bcdfghjklmnpqrstvwxyz";
        static readonly String vowel_letters = "aeiou";

        int N = alphabet.Length;
        int cononant = consonant_letters.Length;
        int vowel = vowel_letters.Length;

        public Random_Letters()
        {
            rnd = new Random();
        }

        public static Random_Letters getInstance()
        {
            if (instance == null)
            {
                instance = new Random_Letters();
            }
            return instance;
        }

        public char[] rndLetters()
        {
            char[] result = new char[8];

            for(int i = 0; i < 8; i++)
            {
                if(i > 4)
                {
                    result[i] = vowel_letters[this.rnd.Next(0, vowel)];
                }
                else
                {
                    result[i] = consonant_letters[this.rnd.Next(0, cononant)];
                }
                
            }

            return result;
        }

        public char bonusLetter()
        {
            char bonus = alphabet[rnd.Next(0,N)];
            return bonus;
        }

    }
}

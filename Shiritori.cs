using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTask3.BL
{
    public class Shiritori
    {
        public List<string> words;
        public bool game_over;

        public Shiritori()
        {
            words = new List<string>();
            game_over = false;
        }

        public List<string> Play(string word)
        {
            if (game_over)
            {
                Console.WriteLine("Game over. Cannot play.");
                return words;
            }

            if (words.Count > 0 && !IsValidWord(word))
            {
                Console.WriteLine("Game over. Invalid word.");
                game_over = true;
                return words;
            }
            words.Add(word);
            return words;
        }

        public string Restart()
        {
            words.Clear();
            game_over = false;
            return "Game restarted.";
        }

        public bool IsValidWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            if (words.Contains(word))
                return false;

            if (words.Count > 0 && words[words.Count - 1].Last() != word.First())
                return false;

            return true;
        }
    }
}

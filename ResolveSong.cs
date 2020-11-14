using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricFormatt
{
    class ResolveSong
    {
        public string[] song;

        public Dictionary<int, string> chordLines = new Dictionary<int, string>();
        public Dictionary<int, string> lyricLines = new Dictionary<int, string>();
        public Dictionary<int, string> unknownLines = new Dictionary<int, string>();

        public void Resolve()
        {
            chordLines.Clear();
            lyricLines.Clear();
            unknownLines.Clear();

            for (int i = 0; i < song.Length; i++)
            {
                string line = song[i];
                int chordLike = ResolveLine(line);
                if (chordLike > 0)
                {
                    chordLines.Add(i, line);
                }
                else if (chordLike < 0)
                {
                    lyricLines.Add(i, line);
                }
                else
                {
                    unknownLines.Add(i, line);
                }
            }
        }

        // -1 Definitely Not Chord
        // 0 Possibly Chord
        // 1 Definitely Chord
        public static int ResolveLine(string line)
        {
            bool ContainsAny(params string[] testFor)
            {
                foreach (var item in testFor)
                {
                    if (line.Contains(item.ToLower()) || line.Contains(item))
                    {
                        return true;
                    }
                }
                return false;
            }

            bool ContainsAnyChar(params char[] testFor)
            {
                foreach (var item in testFor)
                {
                    if (line.Contains(Char.ToLower(item)) || line.Contains(item))
                    {
                        return true;
                    }
                }
                return false;
            }

            if (ContainsAnyChar(Resolvers.Bad))
            {
                return -1;
            }

            foreach (char note in Resolvers.notes)
            {
                if (ContainsAny(Resolvers.Chords(note)))
                    return 1;
            }

            if (ContainsAnyChar(Resolvers.notes))
            {
                return 0;
            }

            return -1;
        }

        public void PrintDifferences()
        {
            for (int i = 0; i < song.Length; i++)
            {
                ConsoleColor color = ConsoleColor.Red;
                if (lyricLines.ContainsKey(i))
                {
                    color = ConsoleColor.Green;
                }
                else if (unknownLines.ContainsKey(i))
                {
                    color = ConsoleColor.Blue;
                }

                Console.ForegroundColor = color;
                Console.WriteLine(song[i]);
            }
        }

        public ResolveSong(string[] song)
        {
            this.song = song;
            Resolve();
        }
    }
}

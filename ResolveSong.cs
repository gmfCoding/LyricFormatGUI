using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricFormatt
{
    public class ResolveSong
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

  

        public ResolveSong(string[] song)
        {
            this.song = song;
            Resolve();
        }

        public string GetSong()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < song.Length; i++)
            {
                sb.AppendLine(song[i]);
            }
            return sb.ToString();
        }

        public string GetChords() => GetLyrics(false, true, false);
        public string GetLyrics() => GetLyrics(true, false, false);
        public string GetUnknown() => GetLyrics(false, false, true);

        public string GetLyricsAndUnknown() => GetLyrics(true, false, true);
        public string GetLyrics(bool lyrics, bool chords, bool unknowns)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < song.Length; i++)
            {
                if (lyrics && lyricLines.ContainsKey(i))
                {
                    sb.Append(lyricLines[i]);
                }

                if (chords && chordLines.ContainsKey(i))
                {
                    sb.Append(chordLines[i]);
                }

                if (unknowns && unknownLines.ContainsKey(i))
                {
                    sb.Append(unknownLines[i]);
                }

            }

            return sb.ToString();
        }
    }
}

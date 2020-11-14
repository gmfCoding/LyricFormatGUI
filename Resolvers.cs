using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricFormatt
{
    public static class Resolvers
    {
        //All variables are named relative to a chord line, so 'bad' means it's a bad chord line (meaning most likely not a chord line)

        public static char[] Bad = { '[', 'O', 'I', 'U', ',' };

        public static char[] notes = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

        public static string[] Chords(char note)
        {
            return new string[] { "maj", "|", note + "m", note + "b" };
        }

    }
}

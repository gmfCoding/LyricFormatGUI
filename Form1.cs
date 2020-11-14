
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LyricFormatt;
using System.IO;

namespace LyricFormatGUI
{
    public partial class Form1 : Form
    {

        ResolveSong current;

        public List<ResolveSong> resolvers = new List<ResolveSong>();
        public static RichTextBox rtb;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtb = (RichTextBox)this.Controls.Find("rtb_output", true)[0];
            rtb.Enabled = true;
            rtb.ReadOnly = true;

            //if (File.Exists(@"D:\Projects\Software\Source\LyricFormatt\bin\Debug\Songs\1.txt"))
            //{
            //    AddSong(new ResolveSong(File.ReadAllLines(@"D:\Projects\Software\Source\LyricFormatt\bin\Debug\Songs\1.txt")));
            //}

            
            Console.ReadLine();
        }

        //prints to the rich text box
        public void PrintToRTB(ResolveSong rs)
        { 
            rtb.Clear();
            
            for (int i = 0; i < rs.song.Length; i++)
            {
                rtb.AppendText(rs.song[i] + '\n');
            }
        }

        private void ColorizeRTB(ResolveSong rs)
        {
            for (int i = 0; i < rs.song.Length; i++)
            {
                Color color = Color.Red;
                if (rs.lyricLines.ContainsKey(i))
                {
                    color = Color.Green;
                }
                else if (rs.unknownLines.ContainsKey(i))
                {
                    color = Color.Blue;
                }

                // if using numbered lines
                //int extra = (int)Math.Floor(Math.Log10(i) + 1);
                //if (i == 0)
                //{
                //    extra = 1;
                //}
                rtb.SelectionStart = rtb.GetFirstCharIndexFromLine(i);// + extra + 1
                rtb.SelectionLength = rs.song[i].Length;

                rtb.SelectionColor = color;
            }
            rtb.SelectionStart = 0;
            rtb.SelectionLength = 0;
        }


        public void AddSong(ResolveSong rs)
        {
            current = rs;
            PrintToRTB(current);
            ColorizeRTB(current);

            resolvers.Add(rs);
        }

        public void OnDragDrop(object sender, DragEventArgs e)
        {
            string[] paths = ((string[])e.Data.GetData(DataFormats.FileDrop));

            foreach (string path in paths)
            {
                if (File.Exists(path))
                {
                    AddSong(new ResolveSong(File.ReadAllLines(path)));
                }
            }
        }

        public void PasteSong(object sender, EventArgs e)
        {
            current = new ResolveSong(Clipboard.GetText().Split('\n'));
            PrintToRTB(current);
            ColorizeRTB(current);
        }

        private void CopyAll(object sender, EventArgs e)
        {
            Clipboard.SetText(current.GetSong());
        }

        public void CopyChords(object sender, EventArgs e)
        {
            Clipboard.SetText(current.GetChords());
        }

        private void CopyLyrics(object sender, EventArgs e)
        {
            Clipboard.SetText(current.GetLyrics());
        }

        private void CopyLyricsAndUnknown(object sender, EventArgs e)
        {
            Clipboard.SetText(current.GetLyricsAndUnknown());
        }

        private void rtb_output_MouseDown(object sender, MouseEventArgs e)
        {
            int charindex = rtb.GetCharIndexFromPosition(e.Location);
            int line = rtb.GetLineFromCharIndex(charindex);

            bool isLyric = current.lyricLines.ContainsKey(line);
            bool isChord = current.chordLines.ContainsKey(line);
            bool isUnknown = current.unknownLines.ContainsKey(line);
            rtb.SelectionStart = rtb.GetFirstCharIndexFromLine(line);
            rtb.SelectionLength = rtb.Lines[line].Length;

            

            if (isLyric)
            {
                Console.WriteLine($"Setting line:{line} to chord.");
                Console.WriteLine(rtb.Lines[line]);

                current.chordLines.Add(line, current.lyricLines[line]);
                current.lyricLines.Remove(line);
                rtb.SelectionColor = Color.Red;
            }
            else if (isChord)
            {
                Console.WriteLine($"Setting line:{line} to lyric.");
                Console.WriteLine(rtb.Lines[line]);

                current.lyricLines.Add(line, current.chordLines[line]);

                current.chordLines.Remove(line);
                rtb.SelectionColor = Color.Green;
            }
            else if(isUnknown)
            {
                Console.WriteLine($"Setting line:{line} to lyric.");
                Console.WriteLine(rtb.Lines[line]);

                current.lyricLines.Add(line, current.unknownLines[line]);
                current.unknownLines.Remove(line);
                rtb.SelectionColor = Color.Green;
            }

            //ColorizeRTB(current);

        }

        private void OnDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricFormatt
{
    public static class Song
    {

        public static string song = @"
Bb Major Capo - 2

[Verse 1]
Bbmaj7 Dm7
Bad things seem to follow all the good things in my life
Bbmaj7 Dm7
and ever since I met you it feels like it's only a matter of time
Gm7
I'm scared
F Gm7
Can you blame me? Yeah.

[Verse 2]
Bbmaj7 Dm7
I'm trying not to overthink but with my track record
Bbmaj7 Dm7
It's hard to turn a blind eye to what usually occurs
Gm7
I'm ensnared
F Gm7
Can you blame me? Yeah.

[Chorus 1]
|Ebmaj7|Dm7|Cm7|Dm7 D7|
So I live through every day, trying to make these thoughts go away
|Ebmaj7|Dm7|Cm7|Dm7 D7|
But some days it's hard to see, the rational side of each hemisphere
|Ebmaj7|Dm7|Cm7|Dm7 D7|
So I'm trying to stop overthinking, but that's easier said than done
|Ebmaj7|Dm7|Cm7|Dm7 D7|
So I'm trying to stop worrying, but I've only just begun

[Interlude]
|Ebmaj7|Dm7|Cm7|Dm7 D7|

[Verse 3]
Bbmaj7 Dm7
It's all a work in progress, but I'm running out of luck
Bbmaj7 Dm7
I try and stay persistent but some days are hard as fuck
Gm7
I'm exhausted
F Gm7
Some days I can't be bothered

[Bridge]
Bbmaj7 Ebmaj7
So I wrote this song in hopes of making people understand
Am7b5 Dm7
It took a while for me to find the words to match what's
Gm7
In my head
F Gm7

[Chorus 2]
|Ebmaj7|Dm7|Cm7|Dm7 D7|
So I live through every day, trying to make these thoughts go away
|Ebmaj7|Dm7|Cm7|Dm7 D7|
But some days it's hard to see, the rational side of each hemisphere
|Ebmaj7|Dm7|Cm7|Dm7 D7|
So I'm trying to stop overthinking, but that's easier said than done
|Ebmaj7|Dm7|Cm7|Dm7 D7|
So I'm trying to stop worrying, but I've only just begun
";

        public static string song2 = @"
Capo 1 - G Major (G# Major)

[Interlude]
G Cmaj7 Bm7 Cmaj7*

[Verse 1 - Drums & Bass Come In]
G Cmaj7
Staring at the ceiling
G Cmaj7
A lot is on my mind
G Cmaj7
Waiting for the day that
G Bm7 Am7
I can call you mine

[Interlude]
G Cmaj7 Bm7 Cmaj7*

[Verse 2]
G Cmaj7
Remember when we stayed up
G Cmaj7
Late into the night
G Cmaj7
Although the sun had set
G Bm7 Am7
Your smile still shone bright

[Chorus]
Cmaj7 Bm7
It's been a little while
G Em
Since I hit the bottom
Cmaj7 Bm7
You dragged me out the darkness
G Em
Straight into autumn
Cmaj7 Am7
I owe you more than I can
Em G
Ever put into words

[Solo]
Am7 Cmaj7 G G
Am7 Cmaj7 Em G
Strum - 3rd 1st 4th 2nd

[Interlude]
G Cmaj7 Bm7 Cmaj7

[Bridge - Rest Between Chords]
Bm7 Cmaj7
I am so grateful
Am7 Em
To have you by my side
Bm7 Cmaj7
In all the time I've known you
Am7 Em
We've laughed, and we've cried
D Am7
It took me a while to get out of this place
Cmaj7 G
Where gray clouds covered the sky all day
D Am7
A hand from behind came down and grabbed me
Cmaj7 G
And lifted me up right off my knees
D Em
I turn around and you're the first thing I see
Am7 Cmaj7
Lifting my spirits as well as my feet

[Bar Pause of Cmaj7 - All Other Instruments Stop]

[Solo]
Am7 Cmaj7 G G
Am7 Cmaj7 Em G
Strum - 3rd 1st 4th 2nd

[Chorus]
Cmaj7 Bm7
It's been a little while
G Em
Since I hit the bottom
Cmaj7 Bm7
You dragged me out the darkness
G Em
Straight into autumn
Cmaj7 Am7
I owe you more than I can
Em G
Ever put in words
Cmaj7 Am7
I've said it before I'll say it again
Em G
Without you it'd have been much 
Cmaj7 Am7 
Worse
Em Cmaj7
Worse

[Outro]
G* Cmaj7* Bm7* Cmaj7*

G*
";

        public static string[] lines;
        public static string[] lines2;

        static Song()
        {
            lines = GetSongAsArray(song);
            lines2 = GetSongAsArray(song2);
        }

        public static string[] GetSongAsArray(string str)
        {
            return str.Split('\n');
        }
    }
}

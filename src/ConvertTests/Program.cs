// ---------------------------------------------------
// 
//   ASS Conversions
// 
// ---------------------------------------------------

using SharpSubtitles;
using SharpSubtitles.AdvancedSubstationAlpha;
using SharpSubtitles.Lrc;
using SharpSubtitles.Srt;

var ass = new AssFile(File.ReadAllText("test.ass"));

Console.WriteLine("------------  ORIGINAL  ------------");
DumpAss(ass);

var srt = SubtitleConvert.ASS.ToSrt(ass);

Console.WriteLine("------------ ASS -> SRT ------------");
DumpSrt(srt);

Console.WriteLine("------------ ASS -> LRC ------------");
var lrc = SubtitleConvert.ASS.ToLrc(ass);
DumpLrc(lrc);

Console.WriteLine("------------ SRT -> ASS ------------");
ass = SubtitleConvert.SRT.ToAss(srt);
DumpAss(ass);

Console.WriteLine("------------ SRT -> LRC ------------");
lrc = SubtitleConvert.SRT.ToLrc(srt);
DumpLrc(lrc);

Console.WriteLine("------------ LRC -> ASS ------------");
ass = SubtitleConvert.LRC.ToAss(lrc);
DumpAss(ass);

Console.WriteLine("------------ LRC -> SRT ------------");
srt = SubtitleConvert.LRC.ToSrt(lrc);
DumpSrt(srt);

Console.WriteLine("------------------------------------");
Console.WriteLine("If all results are identical, it means");
Console.WriteLine("conversion works fine. :D");

static void DumpSrt(SrtFile srt)
{
    foreach (var item in srt.Subtitles)
    {
        Console.WriteLine($"{item.StartTimestamp};{item.EndTimestamp};{item.Text};{item.Index}");
    }
}

static void DumpLrc(LrcFile lrc)
{
    foreach (var item in lrc.Subtitles)
    {
        Console.WriteLine($"{item.Start};{item.End};{item.Text}");
    }
}

static void DumpAss(AssFile ass)
{
    foreach (var item in ass.GetSubtitles())
    {
        Console.WriteLine($"{item.Start};{item.End};{item.Text}");
    }
}

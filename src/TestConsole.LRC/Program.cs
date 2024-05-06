using SharpSubtitles.Lrc;
using System.Diagnostics;

DoBenchmarking(() =>
{
    string rawSrt = @"[00:12.00]Line 1 lyrics
[00:17.20][00:22.00]Line 2 lyrics
";
    // example above was taken from a Wikipedia article

    var srt = new LrcFile(rawSrt, maxDepth: 3);
    foreach (var item in srt.Subtitles)
    {
        Console.WriteLine(item.ToString());
    }
});

static void DoBenchmarking(Action code)
{
    var sw = Stopwatch.StartNew();
    code();
    sw.Stop();
    
    Console.WriteLine($"completed in {sw.Elapsed}");
}

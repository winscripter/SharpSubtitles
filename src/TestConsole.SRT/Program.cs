using SharpSubtitles.Srt;
using System.Diagnostics;

DoBenchmarking(() =>
{
    string rawSrt = @"1
00:02:16,612 --> 00:02:19,376
Senator, we're making
our final approach into Coruscant.

2
00:02:19,482 --> 00:02:21,609
Very good, Lieutenant.

3
00:03:13,336 --> 00:03:15,167
We made it.

4
00:03:18,608 --> 00:03:20,371
I guess I was wrong.

5
00:03:20,476 --> 00:03:22,671
There was no danger at all.";
    // example above was taken from a Wikipedia article

    var srt = new SrtFile(rawSrt, maxDepth: 5);
    foreach (var item in srt.Subtitles)
    {
        Console.WriteLine(item.Text);
        Console.WriteLine(item.StartTimestamp.ToString());
    }
});

static void DoBenchmarking(Action code)
{
    var sw = Stopwatch.StartNew();
    code();
    sw.Stop();

    Console.WriteLine($"completed in {sw.Elapsed}");
}

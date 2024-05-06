using SharpSubtitles.AdvancedSubstationAlpha;
using System.Diagnostics;

DoBenchmarking(() =>
{
    var ass = new AssFile(File.ReadAllText("file.ass"));
    foreach (var element in ass.GetSubtitles())
    {
        Console.WriteLine(element.ToString());
    }
});

static void DoBenchmarking(Action code)
{
    var sw = Stopwatch.StartNew();
    code();
    sw.Stop();

    Console.WriteLine($"completed in {sw.Elapsed}");
}

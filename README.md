# SharpSubtitles
SharpSubtitles is a reader/writer/converter between 3 subtitle formats: SRT, LRC, and ASS

# Loading an ASS file
```cs
var ass = new AssFile(File.ReadAllText("subtitles.ass"));
foreach (var subtitle in ass.GetSubtitles())
{
    // do something with subtitle
}
```

# Loading an SRT file
```cs
var srt = new SrtFile(File.ReadAllText("subtitels.srt"));
foreach (var subtitle in srt.Subtitles)
{
    // do something with subtitle
}
```

# Loading an LRC file
```cs
var lrc = new LrcFile(File.ReadAllText("subtitles.lrc"));
foreach (var subtitle in lrc.Subtitles)
{
    // do something with subtitle
}
```

# Subtitle conversion
The `SubtitleConvert` class has nested classes to convert subtitle formats:
- SubtitleConvert
  - ASS
    - ToSrt
    - ToLrc
  - SRT
    - ToAss
    - ToLrc
  - LRC
    - ToAss
    - ToSrt


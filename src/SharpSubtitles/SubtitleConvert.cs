using SharpSubtitles.AdvancedSubstationAlpha;
using SharpSubtitles.AdvancedSubstationAlpha.Internal;
using SharpSubtitles.Lrc;
using SharpSubtitles.Srt;
using System.Text;

namespace SharpSubtitles;

/// <summary>
/// Converts subtitle formats.
/// </summary>
public static class SubtitleConvert
{
    /// <summary>
    /// Converts Advanced SubStation Alpha to other formats.
    /// </summary>
    public static class ASS
    {
        /// <summary>
        ///   Converts an ASS subtitle format to LRC.
        /// </summary>
        /// <param name="ass">
        ///   Input ASS subtitle.
        /// </param>
        /// <returns>
        ///   A new <see cref="LrcFile"/> instance.
        /// </returns>
        public static LrcFile ToLrc(AssFile ass)
        {
            var lrc = new LrcFile
            {
                Subtitles = []
            };
            foreach (var subtitle in ass.GetSubtitles())
            {
                lrc.Subtitles = lrc.Subtitles.Append(
                    new LrcSubtitle(subtitle.Start, subtitle.End, subtitle.Text));
            }

            return lrc;
        }

        /// <summary>
        ///   Converts an ASS subtitle format to SRT.
        /// </summary>
        /// <param name="ass">
        ///   Input ASS subtitle.
        /// </param>
        /// <returns>
        ///   A new <see cref="SrtFile"/> instance.
        /// </returns>
        public static SrtFile ToSrt(AssFile ass)
        {
            int index = 1;
            var srt = new SrtFile
            {
                Subtitles = []
            };
            foreach (var subtitle in ass.GetSubtitles())
            {
                try
                {
                    srt.Subtitles = srt.Subtitles.Append(
                        new SrtSubtitle(index++, subtitle.Start, subtitle.End, subtitle.Text));
                }
                catch
                {
                    srt.Subtitles = srt.Subtitles.Append(
                        new SrtSubtitle(index++, subtitle.Start, subtitle.End + TimeSpan.FromMicroseconds(1), subtitle.Text));
                }
            }

            return srt;
        }
    }

    /// <summary>
    /// Converts SubRip subtitle to other formats.
    /// </summary>
    public static class SRT
    {
        /// <summary>
        /// Converts an SRT file to an ASS file.
        /// </summary>
        public static AssFile ToAss(SrtFile srt)
        {
            return Internal_ConvertSrtToAss(srt);
        }

        /// <summary>
        /// Converts an SRT file to an LRC file.
        /// </summary>
        public static LrcFile ToLrc(SrtFile srt)
        {
            var lrc = new LrcFile()
            {
                Subtitles = []
            };
            foreach (var sub in srt.Subtitles)
            {
                lrc.Subtitles = lrc.Subtitles.Append(
                    new LrcSubtitle(sub.StartTimestamp, sub.EndTimestamp, sub.Text));
            }

            return lrc;
        }

        private static AssFile Internal_ConvertSrtToAss(SrtFile srt)
        {
            StringBuilder sb = new(@"[Script Info]
ScriptType: v4.00+
PlayResX: 384
PlayResY: 288
ScaledBorderAndShadow: yes
YCbCr Matrix: None

[V4+ Styles]
Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding
Style: Default,Arial,16,&Hffffff,&Hffffff,&H0,&H0,0,0,0,0,100,100,0,0,1,1,0,2,10,10,10,1

[Events]");
            sb.AppendLine("Format: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text");

            foreach (var subtitle in srt.Subtitles)
            {
                Emit(subtitle);
            }

            return new AssFile(sb.ToString());

            void Emit(SrtSubtitle subtitle)
            {
                sb.AppendLine($"Dialogue: 0,{subtitle.StartTimestamp.Stringify()},{subtitle.EndTimestamp.Stringify()},Default,,0,0,0,,{subtitle.Text}");
            }
        }
    }

    /// <summary>
    /// Converts LRC (lyrics) subtitle to other formats.
    /// </summary>
    public static class LRC
    {
        /// <summary>
        /// Converts an LRC file to an ASS file.
        /// </summary>
        public static AssFile ToAss(LrcFile lrc)
            => SRT.ToAss(ToSrt(lrc)); // HACK: just a quick workaround

        /// <summary>
        /// Converts an LRC file to an SRT file.
        /// </summary>
        public static SrtFile ToSrt(LrcFile lrc)
        {
            int index = 1;
            var srt = new SrtFile()
            {
                Subtitles = []
            };
            foreach (var sub in lrc.Subtitles)
            {
                srt.Subtitles = srt.Subtitles.Append(
                    new SrtSubtitle(index++, sub.Start, sub.End ?? (sub.Start + TimeSpan.FromSeconds(1)), sub.Text));
            }

            return srt;
        }
    }
}

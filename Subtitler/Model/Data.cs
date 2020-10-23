namespace Subtitler.Model
{
    public static class Data
    {
        //Reference https://en.wikipedia.org/wiki/Video_file_format
        public static FileExtension[] EpisodesFileExtensions = new FileExtension[]
        {
            new FileExtension(){ Name = "webm" },
            new FileExtension(){ Name = "mkv" },
            new FileExtension(){ Name = "flv" },
            new FileExtension(){ Name = "vob" },
            new FileExtension(){ Name = "ogv" },
            new FileExtension(){ Name = "ogg" },
            new FileExtension(){ Name = "drc" },
            new FileExtension(){ Name = "gif" },
            new FileExtension(){ Name = "gifv" },
            new FileExtension(){ Name = "mng" },
            new FileExtension(){ Name = "avi" },
            new FileExtension(){ Name = "mts" },
            new FileExtension(){ Name = "m2ts" },
            new FileExtension(){ Name = "ts" },
            new FileExtension(){ Name = "mov" },
            new FileExtension(){ Name = "qt" },
            new FileExtension(){ Name = "wmv" },
            new FileExtension(){ Name = "yuv" },
            new FileExtension(){ Name = "rm" },
            new FileExtension(){ Name = "rmvb" },
            new FileExtension(){ Name = "viv" },
            new FileExtension(){ Name = "asf" },
            new FileExtension(){ Name = "amv" },
            new FileExtension(){ Name = "mp4" },
            new FileExtension(){ Name = "m4p" },
            new FileExtension(){ Name = "m4v" },
            new FileExtension(){ Name = "mpg" },
            new FileExtension(){ Name = "mp2" },
            new FileExtension(){ Name = "mpeg" },
            new FileExtension(){ Name = "mpe" },
            new FileExtension(){ Name = "mpv" },
            new FileExtension(){ Name = "m2v" },
            new FileExtension(){ Name = "svi" },
            new FileExtension(){ Name = "3gp" },
            new FileExtension(){ Name = "3g2" },
            new FileExtension(){ Name = "mxf" },
            new FileExtension(){ Name = "roq" },
            new FileExtension(){ Name = "nsv" },
            new FileExtension(){ Name = "flv" },
            new FileExtension(){ Name = "f4v" },
            new FileExtension(){ Name = "f4p" },
            new FileExtension(){ Name = "f4a" },
            new FileExtension(){ Name = "f4b" },
        };

        //Reference https://blog.amara.org/2018/10/15/what-subtitle-file-format-should-i-use/
        public static FileExtension[] SubtitilesFileExtensions = new FileExtension[]
        {
            new FileExtension(){ Name = "srt" },
            new FileExtension(){ Name = "ssa" },
            new FileExtension(){ Name = "ass" },
            new FileExtension(){ Name = "ttml" },
            new FileExtension(){ Name = "sbv" },
            new FileExtension(){ Name = "dfxp" },
            new FileExtension(){ Name = "vtt" },
            new FileExtension(){ Name = "txt" },
        };

        public static MethodSubtitler[] MethodsSubtitler = new MethodSubtitler[]
{
            new MethodSubtitler(){ Name = "Orderned List", Value = "Orderned List" },
};
    }
}

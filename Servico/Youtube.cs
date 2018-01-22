using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Helpers;

namespace Servicos
{
    public class Youtube
    {
        public const string youtubeApiKey = "AIzaSyCzW8vQ1z2l2JD1rmM6x4NsyK8N2ngkMxw";

        public int Width { get; set; }
        public int Height { get; set; }
        public int Duration { get; set; }
        public string Title { get; set; }
        public string ThumbUrl { get; set; }
        public string BigThumbUrl { get; set; }
        public string Description { get; set; }
        public string VideoDuration { get; set; }
        public string Url { get; set; }
        public DateTime UploadDate { get; set; }

        public static string getYoutubeId(string youtubeUrl)
        {
            Match regexMatch = Regex.Match(youtubeUrl, "^[^v]+v=(.{11}).*", RegexOptions.IgnoreCase);
            if (regexMatch.Success)
            {
                return regexMatch.Groups[1].Value;
            }

            return youtubeUrl;
        }

        public static string MontarThumb(string youtubeId)
        {
            return "http://img.youtube.com/vi/" + youtubeId + "/default.jpg";
        }

        public bool YouTubeImport(string VideoID)
        {
            try
            {
                WebClient myDownloader = new WebClient();
                myDownloader.Encoding = System.Text.Encoding.UTF8;

                string jsonResponse = myDownloader.DownloadString("https://www.googleapis.com/youtube/v3/videos?id=" + VideoID + "&key=" + youtubeApiKey + "&part=snippet");
                var dynamicObject = Json.Decode(jsonResponse);
                var item = dynamicObject.items[0].snippet;

                Title = item.title;
                ThumbUrl = item.thumbnails.@default.url;
                BigThumbUrl = item.thumbnails.high.url;
                Description = item.description;
                UploadDate = Convert.ToDateTime(item.publishedAt);

                jsonResponse = myDownloader.DownloadString("https://www.googleapis.com/youtube/v3/videos?id=" + VideoID + "&key=" + youtubeApiKey + "&part=contentDetails");
                dynamicObject = Json.Decode(jsonResponse);
                string tmp = dynamicObject.items[0].contentDetails.duration;
                Duration = Convert.ToInt32(System.Xml.XmlConvert.ToTimeSpan(tmp).TotalSeconds);

                Url = "http://www.youtube.com/watch?v=" + VideoID;

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
                return false;
            }
        }
    }
}

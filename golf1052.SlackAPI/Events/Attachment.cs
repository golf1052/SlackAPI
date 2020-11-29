using System;
using System.Collections.Generic;
using System.Text;

namespace golf1052.SlackAPI.Events
{
    public class Attachment
    {
        public string ServiceName { get; set; }
        public string ServiceUrl { get; set; }
        public string Title { get; set; }
        public string TitleLink { get; set; }
        public string ThumbUrl { get; set; }
        public int? ThumbWidth { get; set; }
        public int? ThumbHeight { get; set; }
        public string Fallback { get; set; }
        public string AudioHtml { get; set; }
        public int? AudioHtmlWidth { get; set; }
        public int? AudioHtmlHeight { get; set; }
        public string FromUrl { get; set; }
        public string ServiceIcon { get; set; }
        public int? Id { get; set; }
        public string OriginalUrl { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace golf1052.SlackAPI.Objects
{
    public class SlackFile
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("created")]
        public long Created { get; private set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("mimetype")]
        public string Mimetype { get; private set; }

        [JsonProperty("filetype")]
        public string Filetype { get; private set; }

        [JsonProperty("pretty_type")]
        public string PrettyType { get; private set; }

        [JsonProperty("user")]
        public string User { get; private set; }

        [JsonProperty("editable")]
        public bool Editable { get; private set; }

        [JsonProperty("size")]
        public long Size { get; private set; }

        [JsonProperty("mode")]
        public string Mode { get; private set; }

        [JsonProperty("is_external")]
        public bool IsExternal { get; private set; }

        [JsonProperty("external_type")]
        public string ExternalType { get; private set; }

        [JsonProperty("is_public")]
        public bool IsPublic { get; private set; }

        [JsonProperty("public_url_shared")]
        public bool PublicUrlShared { get; private set; }

        [JsonProperty("display_as_bot")]
        public bool DisplayAsBot { get; private set; }

        [JsonProperty("username")]
        public string Username { get; private set; }

        [JsonProperty("url_private")]
        public string UrlPrivate { get; private set; }

        [JsonProperty("url_private_download")]
        public string UrlPrivateDownload { get; private set; }

        [JsonProperty("image_exif_rotation")]
        public int ImageExifRotation { get; private set; }

        [JsonProperty("original_w")]
        public long OriginalW { get; private set; }

        [JsonProperty("original_h")]
        public long OriginalH { get; private set; }

        [JsonProperty("deanimate_gif")]
        public string DeanimateGif { get; private set; }

        [JsonProperty("pjpeg")]
        public string Pjpeg { get; private set; }

        [JsonProperty("permalink")]
        public string Permalink { get; private set; }

        [JsonProperty("permalink_public")]
        public string PermalinkPublic { get; private set; }

        [JsonProperty("comments_count")]
        public long CommentsCount { get; private set; }

        [JsonProperty("is_starred")]
        public bool IsStarred { get; private set; }

        [JsonProperty("channels")]
        public List<string> Channels { get; private set; }

        [JsonProperty("groups")]
        public List<string> Groups { get; private set; }

        [JsonProperty("ims")]
        public List<string> Ims { get; private set; }

        [JsonProperty("has_rich_preview")]
        public bool HasRichPreview { get; private set; }
    }
}

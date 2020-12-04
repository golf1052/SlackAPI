using System;
using System.Collections.Generic;
using System.Text;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class Image : IBlockElement
    {
        public string Type { get; private set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }

        public Image(string imageUrl, string altText)
        {
            Type = "image";
            ImageUrl = imageUrl;
            AltText = altText;
        }
    }
}

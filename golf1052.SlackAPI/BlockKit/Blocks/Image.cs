using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.Blocks
{
    public class Image : IBlock
    {
        public string Type { get; private set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public TextObject Title { get; set; }
        public string BlockId { get; set; }

        public Image(string imageUrl, string altText, string title, string blockId)
        {
            if (imageUrl.Length > 3000)
            {
                throw new ArgumentException($"{nameof(imageUrl)} must be 3000 characters or less.");
            }

            if (altText.Length > 2000)
            {
                throw new ArgumentException($"{nameof(altText)} must be 2000 characters or less.");
            }

            if (!string.IsNullOrEmpty(title) && title.Length > 2000)
            {
                throw new ArgumentException($"{nameof(title)} must be 2000 characters or less.");
            }

            if (!string.IsNullOrEmpty(blockId) && blockId.Length > 255)
            {
                throw new ArgumentException($"{nameof(blockId)} must be 255 characters or less.");
            }

            Type = "image";
            ImageUrl = imageUrl;
            AltText = altText;
            if (!string.IsNullOrEmpty(title))
            {
                Title = TextObject.CreatePlainTextObject(title);
            }
            BlockId = blockId;
        }

        public Image(string imageUrl, string altText) : this(imageUrl, altText, null, null)
        {
        }
    }
}

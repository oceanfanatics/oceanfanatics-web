using Cofoundry.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.DestinationWIthImage
{
    public class DestinationWithImageDisplayModel : IPageBlockTypeDisplayModel
    {
        public IHtmlContent Title { get; set; }
        public IHtmlContent SubTitle { get; set; }
        public IHtmlContent Link { get; set; }
        public ImageAssetRenderDetails ImageId { get; set; }
        public bool IsEvent { get; set; }
        public ICollection<DestinationImagesDisplayModel> Images { get; set; }
    }

    public class DestinationImagesDisplayModel
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public ImageAssetRenderDetails Image { get; set; }

    }
}

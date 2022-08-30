using Cofoundry.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.TextWithIcon
{
    public class TextWithIconDisplayModel : IPageBlockTypeDisplayModel
    {
        public IHtmlContent Title { get; set; }
        public IHtmlContent Description { get; set; }
        public IHtmlContent Link { get; set; }
        public ImageAssetRenderDetails ImageId { get; set; }
    }
}

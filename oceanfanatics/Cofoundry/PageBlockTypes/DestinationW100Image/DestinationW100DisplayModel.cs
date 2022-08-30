using Cofoundry.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.DestinationW100Image
{
    public class DestinationW100DisplayModel : IPageBlockTypeDisplayModel
    {
        public IHtmlContent Title { get; set; }
        public IHtmlContent SubTitle { get; set; }
        public IHtmlContent Link { get; set; }
        public ImageAssetRenderDetails Image { get; set; }
        public bool Event { get; set; }
    }
}

using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.LogoOnly
{
    public class LogoOnlyDisplayModel : IPageBlockTypeDisplayModel
    {
        public ImageAssetRenderDetails ImageId { get; set; }
        public string Link { get; set; }
    }
}

using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.LogoOnly
{
    public class LogoOnlyDataModel : IPageBlockTypeDataModel
    {
        [Image]
        public int ImageId { get; set; }
    }
}

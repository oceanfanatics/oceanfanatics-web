using Cofoundry.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.TextOnly
{
    public class TextOnlyDisplayModel : IPageBlockTypeDisplayModel
    {
        public IHtmlContent Title { get; set; }
        public IHtmlContent Description { get; set; }
    }
}

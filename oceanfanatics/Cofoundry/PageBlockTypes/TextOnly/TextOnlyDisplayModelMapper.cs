using Cofoundry.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.TextOnly
{
    public class TextOnlyDisplayModelMapper : IPageBlockTypeDisplayModelMapper<TextOnlyDataModel>
    {
        private readonly IContentRepository _contentRepository;

        public TextOnlyDisplayModelMapper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task MapAsync(PageBlockTypeDisplayModelMapperContext<TextOnlyDataModel> context, PageBlockTypeDisplayModelMapperResult<TextOnlyDataModel> result)
        {
           
            foreach (var input in context.Items)
            {
                var output = new TextOnlyDisplayModel()
                {

                    Title = new HtmlString(input.DataModel.Title),
                    Description = new HtmlString(input.DataModel.Description)
                };
                result.Add(input, output);
            }
        }
    }
}

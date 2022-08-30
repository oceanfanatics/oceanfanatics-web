using Cofoundry.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.TextWithIcon
{
    public class TextWithIconDisplayModelMapper : IPageBlockTypeDisplayModelMapper<TextWithIconDataModel>
    {
        private readonly IContentRepository _contentRepository;

        public TextWithIconDisplayModelMapper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task MapAsync(PageBlockTypeDisplayModelMapperContext<TextWithIconDataModel> context, PageBlockTypeDisplayModelMapperResult<TextWithIconDataModel> result)
        {
            

            foreach (var input in context.Items)
            {
                var image = await _contentRepository
                .ImageAssets()
                .GetById(input.DataModel.ImageId)
                .AsRenderDetails()
                .ExecuteAsync();
                var output = new TextWithIconDisplayModel()
                {

                    Title = new HtmlString(input.DataModel.Title),
                    Description = new HtmlString(input.DataModel.Description),
                    Link = new HtmlString(input.DataModel.Link),
                    ImageId = image
                };
                result.Add(input, output);
            }
        }
    }
}

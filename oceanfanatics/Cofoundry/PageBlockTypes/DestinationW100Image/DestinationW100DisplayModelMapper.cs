using Cofoundry.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.DestinationW100Image
{
    public class DestinationW100DisplayModelMapper : IPageBlockTypeDisplayModelMapper<DestinationW100DataModel>
    {
        private readonly IContentRepository _contentRepository;

        public DestinationW100DisplayModelMapper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task MapAsync(PageBlockTypeDisplayModelMapperContext<DestinationW100DataModel> context, PageBlockTypeDisplayModelMapperResult<DestinationW100DataModel> result)
        {
           
            

            foreach (var input in context.Items)
            {
                var image = await _contentRepository
                .ImageAssets()
                .GetById(input.DataModel.ImageId)
                .AsRenderDetails()
                .ExecuteAsync();

                var output = new DestinationW100DisplayModel()
                {

                    Title = new HtmlString(input.DataModel.Title),
                    SubTitle = new HtmlString(input.DataModel.SubTitle),
                    Link = new HtmlString(input.DataModel.Link),
                    Image = image,
                    Event = input.DataModel.Event
                };
                result.Add(input, output);
            }
        }
    }
}

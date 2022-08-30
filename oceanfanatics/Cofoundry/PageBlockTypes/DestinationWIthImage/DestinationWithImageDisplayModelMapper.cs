using Cofoundry.Core;
using Cofoundry.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.DestinationWIthImage
{
    public class DestinationWithImageDisplayModelMapper : IPageBlockTypeDisplayModelMapper<DestinationWithImageDataModel>
    {
        private readonly IContentRepository _contentRepository;

        public DestinationWithImageDisplayModelMapper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task MapAsync(PageBlockTypeDisplayModelMapperContext<DestinationWithImageDataModel> context, PageBlockTypeDisplayModelMapperResult<DestinationWithImageDataModel> result)
        {

            foreach (var input in context.Items)
            {
                var image = await _contentRepository
                .ImageAssets()
                .GetById(input.DataModel.ImageId)
                .AsRenderDetails()
                .ExecuteAsync();
                var output = new DestinationWithImageDisplayModel()
                {

                    Title = new HtmlString(input.DataModel.Title),
                    SubTitle = new HtmlString(input.DataModel.SubTitle),
                    Link = new HtmlString(input.DataModel.Link),
                    ImageId = image,
                    IsEvent = input.DataModel.IsEvent,
                    Images = EnumerableHelper.Enumerate(input.DataModel.Images).Select(
                        async m => new DestinationImagesDisplayModel()
                        {
                            Title = m.Title,
                            Image = await _contentRepository.ImageAssets().GetById(m.ImageId).AsRenderDetails().ExecuteAsync(),
                            Text = m.Text
                        }).Select(x=>x.Result).ToList()
                };
                result.Add(input, output);
            }
        }
    }
}

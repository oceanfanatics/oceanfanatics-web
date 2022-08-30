using Cofoundry.Core;
using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.Carousel
{
    public class CarouselDisplayModelMapper : IPageBlockTypeDisplayModelMapper<CarouselDataModel>
    {
        private readonly IContentRepository _repository;

        public CarouselDisplayModelMapper(
            IContentRepository repository
            )
        {
            _repository = repository;
        }

        public async Task MapAsync(PageBlockTypeDisplayModelMapperContext<CarouselDataModel> context, PageBlockTypeDisplayModelMapperResult<CarouselDataModel> result)
        {
            var i = 0;
            foreach (var input in context.Items)
            {

                var output = new CarouselDisplayModel();
                output.Slides = EnumerableHelper
                    .Enumerate(input.DataModel.Slides)
                    .Select(async m => new CarouselSliderDisplayModel()
                    {
                        Image = await _repository.ImageAssets().GetById(m.ImageId).AsRenderDetails().ExecuteAsync(),
                        Text = m.Text,
                        //SubText = m.SubText,
                        Title = m.Title,
                        Id = i++,
                        Link = m.Link
                    }).Select(x => x.Result).ToList();

                result.Add(input, output);
            }
        }
    }
}

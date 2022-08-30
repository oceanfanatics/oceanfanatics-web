using Cofoundry.Core;
using Cofoundry.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.ImageAndText
{
    public class ImageAndTextDisplayModelMapper : IPageBlockTypeDisplayModelMapper<ImageAndTextDataModel>
    {
        private readonly IContentRepository _contentRepository;

        public ImageAndTextDisplayModelMapper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task MapAsync(PageBlockTypeDisplayModelMapperContext<ImageAndTextDataModel> context, PageBlockTypeDisplayModelMapperResult<ImageAndTextDataModel> result)
        {
            foreach (var input in context.Items)
            {
                var image = await _contentRepository
                .ImageAssets()
                .GetById(input.DataModel.ImageId)
                .AsRenderDetails()
                .ExecuteAsync();

                var output = new ImageAndTextDisplayModel()
                {

                    Title = input.DataModel.Title,
                    Description = input.DataModel.Description,
                    Image = await _contentRepository.ImageAssets().GetById(input.DataModel.ImageId).AsRenderDetails().ExecuteAsync(),
                    Event = input.DataModel.Event,
                    Link = EnumerableHelper.Enumerate(input.DataModel.Link).Select(
                        async m => new LinkDisplayModel()
                        {
                            Link = m.Link,
                            LinkName = m.LinkName
                           
                        }).Select(x => x.Result).ToList()
                };
                result.Add(input, output);
            }
        }

       
    }
}

using Cofoundry.Core;
using Cofoundry.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.Gallery
{
    public class GalleryDisplayModelMapper : IPageBlockTypeDisplayModelMapper<GalleryDataModel>
    {
        private readonly IContentRepository _repository;

        public GalleryDisplayModelMapper(
            IContentRepository repository
            )
        {
            _repository = repository;
        }

        public async Task MapAsync(PageBlockTypeDisplayModelMapperContext<GalleryDataModel> context, PageBlockTypeDisplayModelMapperResult<GalleryDataModel> result)
        {
            var i = 0;
            foreach (var input in context.Items)
            {

                var output = new GalleryDisplayModel();
                output.Photos = EnumerableHelper
                    .Enumerate(input.DataModel.Photos)
                    .Select(async m => new GallerySliderDisplayModel()
                    {
                        Image = await _repository.ImageAssets().GetById(m.ImageId).AsRenderDetails().ExecuteAsync(),
                    }).Select(x => x.Result).ToList();

                result.Add(input, output);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Epam.AzureWorkShop.Dal.Interfaces;
using Epam.AzureWorkShop.Entities;

namespace Epam.AzureWorkShop.Dal.Implementations
{
    public class MetadataRepository : IMetaDataRepository
	{
        public ImageMetadata Add(ImageMetadata item)
        {
            using (var context = new SqlContext())
            {
                context.Metadata.Add(item);
                context.SaveChanges();
            }

            return item;
        }

		public ImageMetadata Update(ImageMetadata item)
		{
			using (var context = new SqlContext())
			{
				var imageMetadata = context.Metadata.FirstOrDefault(u => u.ImageId == item.ImageId);

				imageMetadata.ThumbnailId = item.ThumbnailId;

				context.SaveChanges();
			}

			return item;
		}

	    public ImageMetadata GetByThumbnailId(Guid id)
	    {
	        using (var context = new SqlContext())
	        {
	            var imageMetadata = context.Metadata.FirstOrDefault(u => u.ThumbnailId == id);

	            return imageMetadata;
	        }
        }

	    public IEnumerable<ImageMetadata> GetAll()
        {
            using (var context = new SqlContext())
            {
                return context.Metadata.ToList();
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new SqlContext())
            {
                var imageMetadata = new ImageMetadata
                {
                    ImageId = id,
                };

                context.Metadata.Attach(imageMetadata);
                context.Metadata.Remove(imageMetadata);

                context.SaveChanges();
            }
        }

        public ImageMetadata GetByNoteId(Guid id)
        {
            using (var context = new SqlContext())
            {
                var imageMetadata = context.Metadata.FirstOrDefault(u => u.NoteId == id);

                return imageMetadata;
            }
        }

		public ImageMetadata GetByImageId(Guid id)
		{
			using (var context = new SqlContext())
			{
				var imageMetadata = context.Metadata.FirstOrDefault(u => u.ImageId == id);

				return imageMetadata;
			}
		}
	}
}
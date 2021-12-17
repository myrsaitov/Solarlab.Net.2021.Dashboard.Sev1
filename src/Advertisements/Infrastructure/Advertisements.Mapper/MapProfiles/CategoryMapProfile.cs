using Mapster;
using Sev1.Advertisements.Contracts.Enums;
using Sev1.Advertisements.Contracts.Contracts.Category;
using Sev1.Advertisements.Contracts.Contracts.Category.Requests;
using Sev1.Advertisements.Contracts.Contracts.Category.Responses;
using System.Linq;

namespace Sev1.Advertisements.MapsterMapper.MapProfiles
{
    public class CategoryMapProfile
    {
        /// <summary>
        /// Считает количество активных объявлений, связанных с данной категорией
        /// </summary>
        /// <param name="src">Категория</param>
        /// <returns></returns>
        private static int Count(Domain.Category src)
        {
            if (src.Advertisements is not null)
            {
                return src.Advertisements
                    .Where(a => a.Status == AdvertisementStatus.Active)
                    .Count();
            }
            else
            {
                return 0;
            }
        }

        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<CategoryCreateRequest, Domain.Category>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.ParentCategoryId, src => src.ParentCategoryId);

            config.NewConfig<CategoryUpdateRequest, Domain.Category>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.ParentCategoryId, src => src.ParentCategoryId);

            config.NewConfig<Domain.Category, CategoryGetResponse>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.ChildCategoriesId, src => src.ChildCategories.Select(a => a.Id).ToList())
                .Map(dest => dest.Count, src => Count(src));

            return config;
        }
    }
}
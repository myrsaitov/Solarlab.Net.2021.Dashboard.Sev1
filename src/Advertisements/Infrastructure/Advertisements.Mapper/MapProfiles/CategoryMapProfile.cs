using Mapster;
using sev1.Advertisements.Contracts.Enums;
using Sev1.Advertisements.Contracts.Contracts.Category;
using Sev1.Advertisements.Contracts.Contracts.Category.Requests;
using Sev1.Advertisements.Contracts.Contracts.Category.Responses;
using System.Linq;

namespace Sev1.Advertisements.MapsterMapper.MapProfiles
{
    public class CategoryMapProfile
    {
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
                .Map(dest => dest.ParentCategoryId, src => src.ParentCategoryId)
                // Считает количество активных объявлений,
                // связанных с данным тагом
                .Map(dest => dest.Count, src => src.Advertisements
                    .Where(a => a.Status == AdvertisementStatus.Active)
                    .Count());

            return config;
        }
    }
}
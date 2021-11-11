using Mapster;
using Sev1.Advertisements.Contracts.Contracts.Category;
using Sev1.Advertisements.Contracts.Contracts.Category.Requests;
using Sev1.Advertisements.Contracts.Contracts.Category.Responses;

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
                .Map(dest => dest.IsDeleted, src => src.IsDeleted);

            return config;
        }
    }
}
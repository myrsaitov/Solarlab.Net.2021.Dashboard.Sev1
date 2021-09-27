using Mapster;
using Sev1.Accounts.Application.Contracts.Category;

namespace Sev1.Accounts.MapsterMapper.MapProfiles
{
    public class CategoryMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<CategoryCreateDto, Domain.Category>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.ParentCategoryId, src => src.ParentCategoryId);

            config.NewConfig<CategoryUpdateDto, Domain.Category>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.ParentCategoryId, src => src.ParentCategoryId);

            config.NewConfig<Domain.Category, CategoryDto>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.ParentCategoryId, src => src.ParentCategoryId)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted);

            return config;
        }
    }
}
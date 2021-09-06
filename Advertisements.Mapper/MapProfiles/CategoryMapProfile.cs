using Mapster;

namespace Sev1.Advertisements.Mapper.MapProfiles
{
    public class CategoryMapProfile
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<Application.Services.Category.Contracts.Create.Request, Domain.Category>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.ParentCategoryId, src => src.ParentCategoryId);

            config.NewConfig<Application.Services.Category.Contracts.Update.Request, Domain.Category>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.ParentCategoryId, src => src.ParentCategoryId);

            config.NewConfig<Domain.Category, Application.Services.Category.Contracts.GetById.Response>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.ParentCategoryId, src => src.ParentCategoryId)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted);

            return config;
        }
    }
}
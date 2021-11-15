using AutoMapper;
using Comments.Contracts;
using Comments.Contracts.AdvertisementChat;
using Comments.Contracts.SellerConsumerChat;
using Comments.Domain.Entities;

namespace Comments.Mapper
{
    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {
            CreateMap<AdvertisementChatDtoRequestGetPaged, AdvertisementIdChatId>();
            CreateMap<AdvertisementChatDtoRequestDeleteChat, AdvertisementIdChatId>();
            CreateMap<AdvertisementChatDtoRequestCreateComment, AdvertisementIdChatId>();

            CreateMap<SellerConsumerChatDtoRequestGetPaged, AdvertisementIdConsumerIdChatId>();
            CreateMap<SellerConsumerChatDtoRequestDeleteChat, AdvertisementIdConsumerIdChatId>();
            CreateMap<SellerConsumerChatDtoRequestCreateComment, AdvertisementIdConsumerIdChatId>();

            /// TODO: username => CommentDtoResponce
            CreateMap<Comment, CommentDtoResponce>();
        }
    }
}

using AutoMapper;
using Comments.Contracts;
using Comments.Domain.Entities;
using System.Collections.Generic;

namespace Comments.Mapper
{
    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {
            /// TODO: username => CommentDtoResponce

            CreateMap<Chat, SellerConsumerChatDtoResponceChatShort>()
                .ForMember(dest => dest.LastMessage, o => o.MapFrom(src => src.Messages[0]));
            CreateMap<Comment, CommentDtoResponce>();

            CreateMap<Chat, CommentDtoResponceChat>();
            //CreateMap<CommentDtoRequestGetChatPaged, CommentDtoResponceChat>();

            CreateMap<CommentDtoRequestCreate, Chat>();
            CreateMap<CommentDtoRequestCreate, Comment>();
        }
    }
}

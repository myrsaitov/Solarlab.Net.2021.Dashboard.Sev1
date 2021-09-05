using AutoMapper;
using Contracts;
using Domain.Entities;

namespace Mapper
{
    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {
            CreateMap<CommentDtoRequestCreate, Comment>();

            CreateMap<CommentDtoRequestUpdate, Comment>();

            /// TODO: username => CommentDtoResponce
            CreateMap<Comment, CommentDtoResponce>();
        }
    }
}

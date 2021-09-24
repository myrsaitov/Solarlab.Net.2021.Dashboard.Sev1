using AutoMapper;
using Comments.Contracts;
using Comments.Domain.Entities;

namespace Comments.Mapper
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

using AutoMapper;
using NotificationsEmail.Contracts;
using NotificationsEmail.Domain.Entities;
using NotificationsEmail.Domain.Enums;
using System;

namespace NotificationsEmail.Mapper
{
    public class LetterMapperProfile : Profile
    {
        /// <summary>
        /// LetterDto => Letter
        /// + Установить:
        ///    SendRequesDate = DateTime.Now
        ///    Status = New
        /// </summary>
        public LetterMapperProfile()
        {
            CreateMap<LetterDto, Letter>()
                .ForMember(letter => letter.SendRequesDate,
                    opt => opt.MapFrom(time => DateTime.Now))
                .ForMember(letter => letter.Status,
                    opt => opt.MapFrom(status => LetterStatus.New));
        }
    }
}

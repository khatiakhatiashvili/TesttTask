using AutoMapper;
using TestTask.Core.Application.Commons;
using TestTask.Core.Application.DTOs;
using TestTask.Core.Domain.Entities;

namespace TestTask.Core.Application.Mappings
{
    public sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {           
            CreateMap<Movie, GetMovieDto>().ReverseMap();
            CreateMap<WatchList, GetWatchListDto>().ReverseMap();
            CreateMap<Movie, GetPaginationDto<GetMovieDto>>().ReverseMap();
            CreateMap(typeof(Pagination<>), typeof(GetPaginationDto<>)).ReverseMap();

            
            //CreateMap<CreateUserProfileCommand.Request, UserProfile>()
            //    .ForMember(dto => dto.DateCreated, opt => opt.MapFrom(src => DateTime.Now))
            //    .ReverseMap();

            //CreateMap<UpdateUserProfileCommand.Request, UserProfile>()
            //    .ForMember(dto => dto.DateUpdated, opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();



        }
    }
}

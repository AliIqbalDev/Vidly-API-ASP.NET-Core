using System;
using AutoMapper;
using Vidly_RESTful_API.Dtos;
using Vidly_RESTful_API.Models;

namespace Vidly_RESTful_API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Customer, CustomerDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Movie, MovieDto>()
                .ForMember(mDto => mDto.Genre,
                    opt => opt.MapFrom(m => new GenreDto {Id = m.Genre.Id, Name = m.Genre.Name}));
            CreateMap<Rental, RentalDto>();

            // API Resource to Domain
            CreateMap<CustomerForCreationDto, Customer>();
            CreateMap<CustomerForUpdateDto, Customer>();
            CreateMap<GenreForCreationDto, Genre>();
            CreateMap<GenreForUpdateDto, Genre>();
            CreateMap<MovieForCreationDto, Movie>();
            CreateMap<MovieForUpdateDto, Movie>();
            CreateMap<RentalForCreationDto, Rental>()
                .ForMember(r => r.DateOut,
                    opt => opt.MapFrom(rDto => DateTime.Now));
        }
    }
}
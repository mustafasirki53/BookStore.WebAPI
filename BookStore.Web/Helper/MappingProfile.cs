using System;
using AutoMapper;
using BookStore.WebAPI.Data;
using BookStore.WebAPI.Models;

namespace BookStore.WebAPI.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookModel>().ReverseMap();
    }
}

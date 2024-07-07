using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.DTOs.Account;
using Service.DTOs.Admin.Authors;
using Service.DTOs.Admin.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public  class MappingProfile : Profile
    {


        public MappingProfile()
        {
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorEditDto, Author>();


            CreateMap<BookCreateDto, Book>();
            CreateMap<BookEditDto, Book>();


            CreateMap<Book, BookDto>().ForMember(d => d.Authors, opt => opt.MapFrom(s => s.BookAuthors.Select(m => new AuthorDto
            {
                Id = m.Author.Id,
                FullName = m.Author.FullName,
                Email = m.Author.Email,
                Address = m.Author.Address,
                Age = m.Author.Age
            }).ToList()));

            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();
            CreateMap<IdentityRole, RoleDto>();

        }
    }
}

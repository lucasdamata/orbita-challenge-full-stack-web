﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserAPI.Controllers;
using UserAPI.Models;

namespace UserAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, IdentityUser<int>>();
        }
    }
}

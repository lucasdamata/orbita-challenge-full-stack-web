using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using UserAPI.Controllers;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class RegisterService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result Create(CreateUserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(userIdentity, userDTO.Password);
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Error in register user");
        }
    }
}

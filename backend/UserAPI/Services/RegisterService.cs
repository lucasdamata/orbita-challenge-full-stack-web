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
        private RoleManager<IdentityRole<int>> _roleManager;

        public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Result Create(CreateUserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(userIdentity, userDTO.Password);
            // var role = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;
            // var userRole = _userManager.AddToRoleAsync(userIdentity, "admin").Result;
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Error in register user");
        }
    }
}

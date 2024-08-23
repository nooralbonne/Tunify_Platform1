﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IAccount
    {
        // Add register
        public Task<RegisterDto> Register(RegisterDto registerdUserDto, ModelStateDictionary modelState);

        // Add login 
        public Task<LoginDto> UserAuthentication(string username, string password);

    }

}


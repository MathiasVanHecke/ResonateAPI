﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resonate.Models;
using Resonate.Repositories;

namespace Resonate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost()]
        public bool RegisterUser([FromBody] User user)
        {
            try
            {

                Boolean succes = _userRepo.RegisterUser(user);
                if (succes)
                {
                    return succes;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public User GetUser(string id)
        {
            return _userRepo.GetUser(id);
        }
    }
}

using AuthProjectVol1.Context;
using AuthProjectVol1.Jwt;
using AuthProjectVol1.Models;
using AuthProjectVol1.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthProjectVol1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class LoginController : ControllerBase
    {
        readonly AuthContext _context;
        readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration, AuthContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("[action]")]
        public async Task<bool> Create([FromForm] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        [HttpPost("[action]")]
        public async Task<Token> Login([FromForm] UserLogin userLogin)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await _context.SaveChangesAsync();

                return token;
            }
            return null;
        }


        }
}

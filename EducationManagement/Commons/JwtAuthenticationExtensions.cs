﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using EducationManagement.Dtos;
using EducationManagement.Dtos.OutputDtos;
using Microsoft.IdentityModel.Tokens;

namespace EducationManagement.Commons
{
    public static class JwtAuthenticationExtensions
    {
        public static string CreateToken(LoginResultDto result)
        {
            var issuedAt = DateTime.UtcNow;
            //set the time when it expires
            var expires = DateTime.UtcNow.AddDays(7);
            
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(Constants.UserIdClaimKey, result.User.Id.ToString()),
                new Claim(Constants.UsernameClaimKey, result.User.Username),
                new Claim(Constants.GroupIdClaimKey, result.Group.Id.ToString()), 
                new Claim(Constants.GroupNameClaimKey, result.Group.Name)
            });

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(Constants.TokenSecretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token = tokenHandler.CreateJwtSecurityToken(
                issuer: Constants.ValidIssuer, 
                audience: Constants.ValidAudience,
                subject: claimsIdentity, 
                notBefore: issuedAt, 
                expires: expires, 
                signingCredentials: signingCredentials);
            return $"Bearer {tokenHandler.WriteToken(token)}";
        }

        public static TokenInformation ExtractTokenInformation(string token)
        {
            try
            {
                if (token.StartsWith("Bearer ")) token = token.Substring(7);
                var handler = new JwtSecurityTokenHandler();

                var jwtSecurityToken = handler.ReadJwtToken(token);

                return new TokenInformation
                {
                    UserId = Convert.ToInt32(jwtSecurityToken.Claims.First(c => c.Type == Constants.UserIdClaimKey).Value),

                    Username = jwtSecurityToken.Claims.First(c => c.Type == Constants.UserIdClaimKey).Value,

                    GroupId = Convert.ToInt32(jwtSecurityToken.Claims.First(c => c.Type == Constants.GroupIdClaimKey).Value),

                    GroupName = jwtSecurityToken.Claims.First(c => c.Type == Constants.GroupNameClaimKey).Value
                };
            }
               
            catch
            {
                return null;
            }
        }

        public static string GetAuthorizationHeader(this HttpRequestMessage request)
        {
            return request.Headers.GetValues("Authorization").First();
        }
    }
}
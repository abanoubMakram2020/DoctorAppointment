
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SharedKernal.Common;
using SharedKernal.Common.Configuration;
using SharedKernal.Common.Enum;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SharedKernal.Middlewares.JWTSettings
{
    public class UserClaim
    {
        public SecurityEnum.TokenInfo Name { get; set; }
        public string Value { get; set; }
    }
    public interface ITokenHandler
    {
        string CreateToken(List<UserClaim> userClaims, SecurityEnum.Audiance audience);
        string GetTokenData(SecurityEnum.TokenInfo tokenInfo, ClaimsPrincipal user);
        List<Claim> GetTokenData(HttpRequest httpRequest);
        string GetToken(HttpRequest httpRequest);
        bool IsValidToken(string token);
        Dictionary<string, string> GetBasicTokenData(HttpRequest httpRequest);
    }

    public class TokenHandler : ITokenHandler
    {


        #region Methods
        public string CreateToken(List<UserClaim> userClaims, SecurityEnum.Audiance audience)
        {
            string audianceUrls = string.Empty;

            switch (audience)
            {
                case SecurityEnum.Audiance.Web:
                    audianceUrls = AuthSettings.WebAudiance;
                    break;
                case SecurityEnum.Audiance.Mobile:
                    audianceUrls = AuthSettings.MobileAudiance;
                    break;
            }
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(AuthSettings.Secret);

            List<Claim> claims = new List<Claim>();
            if (userClaims?.Count > default(int))
            {
                claims = userClaims.Select(x => new Claim(x.Name.ToString(), x.Value)).ToList();
            }

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(AuthSettings.TokenExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.Now,
                Issuer = AuthSettings.Issuer,
                Audience = audianceUrls
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
        public string GetTokenData(SecurityEnum.TokenInfo tokenInfo, ClaimsPrincipal user)
        {
            Claim userIdClaim = user.Claims.FirstOrDefault(x => x.Type == tokenInfo.ToString());
            return userIdClaim != null ? userIdClaim.Value : string.Empty;
        }
        public List<Claim> GetTokenData(HttpRequest httpRequest)
        {
            List<Claim> tokenData = null;
            if (httpRequest.Headers.ContainsKey("Authorization"))
            {
                var header = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(httpRequest.Headers["Authorization"]);
                if (header != null)
                {
                    tokenData = new JwtSecurityTokenHandler().ReadJwtToken(header.Parameter).Claims.ToList();
                }
            }
            return tokenData;
        }
        public bool IsValidToken(string token)
        {
            return true;
        }
        public Dictionary<string, string> GetBasicTokenData(HttpRequest httpRequest)
        {
            var claims = new Dictionary<string, string>();
            if (httpRequest.Headers.ContainsKey("Authorization"))
            {
                var header = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(httpRequest.Headers["Authorization"]);
                if (header != null)
                {
                    claims = JsonConvert.DeserializeObject<Dictionary<string, string>>(GeneralUtilities.Decrypt(header.Parameter));
                    claims["UserName"] = GeneralUtilities.Decrypt(claims["UserName"]);
                    claims["Password"] = GeneralUtilities.Decrypt(claims["Password"]);
                }
                return claims;
            }
            return null;
        }
        public string GetToken(HttpRequest httpRequest)
        {
            if (httpRequest.Headers.ContainsKey("Authorization"))
            {
                var header = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(httpRequest.Headers["Authorization"]);
                if (header != null)
                {
                    return header.Parameter;
                }
            }
            return string.Empty;
        }

        #endregion
    }
}

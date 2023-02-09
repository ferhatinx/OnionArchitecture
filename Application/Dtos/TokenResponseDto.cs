using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class TokenResponseDto
    {
        public TokenResponseDto(string token,DateTime expireDate)
        {
            this.Token = token;
            this.ExpireDate = expireDate;
        }
        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
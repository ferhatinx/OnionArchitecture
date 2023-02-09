using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string validAudience ="http://localhost";
        public const string validIssuer = "http://localhost";
        public const int expire = 5;
        public const string securityKey ="ferhatferhat.1";
    }
}
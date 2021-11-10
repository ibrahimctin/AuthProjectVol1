using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthProjectVol1.Jwt
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}

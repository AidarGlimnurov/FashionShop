using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.SupportData
{
    public class AuthInfo
    {
        public static string CookieName = "AuthCookie";
        public string Key { get; set; } = string.Empty;
        public UserDto User { get; set; } = new UserDto();

    }
}

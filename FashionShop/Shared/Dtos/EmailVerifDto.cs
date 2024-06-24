using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.Dtos
{
    public class EmailVerifDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsAcivate { get; set; } = false;
        public DateTime CreatAt { get; set; } = DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Model
{
    public class ResponseAuth
    {
        public bool sucess { get; set; }
        public string message { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}

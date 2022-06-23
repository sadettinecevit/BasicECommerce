using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerce.DAL
{
    public class Response
    {
        public bool IsSucces { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}

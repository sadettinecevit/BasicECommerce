using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerce.DAL.Response
{
    public class BaseResponse
    {
        public bool IsSucces { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}

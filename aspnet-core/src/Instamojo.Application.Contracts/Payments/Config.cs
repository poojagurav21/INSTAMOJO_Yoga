using System;
using System.Collections.Generic;
using System.Text;

namespace Instamojo.Payments
{
    public class Config
    {
        public string grant_type { get; set; }
        
         public string client_id { get; set; }
        public string client_secret { get; set; }
    }

    public class Auth
    {
        public string access_token { get; set; }
    }

}

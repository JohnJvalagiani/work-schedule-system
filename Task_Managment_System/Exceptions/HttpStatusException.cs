﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace service.server.Exceptions
{
    
        public class HttpStatusException : Exception
        {
            public HttpStatusCode Status { get; private set; }

            public HttpStatusException(HttpStatusCode status, string msg) : base(msg)
            {
                Status = status;
            }
        }

    
}

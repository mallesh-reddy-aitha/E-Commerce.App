using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.App.API.Errors
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode, string message, string details)
        {
            this.Details = details;
            this.Message = message;
            this.StatusCode = statusCode;
        }

        public string Details { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }
    }
}

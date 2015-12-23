using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace DotNextRZD.PublicApi.Controllers
{
    public class ErrorResponse
    {
        public int Code { get; set;  }
        public string Message { get; set; }

        public static HttpResponseException CreateException(HttpStatusCode statusCode, string message)
        {
            var er = new ErrorResponse()
            {
                Code = 1,
                Message = message
            };

            return new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(JsonConvert.SerializeObject(er, Formatting.Indented),
                    Encoding.UTF8,
                    "application/json")
            });
        }
    }
}
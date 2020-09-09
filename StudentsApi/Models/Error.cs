using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudentsApi.Errors;

namespace StudentsApi.Models
{
    public class Error
    {
        [JsonProperty("type")]
        public ErrorType Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSF.NexGen.Shared.Wrappers
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        { }

        public ApiResponse(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }

        public ApiResponse(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public bool Succeeded { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        public string[]? Errors { get; set; }

        public static ApiResponse<T> Fail(string errorMessage) => new() { Succeeded = false, Message = errorMessage };
    }
}

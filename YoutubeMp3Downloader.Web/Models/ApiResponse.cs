using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoutubeMp3Downloader.Web.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public ApiResponse(string message)
        {
            IsSuccess = false;
            Message = message;
        }

        public ApiResponse()
        {

        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

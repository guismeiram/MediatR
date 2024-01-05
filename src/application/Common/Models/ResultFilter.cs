using FluentResults;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using OkResult = Microsoft.AspNetCore.Mvc.OkResult;

namespace application.Common.Models
{
    public class Result<T>
    {
        public HttpStatusCode StatusCode { get; }

        public bool Sucess { get; }
        public string ErrorMessage { get; }
        public T Data { get; }

        public Result(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        private Result(bool success, string errorMessage, T data, HttpStatusCode statusCode)
        {
            Sucess = success;
            ErrorMessage = errorMessage;
            Data = data;
            StatusCode = statusCode;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, string.Empty, data, HttpStatusCode.OK);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, errorMessage, default, HttpStatusCode.OK);
        }
    }
}

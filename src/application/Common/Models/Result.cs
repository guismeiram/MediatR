using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Common.Models
{
    public class Result<T>
    {
        public bool Sucess { get; }
        public string ErrorMessage { get; }
        public T Data { get; }

        private Result(bool success, string errorMessage, T data)
        {
            Sucess = success;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, string.Empty, data);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, errorMessage, default);
        }
    }
}

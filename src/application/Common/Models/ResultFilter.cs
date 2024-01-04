using FluentResults;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http.Results;
using OkResult = Microsoft.AspNetCore.Mvc.OkResult;

namespace application.Common.Models
{
    public class ResultFilter : IAsyncResultFilter
    {
        private sealed class Response
        {
            public object Value { get; set; }
            public bool IsSuccess { get; set; }
            public bool IsFailed { get; set; }

            public string[] Errors { get; set; } = new string[] { };
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var json = context?.Result?.GetType()?.Name switch
            {
                nameof(OkResult) => JsonConvert.SerializeObject(Result.Ok()),
                nameof(OkObjectResult) => JsonConvert.SerializeObject((context.Result as OkObjectResult).Value),
                _ => JsonConvert.SerializeObject(Result.Fail($"Não há filtros de saída definidos para o tipoo {context.Result.GetType().Name}"))
            } ?? JsonConvert.SerializeObject(Result.Fail("o contexto não tem resultados"));

            var data = JsonConvert.DeserializeObject<Response>(json);
            context.Result = new OkObjectResult(data);

            await next();
        }
    }
}

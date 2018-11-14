using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace ServicePropertie.ExceptionHandlers
{
    internal class CustomErrorHandler: ExceptionHandler
    {
        private readonly IExceptionHandler _innerHandler;

        public IExceptionHandler InnerHandler
        {
            get { return _innerHandler; }
        }
        public CustomErrorHandler(IExceptionHandler innerHandler)
        {
            if (innerHandler == null)
                throw new ArgumentNullException(nameof(innerHandler));
            _innerHandler = innerHandler;
        }

        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new
                {
                    Message = context.Exception.Message
                });
            response.Headers.Add("Error", context.Exception.Message);
            context.Result = new ResponseMessageResult(response);
            return Task.FromResult(0);
        }
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new InternalServerErrorResult(context.Request); 
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }
}
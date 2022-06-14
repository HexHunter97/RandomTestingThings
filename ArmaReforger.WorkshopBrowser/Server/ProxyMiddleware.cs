using ArmaReforger.WorkshopBrowser.Shared;
using Yarp.ReverseProxy.Forwarder;

namespace ArmaReforger.WorkshopBrowser.Server
{
    public class ProxyMiddleware
    {
        private const string ArmaWorkshopBaseUrl = "https://api-ar-workshop.bistudio.com/";

        private readonly RequestDelegate _next;

        public ProxyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IHttpForwarder forwarder, ILogger<ProxyMiddleware> logger)
        {
            if (context.Request.Headers.TryGetValue(Constants.ProxyHeaderName, out _))
            {
                await forwarder.SendAsync(
                    context, 
                    ArmaWorkshopBaseUrl, 
                    new LoggingHttpMessageInvoker(new SocketsHttpHandler(), logger));
            }
            else
            {
                await _next(context);
            }
        }

        private class LoggingHttpMessageInvoker : HttpMessageInvoker
        {
            private readonly ILogger _logger;

            public LoggingHttpMessageInvoker(HttpMessageHandler handler, ILogger logger) : base(handler)
            {
                _logger = logger;
            }

            public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var pendingRequest = base.SendAsync(request, cancellationToken);

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    return LogRequestAndResponse(request, pendingRequest);
                }

                return pendingRequest;
            }

            private async Task<HttpResponseMessage> LogRequestAndResponse(HttpRequestMessage request, Task<HttpResponseMessage> pendingRequest)
            {
                _logger.LogInformation($"Sending request: {request}");
                var response = await pendingRequest;
                _logger.LogInformation($"Received response: {response}");

                return response;
            }
        }
    }
}

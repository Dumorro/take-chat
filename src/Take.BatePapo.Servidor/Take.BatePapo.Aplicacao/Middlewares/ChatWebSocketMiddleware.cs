using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Take.BatePapo.Aplicacao.Servicos;

namespace Take.BatePapo.Aplicacao.Middlewares
{
    public class ChatWebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly MotorDeEnvioDeMensagem _motorDeEnvioDeMensagem;

        public ChatWebSocketMiddleware(RequestDelegate next, MotorDeEnvioDeMensagem motorDeEnvioDeMensagem)
        {
            _next = next;
            _motorDeEnvioDeMensagem = motorDeEnvioDeMensagem;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await _next.Invoke(context);
                return;
            }

            await _motorDeEnvioDeMensagem.ProcessarWebSocket(context);
        }
    }
}

using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Take.BatePapo.Dominio.Entidades
{
    public class EnvioDeMensagem
    {
        private readonly string _mensagem;
        private readonly WebSocket _socket;

        public EnvioDeMensagem(string mensagem, WebSocket socket)
        {
            _mensagem = mensagem;
            _socket = socket;
        }

        public async Task Enviar()
        {
            var bytesDaMensagem = Encoding.UTF8.GetBytes(_mensagem);
            var buffer = new ArraySegment<byte>(bytesDaMensagem);
            const bool fimDeMensagem = true;
            await _socket.SendAsync(buffer, WebSocketMessageType.Text, fimDeMensagem, default(CancellationToken));
        }
    }
}

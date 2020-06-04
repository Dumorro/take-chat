using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Take.BatePapo.Dominio.Entidades;
using Take.BatePapo.Dominio.Interfaces;

namespace Take.BatePapo.Aplicacao.Servicos
{
    /// <summary>
    /// Serviço para orquestrar as chamadas de WebSockets e gestão da sala de bate papo.
    /// </summary>
    public class MotorDeEnvioDeMensagem
    {        
        private readonly IBatePapo _batePapo;
        public MotorDeEnvioDeMensagem(IBatePapo batePapo)
        {
            _batePapo = batePapo;
        }

        /// <summary>
        /// Mantem o processamento de requisições do socket até ser o fechamento da conexão do socket ser relizada
        /// </summary>
        // Uma refatoração do loop de processamento para handlers tornaria mais elegante a solução.
        public async Task ProcessarWebSocket(HttpContext context)
        {
            CancellationToken ct = context.RequestAborted;
            if (ct.IsCancellationRequested)
                return;

            WebSocket socketParticipante = await context.WebSockets.AcceptWebSocketAsync();
            var idParticipante = Guid.NewGuid();
            await _batePapo.AdicionarParticipante(idParticipante, socketParticipante);
            while (true)
            {
                var response = await ProcessarMensagem(socketParticipante, ct);
                var mensagem = CriacaoDeMensagemDeAviso.Montar(response);
                if (string.IsNullOrEmpty(response) || mensagem == null || string.IsNullOrWhiteSpace(mensagem.Montar()))
                {
                    if (socketParticipante.State != WebSocketState.Open)
                        break;
                    continue;
                }
                if (!_batePapo.VerificarApelidoExistente(mensagem.ApelidoDoParticipante))
                {
                    _batePapo.DefinirApelidoDoParticipante(mensagem.ApelidoDoParticipante, socketParticipante);
                }
                foreach (var socketDestinatario in _batePapo.ListarUsuarioParaEnvioMensagem(idParticipante, mensagem))
                {
                    if (socketDestinatario.State != WebSocketState.Open)
                        continue;
                    await EnviarMensagem(socketDestinatario, mensagem.Montar(), ct);
                }
            }
            await RemoverParticipante(socketParticipante, idParticipante, ct);
        }

        private async Task RemoverParticipante(WebSocket socketParticipante, Guid idParticipante, CancellationToken ct)
        {
            var apelido = _batePapo.BuscarApelidoDoParticipante(idParticipante);
            _batePapo.RemoverParticipante(idParticipante);
            await socketParticipante.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", ct);
            socketParticipante.Dispose();
        }

        private async Task EnviarMensagem(WebSocket socket, string data, CancellationToken ct = default(CancellationToken))
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var segment = new ArraySegment<byte>(buffer);
            await socket.SendAsync(segment, WebSocketMessageType.Text, true, ct);           
        }

        private async Task<string> ProcessarMensagem(WebSocket socket, CancellationToken ct = default(CancellationToken))
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    ct.ThrowIfCancellationRequested();
                    result = await socket.ReceiveAsync(buffer, ct);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);

                ms.Seek(0, SeekOrigin.Begin);
                if (result.MessageType != WebSocketMessageType.Text)
                {
                    return null;
                }

                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}

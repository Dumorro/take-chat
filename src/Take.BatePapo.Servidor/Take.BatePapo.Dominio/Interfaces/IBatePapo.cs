using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Take.BatePapo.Dominio.Dtos;

namespace Take.BatePapo.Dominio.Interfaces
{
    public interface IBatePapo
    {
        Task<bool> AdicionarParticipante(Guid idUsuario, WebSocket socket);
        void RemoverParticipante(Guid idParticipante);
        WebSocket BuscarWebSocketDoParticipante(Guid idParticipante);
        List<WebSocket> ListarSocketsParaEnvioMensagem(Guid idParticipante, Mensagem mensagem);
        void DefinirApelidoDoParticipante(string apelido, WebSocket webSocketDoParticipante);
        bool VerificarApelidoExistente(string apelido);
    }
}

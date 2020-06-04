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
        string BuscarApelidoDoParticipante(Guid idUsuario);
        void RemoverParticipante(Guid idParticipante);
        WebSocket BuscarWebSocketDoParticipante(Guid idParticipante);
        List<WebSocket> ListarUsuarioParaEnvioMensagem(Guid idParticipante, Mensagem mensagem);
        void DefinirApelidoDoParticipante(string apelido, WebSocket webSocketDoParticipante);
        bool VerificarApelidoExistente(string apelido);
    }
}

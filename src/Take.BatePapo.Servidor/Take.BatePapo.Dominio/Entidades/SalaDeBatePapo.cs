using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Enumeracoes;
using Take.BatePapo.Dominio.Interfaces;

namespace Take.BatePapo.Dominio.Entidades
{
    public class SalaDeBatePapo : IBatePapo
    {
        public string Nome { get; private set; }
        private readonly ConcurrentDictionary<Guid, WebSocket> _participantes =
            new ConcurrentDictionary<Guid, WebSocket>();
        private readonly ConcurrentDictionary<Guid, string> _apelidos = 
            new ConcurrentDictionary<Guid, string>();

        public SalaDeBatePapo()
        {
            Nome = Guid.NewGuid().ToString();
        }

        private Guid BuscarIdDoParticipante(string apelido)
        {
            return _apelidos.FirstOrDefault(p => p.Value == apelido).Key;
        }

        public WebSocket BuscarWebSocketDoParticipante(Guid idUsuario)
        {
            return _participantes[idUsuario];
        }

        public List<Guid> ListarIdsDosParticipantes()
        {
            return _participantes.Select(p => p.Key).ToList();
        }

        public bool VerificarApelidoExistente(string apelido)
        {
            return _apelidos.Where(a => a.Value == apelido).Count() > 0;
        }

        public void DefinirApelidoDoParticipante(string apelido, WebSocket webSocket)
        {
            var participante = _participantes.FirstOrDefault(p => p.Value == webSocket);
            _apelidos.TryAdd(participante.Key, apelido);
        }

        public async Task<bool> AdicionarParticipante(Guid idUsuario, WebSocket socket) => 
            await Task.Run(()=> _participantes.TryAdd(idUsuario, socket));

        public void RemoverParticipante(Guid idUsuario)
        {
            WebSocket socket;
            string apelido;
            _apelidos.TryRemove(idUsuario, out apelido);
            _participantes.TryRemove(idUsuario, out socket);
        }

        public List<WebSocket> ListarSocketsParaEnvioMensagem(Guid idUsuario, Mensagem mensagem)
        {
            if (mensagem != null && mensagem.TipoVisibilidadeDaMensagem == ETipoVisibilidadeDaMensagem.Privada)
            {
                var idDestinatario = BuscarIdDoParticipante(mensagem.Destinatario);
                if (idDestinatario == new Guid())
                    return new List<WebSocket>();
                var socketDestinatario = BuscarWebSocketDoParticipante(idDestinatario);
                var socketUsuario = BuscarWebSocketDoParticipante(idUsuario);

                return new List<WebSocket> { socketDestinatario, socketUsuario };
            }

            return _participantes.Select(p => p.Value).ToList();
        }
    }
}

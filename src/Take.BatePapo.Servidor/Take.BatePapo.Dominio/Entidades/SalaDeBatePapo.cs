using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

namespace Take.BatePapo.Dominio.Entidades
{
    public class SalaDeBatePapo
    {
        private readonly ConcurrentDictionary<string, WebSocket> _participantes = new ConcurrentDictionary<string, WebSocket>();

        public IEnumerable<string> Participantes => _participantes.Select(k => k.Key);

        public bool AdicionarParticipante(string apelido, WebSocket socket) => _participantes.TryAdd(apelido, socket);

        public bool RemoverParticipante(string apelido) => _participantes.TryRemove(apelido, out var socket);
    }
}

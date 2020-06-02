using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Enumeracoes;

namespace Take.BatePapo.Dominio.Entidades
{
    public class BatePapo
    {
        private const string _todosParticipantes = "Todos";

        private readonly ConcurrentDictionary<string, WebSocket> _participantes =
            new ConcurrentDictionary<string, WebSocket>();

        private readonly ValidadorDeMensagem _validacaoDeMensagem = new ValidadorDeMensagem();

        public IEnumerable<string> Participantes => _participantes.Select(k => k.Key);

        public bool AdicionarParticipante(string apelido, WebSocket socket) => _participantes.TryAdd(apelido, socket);

        public bool RemoverParticipante(string apelido) => _participantes.TryRemove(apelido, out var socket);

        public async Task Enviar(Mensagem mensagem)
        {
            new ValidadorDeMensagem().Validate(mensagem);
            var destinatarios = FiltroParaEnvioDeMensagem.Filtrar(mensagem, _participantes);
            await DispararMensagem(mensagem, destinatarios);
        }

        private async Task DispararMensagem(Mensagem mensagem, List<string> destinatorios)
        {
            await Task.Run(() =>
                destinatorios.ForEach(async d =>
                    await new EnvioDeMensagem(CriacaoDeMensagemDeParticipante.Montar(mensagem), _participantes[d])
                        .Enviar())
            );
        }
    }
}

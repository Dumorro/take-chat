using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Enumeracoes;

namespace Take.BatePapo.Dominio.Entidades
{
    public class FiltroParaEnvioDeMensagem
    {
        public static List<string> Filtrar(Mensagem mensagem, ConcurrentDictionary<string, WebSocket> participantes)
        {
            var tiposMensagemDireta = new List<ETipoDaMensagem>(){ ETipoDaMensagem.Aberta, ETipoDaMensagem.Privada };
            return participantes.Where(d => !d.Key.Equals(mensagem.ApelidoDoParticipante) && mensagem.Tipo != ETipoDaMensagem.Comando
                                       && (
                                       (string.IsNullOrWhiteSpace(mensagem.Destinatario) && mensagem.Tipo == ETipoDaMensagem.Todos)
                                       ||
                                       (d.Key.Equals(mensagem.Destinatario) && tiposMensagemDireta.Contains(mensagem.Tipo))
                                       )).Select(d => d.Key).ToList();
        }
    }
}

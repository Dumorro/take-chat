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
            return participantes.Where(d => !d.Key.Equals(mensagem.ApelidoDoParticipante) && mensagem.Tipo != ETipoDaMensagem.Comando 
            && ((mensagem.Tipo == ETipoDaMensagem.Aberta || mensagem.Tipo== ETipoDaMensagem.Privada) && d.Key.Equals(mensagem.Destinatario))
            ).
                                                  Select(d => d.Key).ToList();

        }
    }
}

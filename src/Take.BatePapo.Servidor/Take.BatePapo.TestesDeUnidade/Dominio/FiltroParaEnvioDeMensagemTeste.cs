using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Entidades;
using Take.BatePapo.Dominio.Enumeracoes;
using ExpectedObjects;
using Xunit;
using System.Security.Cryptography;

namespace Take.BatePapo.TestesDeUnidade.Dominio
{
    public class FiltroParaEnvioDeMensagemTeste
    {
        private readonly ConcurrentDictionary<string, WebSocket> _participantes =
            new ConcurrentDictionary<string, WebSocket>();

        public FiltroParaEnvioDeMensagemTeste()
        {
            Setup();
        }
        private void Setup()
        {
            _participantes.TryAdd("Joaquim", null);
            _participantes.TryAdd("Mara", null);
            _participantes.TryAdd("Luiz", null);
            _participantes.TryAdd("Rosa", null);
            _participantes.TryAdd("Eduarda", null);
        }

        //[Fact]
        //public void DeveRetornarTodosParticipantesParaEnvioDaMensagem()
        //{//o própio usuário deve ficar de fora da lista.
        //    var apelidoDoParticipante = _participantes.Keys.FirstOrDefault();
        //    const string salaDoBatePapo = "Sala1";
        //    const string destinatario = null;
        //    const string textoDaMensagem = "oi, alguem quer tc?";
        //    const ETipoDaMensagem tipoDaMensagem = ETipoDaMensagem.Todos;
        //    var usuariosEsperados = _participantes.Keys.Where(k => !k.Equals(apelidoDoParticipante))
        //        .Select(k => k).ToList();
        //    var mensagem = new Mensagem(salaDoBatePapo, apelidoDoParticipante, destinatario, textoDaMensagem, tipoDaMensagem);

        //    var usuariosObtidos = FiltroParaEnvioDeMensagem.Filtrar(mensagem, _participantes);

        //    usuariosEsperados.ToExpectedObject(o => o.UseOrdinalComparison()).ShouldMatch(usuariosObtidos);
        //}

        //[Theory]
        //[InlineData(ETipoDaMensagem.Aberta)]
        //[InlineData(ETipoDaMensagem.Privada)]
        //public void DeveRetornarSomenteParticipanteDestinatarioDaMensagem(ETipoDaMensagem tipoDaMensagem)
        //{
        //    var apelidoDoParticipante = _participantes.Keys.FirstOrDefault();
        //    const string salaDoBatePapo = "Sala1";
        //    const string textoDaMensagem = "oi, quer tc?";
        //    var destinatario = _participantes.Keys.Where(k => !k.Equals(apelidoDoParticipante))
        //        .FirstOrDefault();
        //    var mensagem = new Mensagem(salaDoBatePapo, apelidoDoParticipante, destinatario, textoDaMensagem, tipoDaMensagem);

        //    var usuarioObtido = FiltroParaEnvioDeMensagem.Filtrar(mensagem, _participantes).FirstOrDefault();

        //    Assert.Equal(destinatario, usuarioObtido);
        //}

        //[Fact]
        //public void NaoDeveRetornarUsuarioQuandoForMensagemDeComando()
        //{
        //    var apelidoDoParticipante = _participantes.Keys.FirstOrDefault();
        //    const string salaDoBatePapo = "Sala1";
        //    const string textoDaMensagem = "/exit";
        //    const string destinatario = "";
        //    ETipoDaMensagem tipoDaMensagem = ETipoDaMensagem.Comando;
        //    var mensagem = new Mensagem(salaDoBatePapo, apelidoDoParticipante, destinatario, textoDaMensagem, tipoDaMensagem);
        //    var usuariosEsperados = new { };

        //    var usuariosObtidos = FiltroParaEnvioDeMensagem.Filtrar(mensagem, _participantes);

        //    usuariosEsperados.ToExpectedObject(o => o.UseOrdinalComparison()).ShouldMatch(usuariosEsperados);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using ExpectedObjects;
using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Entidades;
using Take.BatePapo.Dominio.Enumeracoes;
using Xunit;

namespace Take.BatePapo.TestesDeUnidade.Dominio
{
    public class SalaDeBatePapoTestes
    {
        [Fact]
        public async void DeveAdicionarWebSocketDoUsuario()
        {
            var participante = Guid.NewGuid();
            var webSocketEsperado = new ClientWebSocket();
            var batePapo = new SalaDeBatePapo();
            await batePapo.AdicionarParticipante(participante, webSocketEsperado);

            var webSocketObtido = batePapo.BuscarWebSocketDoParticipante(participante);

            Assert.Equal(webSocketEsperado, webSocketObtido);
        }

        [Fact]
        public async void NaoDeveAdicionarUsuarioJaExistenteAoBatePapo()
        {
            var participante = Guid.NewGuid();
            var webSocketParticipante = new ClientWebSocket();
            var batePapo = new SalaDeBatePapo();
            var participantesEsperados = new List<Guid> { participante };
            await batePapo.AdicionarParticipante(participante, webSocketParticipante);

            //Adicionando usuário repetido
            var particitpantesObtidos = batePapo.ListarIdsDosParticipantes();
            var participanteFoiAdicionado = batePapo.AdicionarParticipante(participante, webSocketParticipante).Result;

            Assert.False(participanteFoiAdicionado);
            Assert.True(particitpantesObtidos.Count() == 1);
            participantesEsperados.ToExpectedObject().ShouldMatch(particitpantesObtidos);
        }

        [Fact]
        public async void DeveRemoverUsuarioExistenteNoBatePapo()
        {
            var participante = Guid.NewGuid();
            var webSocketParticipante = new ClientWebSocket();
            var batePapo = new SalaDeBatePapo();
            await batePapo.AdicionarParticipante(participante, webSocketParticipante);
            var totalInicialDeParticipantes = batePapo.ListarIdsDosParticipantes().Count();

            batePapo.RemoverParticipante(participante);
            var participantesObtidos = batePapo.ListarIdsDosParticipantes();
            var totalDeParticipantesObtido = participantesObtidos.Count();

            Assert.True(totalInicialDeParticipantes == 1);
            Assert.True(totalDeParticipantesObtido == 0);
            Assert.False(participantesObtidos.Exists(p => p == participante));
        }

        [Theory]
        [InlineData(true, "nick1")]
        [InlineData(false, "nick2")]
        public async void DeveVerificarApelidoExistente(bool apelidoEhEsperado, string apelidoEnviado)
        {
            const string apelidoParticipante = "nick1";
            var participante = Guid.NewGuid();
            var webSocketParticipante = new ClientWebSocket();
            var batePapo = new SalaDeBatePapo();
            await batePapo.AdicionarParticipante(participante, webSocketParticipante);
            batePapo.DefinirApelidoDoParticipante(apelidoParticipante, webSocketParticipante);

            var apelidoFoiObtido = batePapo.VerificarApelidoExistente(apelidoEnviado);

            Assert.Equal(apelidoEhEsperado, apelidoFoiObtido);
        }

        [Fact]
        public async void DeveListarUsuarioParaEnvioMensagem()
        {
            const string textoMensagem = "nick entrou na sala";
            const string destinatario = "todos";
            var batePapo = new SalaDeBatePapo();
            var idParticipante1 = Guid.NewGuid();
            const string apelidoDoParticipante = "nick";
            var webSocketParticipante1 = new ClientWebSocket();
            var mensagem = new Mensagem(apelidoDoParticipante, destinatario, textoMensagem, ETipoVisibilidadeDaMensagem.Aberta);
            var idParticipante2 = Guid.NewGuid();
            var webSocketParticipante2 = new ClientWebSocket();
            var idParticipante3 = Guid.NewGuid();
            var webSocketParticipante3 = new ClientWebSocket();
            await batePapo.AdicionarParticipante(idParticipante1, webSocketParticipante1);
            await batePapo.AdicionarParticipante(idParticipante2, webSocketParticipante2);
            await batePapo.AdicionarParticipante(idParticipante3, webSocketParticipante3);
            var socketsEsperados = new List<ClientWebSocket> { webSocketParticipante1, webSocketParticipante2, webSocketParticipante3 }.ToExpectedObject();
            
            var socketsObtidos = batePapo.ListarSocketsParaEnvioMensagem(idParticipante1, mensagem);

            socketsEsperados.ShouldMatch(socketsObtidos);
        }  
        

    }
}

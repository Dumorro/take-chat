using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using ExpectedObjects;
using Xunit;

namespace Take.BatePapo.TestesDeUnidade.Dominio
{
    public class BatePapoTestes
    {
        [Fact]
        public async void DeveAdicionarWebSocketDoUsuario()
        {
            var participante = Guid.NewGuid();
            var webSocketEsperado = new ClientWebSocket();
            var batePapo = new BatePapo.Dominio.Entidades.SalaDeBatePapo();            
            await batePapo.AdicionarParticipante(participante, webSocketEsperado);

            var webSocketObtido = batePapo.BuscarWebSocketDoParticipante(participante);

            Assert.Equal(webSocketEsperado,webSocketObtido);
        }

        [Fact]
        public async void NaoDeveAdicionarUsuarioJaExistenteAoBatePapo()
        {
            var participante = Guid.NewGuid();
            var webSocketParticipante = new ClientWebSocket();
            var batePapo = new BatePapo.Dominio.Entidades.SalaDeBatePapo();
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
            var batePapo = new BatePapo.Dominio.Entidades.SalaDeBatePapo();
            await batePapo.AdicionarParticipante(participante, webSocketParticipante);
            var totalInicialDeParticipantes = batePapo.ListarIdsDosParticipantes().Count();

            batePapo.RemoverParticipante(participante);
            var participantesObtidos = batePapo.ListarIdsDosParticipantes();
            var totalDeParticipantesObtido = participantesObtidos.Count();

            Assert.True(totalInicialDeParticipantes == 1);
            Assert.True(totalDeParticipantesObtido == 0);
            Assert.False(participantesObtidos.Exists(p=> p == participante));
        }
    }
}

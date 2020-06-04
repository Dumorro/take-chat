using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using ExpectedObjects;
using Xunit;

namespace Take.BatePapo.TestesDeUnidade.Dominio
{
    public class BatePapoTeste
    {
        //[Fact]
        //public async void DeveAdicionarUsuarioAoBatePapo()
        //{
        //    var participanteApelido = "José";
        //    var particitpantesDoBatePapoEsperados = new List<string>{participanteApelido};
        //    var batePapo = new BatePapo.Dominio.Entidades.SalaDeBatePapo();
        //    await batePapo.AdicionarParticipante(participanteApelido, new ClientWebSocket());

        //    var particitpantesDoBatePapo = batePapo.Participantes;

        //    particitpantesDoBatePapo.ToExpectedObject().ShouldMatch(particitpantesDoBatePapoEsperados);
        //}

        //[Fact]
        //public async void NaoDeveAdicionarUsuarioJaExistenteAoBatePapo()
        //{
        //    var participanteApelido = "José";
        //    var particitpantesDoBatePapoEsperados = new List<string> { participanteApelido };
        //    var batePapo = new BatePapo.Dominio.Entidades.SalaDeBatePapo();
        //    await batePapo.AdicionarParticipante(participanteApelido, new ClientWebSocket());
        //    //Adicionando usuário repetido
        //    var usuarioFoiAdiconado = batePapo.AdicionarParticipante(participanteApelido, new ClientWebSocket()).Result;

        //    var particitpantesDoBatePapo = batePapo.Participantes;

        //    Assert.False(usuarioFoiAdiconado);
        //    particitpantesDoBatePapo.ToExpectedObject().ShouldMatch(particitpantesDoBatePapoEsperados);
        //}
        
        //[Fact]
        //public async void DeveRemoverUsuarioExistenteNoBatePapo()
        //{
        //    //criar bate papo e adicionar participante à sala.
        //    var apelidoDoParticipante = "José";
        //    var batePapo = new BatePapo.Dominio.Entidades.SalaDeBatePapo();
        //    await batePapo.AdicionarParticipante(apelidoDoParticipante, new ClientWebSocket());
        //    var particitpantesDoBatePapo1Participante = batePapo.Participantes;
        //    var totalInicialDeParticipantes = particitpantesDoBatePapo1Participante.Count();
            
        //    Assert.True(totalInicialDeParticipantes == 1);

        //    var participanteRemovidoDoBatePapo = batePapo.RemoverParticipante(apelidoDoParticipante).Result;
        //    var totalDeParticipantesObtido = batePapo.Participantes.Count();

        //    Assert.True(participanteRemovidoDoBatePapo);
        //    Assert.True(totalDeParticipantesObtido==0);
        //    Assert.Empty(batePapo.Participantes);
        //}
    }
}

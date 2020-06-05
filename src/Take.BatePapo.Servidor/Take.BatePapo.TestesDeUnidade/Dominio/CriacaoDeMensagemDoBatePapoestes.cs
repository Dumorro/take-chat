using ExpectedObjects;
using System.Collections;
using System.Collections.Generic;
using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Entidades;
using Take.BatePapo.Dominio.Enumeracoes;
using Xunit;

namespace Take.BatePapo.TestesDeUnidade.Dominio
{
    public class CriacaoDeMensagemDeAvisoTestes
    {
        [Theory]
        [ClassData(typeof(CriacaoDeMensagemDeAvisoParametrosParaTestes))]
        public void DeveMontarUmaMensagemParaEnvioNoChat(string mensagemTexto, Mensagem mensagemEsperada)
        {
           var mensagemObtida = CriacaoDeMensagemDoBatePapo.Montar(mensagemTexto);

            mensagemEsperada.ToExpectedObject().ShouldEqual(mensagemObtida);
        }
    }
        
    public class CriacaoDeMensagemDeAvisoParametrosParaTestes : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
            "nick: /e /t entrou na sala",
            new Mensagem("nick", "todos", "entrou na sala", ETipoVisibilidadeDaMensagem.Comando)
            };
            
            yield return new object[]
            {
            "nick: /s /t saiu da sala",
            new Mensagem("nick", "todos", "saiu da sala", ETipoVisibilidadeDaMensagem.Comando)
            };

            yield return new object[]
            {
            "nick: /t olá",
            new Mensagem("nick", "todos", "olá", ETipoVisibilidadeDaMensagem.Aberta)
            };

            yield return new object[]
            {
            "nick: /t olá /d nick2",
            new Mensagem("nick", "nick2", "olá", ETipoVisibilidadeDaMensagem.Aberta)
            };

            yield return new object[]
            {
            "nick: /t olá /r nick2",
            new Mensagem("nick", "nick2", "olá", ETipoVisibilidadeDaMensagem.Privada)
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Enumeracoes;
using Xunit;

namespace Take.BatePapo.TestesDeUnidade.Dominio
{
    public class MensagemTestes
    {
        [Fact]
        public void DeveMontarUmaMensagemParaEnvioNoBatePapo()
        {
            const string mensagemEsperada = "João fala para Maria: Olá";
            const string nomeDaSala = "Sala1";
            const string apelido = "João";
            const string destinatario = "Maria";
            const string textoDaMensagem = "Olá";
            const ETipoDaMensagem tipoDaMensagem = ETipoDaMensagem.Comando;
            var mensagem = new Mensagem(nomeDaSala, apelido, destinatario, textoDaMensagem, tipoDaMensagem);

            var mensagemObtida = mensagem.Montar();

            Assert.Equal(mensagemEsperada, mensagemObtida);
        }
    }
}

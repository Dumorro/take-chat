using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Enumeracoes;
using Xunit;

namespace Take.BatePapo.TestesDeUnidade.Dominio
{
    public class MensagemTestes
    {
        [Fact]
        public void DeveMontarUmaMensagemParaEnvioAberto()
        {
            const string mensagemEsperada = "João fala para Maria: Olá";
            const string apelido = "João";
            const string destinatario = "Maria";
            const string textoDaMensagem = "Olá";
            const ETipoVisibilidadeDaMensagem tipoDaMensagem = ETipoVisibilidadeDaMensagem.Aberta;
            var mensagem = new Mensagem(apelido, destinatario, textoDaMensagem, tipoDaMensagem);

            var mensagemObtida = mensagem.Montar();

            Assert.Equal(mensagemEsperada, mensagemObtida);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void DeveMontarUmaMensagemComDestinatarioNuloOuVazio(string destinatario)
        {
            const string mensagemEsperada = "João fala para todos: Olá";
            const string apelido = "João";
            const string textoDaMensagem = "Olá";
            const ETipoVisibilidadeDaMensagem tipoDaMensagem = ETipoVisibilidadeDaMensagem.Aberta;
            var mensagem = new Mensagem(apelido, destinatario, textoDaMensagem, tipoDaMensagem);

            var mensagemObtida = mensagem.Montar();

            Assert.Equal(mensagemEsperada, mensagemObtida);
        }
    }
}

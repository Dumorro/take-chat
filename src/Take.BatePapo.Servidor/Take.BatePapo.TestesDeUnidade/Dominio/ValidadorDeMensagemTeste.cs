using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Entidades;
using Take.BatePapo.Dominio.Enumeracoes;
using Xunit;

namespace Take.BatePapo.TestesDeUnidade.Dominio
{
    public class ValidadorDeMensagemTeste
    {
        [Fact]
        public void DeveValidarUmaMensagemParaEnvioNoBatePapo()
        {
            const string nomeDaSala = "Sala1";
            const string apelido = "João";
            const string destinatario = "Maria";
            const string textoDaMensagem = "Olá";
            const ETipoDaMensagem tipoDaMensagem = ETipoDaMensagem.Comando;
            var mensagem = new Mensagem(nomeDaSala, apelido, destinatario, textoDaMensagem, tipoDaMensagem);
            
            var validador = new ValidadorDeMensagem();
            var resultadoDaValidacao = validador.Validate(mensagem);

            Assert.True(resultadoDaValidacao.IsValid);
        }
    }
}

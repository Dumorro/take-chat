using System.Linq;
using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Enumeracoes;

namespace Take.BatePapo.Dominio.Entidades
{
    public class CriacaoDeMensagemDoBatePapo
    {        
        public static Mensagem Montar(string mensagem)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
                return null;
            var apelidoDoParticipante = mensagem.Split(':')[0];
            var parametros = ObterParametros(apelidoDoParticipante, mensagem);
            if (parametros == null)
                return null;
            var destinatario = ObterDestinatario(parametros) ?? "todos";
            var tipoMensagem = ObterTipoMensagem(parametros);
            var textoDaMensagem = ObterTexto(parametros);

            return new Mensagem(apelidoDoParticipante, destinatario, textoDaMensagem, tipoMensagem);
        }

        private static ETipoVisibilidadeDaMensagem ObterTipoMensagem(string[] parametros)
        {
            var comandoEntradaNaSala = ((char)ETipoComando.EntrarNaSala).ToString();
            var comandoSaidaSala = ((char)ETipoComando.SairDaSala).ToString();
            var comandoMensagemReservada = ((char)ETipoComando.MensagemReservada).ToString();
            if (parametros.FirstOrDefault(p => p.StartsWith(comandoEntradaNaSala) || p.StartsWith(comandoSaidaSala)) != null)
                return ETipoVisibilidadeDaMensagem.Comando;
            return parametros.FirstOrDefault(p => p.StartsWith(comandoMensagemReservada)) 
                != null ? ETipoVisibilidadeDaMensagem.Privada : ETipoVisibilidadeDaMensagem.Aberta;
        }

        private static string ObterTexto(string[] parametros)
        {
            return parametros.FirstOrDefault(p => p.StartsWith("t")).Substring(2);
        }

        private static string[] ObterParametros(string apelidoDoParticipante, string response)
        {
            if (response.IndexOf('/') == -1)
                return null;
            return response.Remove(0, apelidoDoParticipante.Length + 2).Split('/');
        }

        private static string ObterDestinatario(string[] parametros)
        {
            return parametros.FirstOrDefault(p => p.StartsWith("d") || p.StartsWith("r"))?.Substring(2);
        }
    }
}

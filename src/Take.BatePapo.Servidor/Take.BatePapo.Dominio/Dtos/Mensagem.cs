using Take.BatePapo.Dominio.Enumeracoes;

namespace Take.BatePapo.Dominio.Dtos
{
    public class Mensagem
    {
        public string ApelidoDoParticipante { get; private set; }
        public string Destinatario { get; private set; }
        public string _textoDaMensagem { get; private set; }
        public ETipoVisibilidadeDaMensagem TipoVisibilidadeDaMensagem { get; private set; }

        public Mensagem(string apelidoDoParticipante, string destinatario, string textoDaMensagem, ETipoVisibilidadeDaMensagem tipoDaMensagem)
        {
            ApelidoDoParticipante = apelidoDoParticipante;
            Destinatario = string.IsNullOrWhiteSpace(destinatario) ? "todos" : destinatario;
            _textoDaMensagem = textoDaMensagem?.Trim();
            TipoVisibilidadeDaMensagem = tipoDaMensagem;
        }

        public string Montar()
        {
            if (TipoVisibilidadeDaMensagem == ETipoVisibilidadeDaMensagem.Comando)
            {
                return $"{ApelidoDoParticipante.Trim()} {_textoDaMensagem.Trim()}";
            }
            var ehMensagemReservada = TipoVisibilidadeDaMensagem == ETipoVisibilidadeDaMensagem.Privada ? "reservadamente " : "";
            return $"{ApelidoDoParticipante.Trim()} fala para {ehMensagemReservada}{Destinatario.Trim()}: {_textoDaMensagem.Trim()}";
        }
    }
}

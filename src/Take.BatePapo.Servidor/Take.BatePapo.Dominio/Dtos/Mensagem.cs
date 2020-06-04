using Take.BatePapo.Dominio.Enumeracoes;

namespace Take.BatePapo.Dominio.Dtos
{
    public class Mensagem
    {
        public string _salaDoBatePapo { get; private set; }
        public string ApelidoDoParticipante { get; private set; }
        public string Destinatario { get; private set; }
        public string _textoDaMensagem { get; private set; }
        public ETipoDaMensagem TipoDaMensagem { get; private set; }

        public Mensagem(string salaDoBatePapo, string apelidoDoParticipante, string destinatario, string textoDaMensagem, ETipoDaMensagem tipoDaMensagem)
        {
            _salaDoBatePapo = salaDoBatePapo;
            ApelidoDoParticipante = apelidoDoParticipante;
            Destinatario = string.IsNullOrWhiteSpace(destinatario) ? "todos" : destinatario;
            _textoDaMensagem = textoDaMensagem;
            TipoDaMensagem = tipoDaMensagem;
        }

        public string Montar()
        {
            if (TipoDaMensagem == ETipoDaMensagem.Comando)
            {
                return $"{ApelidoDoParticipante.Trim()} {_textoDaMensagem.Trim()}";
            }
            var ehMensagemReservada = TipoDaMensagem == ETipoDaMensagem.Privada ? "reservadamente " : "";
            return $"{ApelidoDoParticipante.Trim()} fala para {ehMensagemReservada}{Destinatario.Trim()}: {_textoDaMensagem.Trim()}";
        }
    }
}

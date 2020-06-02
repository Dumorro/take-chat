using Take.BatePapo.Dominio.Dtos;

namespace Take.BatePapo.Dominio.Entidades
{
    public class CriacaoDeMensagemDeParticipante
    {
        private const string _modeloMensgem = "[{0}] fala para [{1}]: {2}";
        public static string Montar(Mensagem mensagem)
        {
            return string.Format(_modeloMensgem, mensagem.ApelidoDoParticipante, mensagem.Destinatario, mensagem.Texto);
        }
    }
}

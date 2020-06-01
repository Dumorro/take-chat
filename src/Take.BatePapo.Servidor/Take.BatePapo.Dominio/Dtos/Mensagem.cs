using Take.BatePapo.Dominio.Enumeracoes;

namespace Take.BatePapo.Dominio.Dtos
{
    public class Mensagem
    {
        public string SalaDoBatePapo { get; private set; }
        public string ApelidoDoParticipante { get; private set; }
        public string Destinatario { get; private set; }
        public string Texto { get; private set; }
        public ETipoDaMensagem Tipo { get; private set; }
        
        public Mensagem(string salaDoBatePapo, string apelidoDoParticipante, string destinatario, string textoDaMensagem, ETipoDaMensagem tipoDaMensagem) 
        {
            SalaDoBatePapo = salaDoBatePapo;
            ApelidoDoParticipante = apelidoDoParticipante;
            Destinatario = destinatario;
            Texto = textoDaMensagem;
            Tipo = tipoDaMensagem;   
        }
    }
}

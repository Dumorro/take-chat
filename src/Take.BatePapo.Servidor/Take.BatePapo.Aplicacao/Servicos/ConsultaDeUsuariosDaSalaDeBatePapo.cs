using Take.BatePapo.Dominio.Interfaces;

namespace Take.BatePapo.Aplicacao.Servicos
{
    public class ConsultaDeUsuariosDaSalaDeBatePapo : IConsultaDeUsuariosDaSalaDeBatePapo
    {
        private readonly IBatePapo _batePapo;
        public ConsultaDeUsuariosDaSalaDeBatePapo(IBatePapo batePapo)
        {
            _batePapo = batePapo;
        }

        public bool VerificarUsuarioExistente(string apelido)
        {
            return _batePapo.VerificarApelidoExistente(apelido);
        }
    }
}

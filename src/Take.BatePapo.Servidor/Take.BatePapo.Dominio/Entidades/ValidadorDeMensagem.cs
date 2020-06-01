using FluentValidation;
using Take.BatePapo.Dominio.Dtos;
using Take.BatePapo.Dominio.Enumeracoes;

namespace Take.BatePapo.Dominio.Entidades
{
    public class ValidadorDeMensagem : AbstractValidator<Mensagem>
    {
        public ValidadorDeMensagem()
        {
            RuleFor(m => m.Texto).NotEmpty().WithMessage("Uma mensagem deve ser informada");
            RuleFor(m => m.ApelidoDoParticipante).NotEmpty().WithMessage("O participante deve ser informado.");
            RuleFor(m => m.Destinatario).NotEmpty().WithMessage("O destinatário deve ser informado.");
            RuleFor(m => m.Tipo).Equal(ETipoDaMensagem.Comando).WithMessage("Não é possível enviar um comando como mensagem");
        }
    }
}

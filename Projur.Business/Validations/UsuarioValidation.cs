using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Projur.Entity.Models; 

namespace Projur.Business.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation() {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Por favor, digite o seu nome.");
            RuleFor(x => x.Sobrenome).NotEmpty().WithMessage("Por favor, digite o seu sobrenome.");
            RuleFor(x => x.EscolaridadeId).MustAsync(ValidaEscolaridadeExiste).WithMessage("Por favor, selecione uma opção de escolaridade válida.");
            RuleFor(x => x.Email).Must(ValidaEmail).WithMessage("Por favor, insira um email válido.");
            RuleFor(x => x.DtNascimento).Must(ValidaDataNasc).WithMessage("Data de nascimento não pode ser maior do que a data de hoje.");
        }

        private async Task<bool> ValidaEscolaridadeExiste(int escolaridadeId, CancellationToken cancellation)
        {
            var escolaridade = await new Services.EscolaridadeService().GetEscolaridade(escolaridadeId);

            return escolaridade is Escolaridade;
        }
        private bool ValidaDataNasc(DateTime dtNascimento)
            => DateTime.Now >= dtNascimento;
        private bool ValidaEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            return match.Success;
        }
    }
}
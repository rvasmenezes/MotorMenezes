using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace MotorMenezes.Core.Helpers
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        private readonly IStringLocalizer<CustomIdentityErrorDescriber> _localizer;

        public CustomIdentityErrorDescriber(IStringLocalizer<CustomIdentityErrorDescriber> localizer)
        {
            _localizer = localizer;
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = _localizer["Já existe um usuário com o Name '{0}'.", userName]
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = _localizer["Senha deve conter no mínimo '{0}' caracteres.", length]
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = _localizer["Senha deve ter pelo menos 1 caracter especial ('@', '#', '$', '%')!"]
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = _localizer["Senha deve ter pelo menos 1 letra maiúscula ('A'-'Z')!"]
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = _localizer["Senha deve ter pelo menos 1 letra minúscula ('a'-'z')!"]
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = _localizer["Senha deve ter pelo menos 1 número ('0'-'9')!"]
            };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Code = nameof(InvalidToken),
                Description = _localizer["Token inválido!"]
            };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = nameof(PasswordMismatch),
                Description = _localizer["Senha incorreta!"]
            };
        }
    }
}

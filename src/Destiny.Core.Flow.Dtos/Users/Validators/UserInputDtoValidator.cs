using Destiny.Core.Flow.FluentValidation;
using FluentValidation;

namespace Destiny.Core.Flow.Dtos.Users.Validators
{
    public class UserInputDtoValidator : FluentModelValidator<UserInputDto>
    {
        public UserInputDtoValidator()
        {
            RuleFor(b => b.Description).NotEmpty()
                .WithMessage("描述不能为空");
        }
    }
}
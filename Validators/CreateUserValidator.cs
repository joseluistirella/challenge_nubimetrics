using FluentValidation;

using Service.Queries;

namespace Service.Validators
{
    public class CreateUserValidator : AbstractValidator<IUser>
    {
        public CreateUserValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id es requerido");    
            
            RuleFor(c => c.Apellido)
                .NotEmpty()
                .WithMessage("Apellido es requerido");    
            
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Email es requerido");    
            
            RuleFor(c => c.Nombre)
                .NotEmpty()
                .WithMessage("Nombre es requerido");    
            
            RuleFor(c => c.Password)
                .NotEmpty()
                .WithMessage("Password es requerido");    
        
        }


        

    }
}

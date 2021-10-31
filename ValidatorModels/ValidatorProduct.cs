using APICatalogo.Models.Product;
using FluentValidation;

namespace APICatalogo.ValidatorModels
{
    public class ValidatorProduct : AbstractValidator<Product>
    {
        public ValidatorProduct()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .WithMessage("Titulo não pode ser vazio.")
                .NotNull()
                .WithMessage("Titulo não pode ser null e vazio.");

            RuleFor(a => a.Price)
                .NotEmpty()
                .WithMessage("Price não pode ser vazio.")
                .NotNull()
                .WithMessage("Price não pode ser null e vazio.");

            //RuleFor(a => a.IdProduct)
            //   .NotEmpty()
            //   .WithMessage("IdProduct não pode ser vazio.")
            //   .NotNull()
            //   .WithMessage("IdProduct não pode ser null.");
        }
    }
}

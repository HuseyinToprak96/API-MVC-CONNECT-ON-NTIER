using CORE_LAYER.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE_LAYER.FluentValidations
{
    public class EmployeeValidation:AbstractValidator<EmployeeDto>
    {
        public string notFoundMessage { get; set; } = "{PropertyName} is required";
        public EmployeeValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(notFoundMessage);
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage(notFoundMessage);
            RuleFor(x => x.Salary).NotEmpty().WithMessage(notFoundMessage).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.DepartmentId).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.BirthDay).NotNull().NotEmpty();
        }
    }
}

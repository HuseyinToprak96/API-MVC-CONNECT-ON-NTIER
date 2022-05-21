using CORE_LAYER.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE_LAYER.FluentValidations
{
   public class DepartmentValidation:AbstractValidator<DepartmentDto>
    {
        public DepartmentValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}

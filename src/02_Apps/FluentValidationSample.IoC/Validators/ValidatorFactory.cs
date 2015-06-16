using System;
using Autofac;
using FluentValidation;

namespace FluentValidationSample.WebApp.Validators
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private readonly IContainer container;

        public ValidatorFactory(IContainer container)
        {
            this.container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            var validator = container.ResolveOptionalKeyed<IValidator>(validatorType);
            return validator;
        }
    }
}
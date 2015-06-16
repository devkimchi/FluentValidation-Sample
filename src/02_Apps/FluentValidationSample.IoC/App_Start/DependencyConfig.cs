using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using FluentValidation.Mvc;
using FluentValidationSample.WebApp.Models;
using FluentValidationSample.WebApp.Validators;

namespace FluentValidationSample.WebApp
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacWebTypesModule());
            RegisterValidators(builder);
            RegisterControllers(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            RegisterValidationProviders(container);
        }

        private static void RegisterValidators(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterViewModelValidator>()
                   .Keyed<IValidator>(typeof(IValidator<RegisterViewModel>))
                   .As<IValidator>();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
        }

        private static void RegisterValidationProviders(IContainer container)
        {
            ModelValidatorProviders.Providers.Clear();
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            var fvmvp = new FluentValidationModelValidatorProvider(new ValidatorFactory(container))
                        {
                            AddImplicitRequiredValidator = false,
                        };
            ModelValidatorProviders.Providers.Add(fvmvp);
        }
    }
}
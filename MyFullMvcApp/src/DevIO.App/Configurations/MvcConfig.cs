using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.App.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddMvc(options => {
                options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "The filled value is invalid for this field.");
                options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "This field needs to be completed.");
                options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "This field needs to be completed.");
                options.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "The body in the request must not be empty.");
                options.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(x => "The filled value is invalid for this field.");
                options.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "The filled value is invalid for this field.");
                options.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "The field must be numeric.");
                options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(x => "The filled value is invalid for this field.");
                options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => "The filled value is invalid for this field.");
                options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "The field must be numeric.");
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "This field needs to be completed.");
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return services;
        }
    }
}

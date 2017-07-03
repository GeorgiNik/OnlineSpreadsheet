namespace OnlineSpreadsheet.Web.Application.ModelBinders
{
    using System.Web.Mvc;

    public class TrimModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // First check if request validation is required
            var shouldPerformRequestValidation = controllerContext.Controller.ValidateRequest &&
                                                 bindingContext.ModelMetadata.RequestValidationEnabled;

            // Get value
            ValueProviderResult valueResult = bindingContext.GetValueFromValueProvider(shouldPerformRequestValidation);

            if (valueResult == null || valueResult.AttemptedValue == null)
            {
                return null;
            }
            else if (valueResult.AttemptedValue == string.Empty)
            {
                return string.Empty;
            }

            return valueResult.AttemptedValue.Trim();
        }
    }

    public static class ModelBinderHelpers
    {
        public static ValueProviderResult GetValueFromValueProvider(this ModelBindingContext bindingContext,
                                                                    bool performRequestValidation)
        {
            var unvalidatedValueProvider = bindingContext.ValueProvider as IUnvalidatedValueProvider;

            return (unvalidatedValueProvider != null)
              ? unvalidatedValueProvider.GetValue(bindingContext.ModelName, !performRequestValidation)
              : bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        }
    }
}
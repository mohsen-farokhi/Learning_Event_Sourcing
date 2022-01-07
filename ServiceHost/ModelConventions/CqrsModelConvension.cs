using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ServiceHost.ModelConventions;
public class CqrsModelConvention : IApplicationModelConvention
{
    private const string Query = "QueryController";

    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers
                    .Where(c => c.ControllerType.Name.EndsWith(Query,
                        StringComparison.OrdinalIgnoreCase)))
        {
            foreach (var selectorModel in controller.Selectors
                        .Where(c => c.AttributeRouteModel != null).ToList())
            {
                selectorModel.AttributeRouteModel =
                    new AttributeRouteModel
                    {
                        Template =
                            controller.ControllerType.Name.Replace(Query, "",
                            StringComparison.OrdinalIgnoreCase),
                    };
            }
        }
    }
}

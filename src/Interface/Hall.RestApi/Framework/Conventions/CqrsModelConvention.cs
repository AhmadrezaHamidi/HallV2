using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Framework.RestApi.Conventions;

public class CqrsModelConvention : IApplicationModelConvention
{
    private const string Command = "CommandController";
    private const string Query = "QueryController";

    public void Apply(ApplicationModel application)
    {
        var commandControllers = application.Controllers.Where(a =>
            a.ControllerType.Name.EndsWith(Command, StringComparison.OrdinalIgnoreCase));

        foreach (var controller in commandControllers)
        {
            foreach (var selectorModel in controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList())
            {
                if (selectorModel.AttributeRouteModel != null)
                {
                        selectorModel.AttributeRouteModel.Template =
                            selectorModel.AttributeRouteModel.Template?.Replace("[controller]",
                                controller.ControllerType.Name.Replace(Command, "", StringComparison.OrdinalIgnoreCase));
                }
            }
        }
        
        var queryControllers = application.Controllers.Where(a =>
            a.ControllerType.Name.EndsWith(Query, StringComparison.OrdinalIgnoreCase));

        foreach (var controller in queryControllers)
        {
            foreach (var selectorModel in controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList())
            {
                if (selectorModel.AttributeRouteModel != null)
                {
                    selectorModel.AttributeRouteModel.Template =
                        selectorModel.AttributeRouteModel.Template?.Replace("[controller]",
                            controller.ControllerType.Name.Replace(Query, "", StringComparison.OrdinalIgnoreCase));
                }
            }
        }
    }
}
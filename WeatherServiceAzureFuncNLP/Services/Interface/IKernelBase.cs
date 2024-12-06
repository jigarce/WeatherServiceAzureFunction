using Microsoft.SemanticKernel;

namespace WeatherServiceAzureFunction.Services.Interface
{
    public interface IKernelBase
    {
        Kernel CreateKernel();
    }
}

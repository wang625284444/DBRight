

using Microsoft.Extensions.Options;

namespace DB.Utils.Appsetting
{
    /// <summary>
    /// 读取配置文件appsetting文件
    /// </summary>
    public class ApplicationConfigServices
    {
        private readonly IOptions<ApplicationConfig> _appConfiguration;
        public ApplicationConfigServices(IOptions<ApplicationConfig> appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }
        public ApplicationConfig AppConfigurations
        {
            get
            {
                return _appConfiguration.Value;
            }
        }
    }
}
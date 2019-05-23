
namespace DB.Utils.Appsetting
{
    /// <summary>
    /// 加载配置文件的信息
    /// </summary>
    /// 修改记录：
    public class ApplicationConfig
    {
        /// <summary>
        /// 网站管理平台标题
        /// </summary>
        public string AdminTitle { get; set; }

        /// <summary>
        /// 网站版权
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// CSS/JS版本
        /// </summary>
        public string ContentAndScriptVersion { get; set; }
    }
}
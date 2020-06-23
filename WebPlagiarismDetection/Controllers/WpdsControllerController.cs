using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebPlagiarismDetection.ViewModels;

namespace WebPlagiarismDetection.Controllers
{
    /// <summary>
    /// 检测
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class WpdsController : ControllerBase
    {
        private readonly ILogger<WpdsController> _logger;

        /// <summary>
        /// 
        /// </summary>
        public WpdsController(ILogger<WpdsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Wpd> Get()
        {
            return new List<Wpd> {
                new Wpd { WpdId = Guid.NewGuid(), Title = "标题测试1", CreateTime = DateTime.Now, DetectBeginTime = DateTime.Now, DetectEndTime = DateTime.Now },
                new Wpd { WpdId = Guid.NewGuid(), Title = "标题测试2", CreateTime = DateTime.Now, DetectBeginTime = DateTime.Now, DetectEndTime = DateTime.Now },
                new Wpd { WpdId = Guid.NewGuid(), Title = "标题测试3", CreateTime = DateTime.Now, DetectBeginTime = DateTime.Now, DetectEndTime = DateTime.Now },
                new Wpd { WpdId = Guid.NewGuid(), Title = "标题测试4", CreateTime = DateTime.Now, DetectBeginTime = DateTime.Now, DetectEndTime = DateTime.Now },
                new Wpd { WpdId = Guid.NewGuid(), Title = "标题测试5", CreateTime = DateTime.Now, DetectBeginTime = DateTime.Now, DetectEndTime = DateTime.Now }
            };
        }
    }
}

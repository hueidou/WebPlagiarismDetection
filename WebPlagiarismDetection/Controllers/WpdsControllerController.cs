using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebPlagiarismDetection.Models;
using WebPlagiarismDetection.ViewModels;

namespace WebPlagiarismDetection.Controllers
{
    /// <summary>
    /// 检测
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WpdsController : ControllerBase
    {
        private readonly ILogger<WpdsController> _logger;
        private readonly WpdContext _wpdContext;

        /// <summary>
        /// 
        /// </summary>
        public WpdsController(ILogger<WpdsController> logger, WpdContext wpdContext)
        {
            _logger = logger;
            _wpdContext = wpdContext;
        }

        /// <summary>
        /// 获取检测列表
        /// </summary>
        /// <response code="200">获取检测列表成功</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Wpd>), 200)]
        public IActionResult Get()
        {
            var list = _wpdContext.Wpds.ToList();
            return Ok(list);
        }

        /// <summary>
        /// 新增检测
        /// </summary>
        /// <param name="wpdPost"></param>
        /// <response code="200">新增检测成功</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        public IActionResult Post(WpdPostBindingModel wpdPost)
        {
            Guid wpdId = Guid.NewGuid();

            _wpdContext.Wpds.Add(new Wpd
            {
                WpdId = wpdId,
                Title = wpdPost.Title,
                CreateTime = DateTime.Now
            });

            _wpdContext.SaveChanges();

            return Ok(wpdId);
        }

        /// <summary>
        /// 获取检测
        /// /// </summary>
        /// <param name="wpdId"></param>
        /// <response code="200">获取检测成功</response>
        /// <response code="404">此检测不存在</response>
        [HttpGet("{wpdId}")]
        [ProducesResponseType(typeof(Wpd), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetWpd(Guid wpdId)
        {
            var wpd = _wpdContext.Wpds.FirstOrDefault(wpd => wpd.WpdId == wpdId);
            if (wpd == null)
            {
                return NotFound();
            }

            return Ok(wpd);
        }
    }
}

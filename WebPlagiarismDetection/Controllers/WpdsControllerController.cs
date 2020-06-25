using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
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
        private string[] permittedExtensions = { "doc", "docx", ".txt", ".pdf" };

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
        [ProducesResponseType(typeof(IEnumerable<WpdViewModel>), 200)]
        public IActionResult Get()
        {
            var list = _wpdContext.Wpds.Select(wpd => new WpdViewModel
            {
                WpdId = wpd.WpdId,
                Title = wpd.Title,
                CreateTime = wpd.CreateTime,
                DetectBeginTime = wpd.DetectBeginTime,
                DetectEndTime = wpd.DetectEndTime
            }).ToList();
            return Ok(list);
        }

        /// <summary>
        /// 新增检测
        /// </summary>
        /// <param name="wpdPost"></param>
        /// <response code="200">新增检测成功</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        public IActionResult Post([FromForm] WpdPostBindingModel wpdPost)
        {
            // 检查文件后缀
            var ext = Path.GetExtension(wpdPost.File.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                return BadRequest();
            }

            // 文件流转二进制
            byte[] file;
            using (MemoryStream ms = new MemoryStream())
            {
                wpdPost.File.CopyTo(ms);
                file = ms.ToArray();
            }

            Guid wpdId = Guid.NewGuid();

            _wpdContext.Wpds.Add(new Wpd
            {
                WpdId = wpdId,
                Title = wpdPost.File.FileName,
                File = file,
                CreateTime = DateTime.Now
            });

            _wpdContext.SaveChanges();

            return Ok(wpdId);
        }

        /// <summary>
        /// 获取检测
        /// </summary>
        /// <param name="wpdId"></param>
        /// <response code="200">获取检测成功</response>
        /// <response code="404">此检测不存在</response>
        [HttpGet("{wpdId}")]
        [ProducesResponseType(typeof(WpdViewModel), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetWpd(Guid wpdId)
        {
            var wpd = _wpdContext.Wpds.FirstOrDefault(wpd => wpd.WpdId == wpdId);
            if (wpd == null)
            {
                return NotFound();
            }

            var wpdViewModel = new WpdViewModel
            {
                WpdId = wpd.WpdId,
                Title = wpd.Title,
                CreateTime = wpd.CreateTime,
                DetectBeginTime = wpd.DetectBeginTime,
                DetectEndTime = wpd.DetectEndTime
            };

            return Ok(wpdViewModel);
        }

        /// <summary>
        /// 获取检测file
        /// </summary>
        /// <param name="wpdId"></param>
        /// <response code="200">获取检测file成功</response>
        /// <response code="404">此检测不存在</response>
        [HttpGet("{wpdId}/file")]
        [ProducesResponseType(typeof(byte[]), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetWpdFile(Guid wpdId)
        {
            var wpd = _wpdContext.Wpds.FirstOrDefault(wpd => wpd.WpdId == wpdId);
            if (wpd == null)
            {
                return NotFound();
            }

            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(wpd.Title, out contentType);

            return File(wpd.File, contentType);
        }

        /// <summary>
        /// 获取检测text
        /// </summary>
        /// <param name="wpdId"></param>
        /// <response code="200">获取检测text成功</response>
        /// <response code="404">此检测不存在</response>
        [HttpGet("{wpdId}/text")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetWpdText(Guid wpdId)
        {
            var wpd = _wpdContext.Wpds.FirstOrDefault(wpd => wpd.WpdId == wpdId);
            if (wpd == null)
            {
                return NotFound();
            }

            return Content(wpd.Text);
        }

        /// <summary>
        /// 获取检测result
        /// </summary>
        /// <param name="wpdId"></param>
        /// <response code="200">获取检测result成功</response>
        /// <response code="404">此检测不存在</response>
        [HttpGet("{wpdId}/result")]
        [ProducesResponseType(typeof(Object), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetWpdResult(Guid wpdId)
        {
            var wpd = _wpdContext.Wpds.FirstOrDefault(wpd => wpd.WpdId == wpdId);
            if (wpd == null)
            {
                return NotFound();
            }

            return Content(wpd.Result, "application/json");
        }
    }
}

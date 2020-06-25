using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebPlagiarismDetection.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class WpdPostBindingModel
    {
        /// <summary>
        /// 文件
        /// </summary>
        [Required]
        public IFormFile File { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WebPlagiarismDetection.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class WpdPostBindingModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        public string Title { get; set; }
    }
}
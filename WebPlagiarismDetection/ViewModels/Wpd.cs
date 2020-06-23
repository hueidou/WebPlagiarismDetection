using System;

namespace WebPlagiarismDetection.ViewModels
{
    /// <summary>
    /// 检测
    /// </summary>
    public class Wpd
    {
        /// <summary>
        /// 检测Id
        /// </summary>
        public Guid WpdId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 检测开始时间
        /// </summary>
        public DateTime DetectBeginTime { get; set; }

        /// <summary>
        /// 检测结束时间
        /// </summary>
        public DateTime DetectEndTime { get; set; }
    }
}

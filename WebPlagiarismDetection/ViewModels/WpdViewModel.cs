using System;

namespace WebPlagiarismDetection.ViewModels
{
    /// <summary>
    /// WpdViewModel
    /// </summary>
    public class WpdViewModel
    {
        /// <summary>
        /// 检测Id
        /// </summary>
        public Guid WpdId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        // /// <summary>
        // /// 文件
        // /// </summary>
        // public byte[] File { get; set; }

        // /// <summary>
        // /// 检测文本
        // /// </summary>
        // public string Text { get; set; }

        // /// <summary>
        // /// 检测结果
        // /// </summary>
        // public string Result { get; set; }

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

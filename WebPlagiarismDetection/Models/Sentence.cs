using System;

namespace WebPlagiarismDetection.Models
{
    /// <summary>
    /// 分句
    /// </summary>
    public class Sentence
    {
        /// <summary>
        /// 分句Id
        /// </summary>
        public Guid SentenceId { get; set; }

        /// <summary>
        /// 外键，检测Id
        /// </summary>
        public Guid WpdId { get; set; }

        /// <summary>
        /// 分句文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 序号
        /// 分句在检测文本中的位置
        /// </summary>
        public int No { get; set; }
    }
}
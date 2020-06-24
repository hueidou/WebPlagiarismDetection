using System;

namespace WebPlagiarismDetection.Models
{
    /// <summary>
    /// 句子搜索
    /// </summary>
    public class SentenceSearch
    {
        /// <summary>
        /// 句子搜索Id
        /// </summary>
        public Guid SentenceSearchId { get; set; }

        /// <summary>
        /// 外键，句子Id
        /// </summary>
        public Guid SentenceId { get; set; }

        /// <summary>
        /// 搜索引擎
        /// </summary>
        public string SearchEngine { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 文本
        /// 搜索Url解析出的文本
        /// 被比对文本
        /// </summary>
        public string Text { get; set; }
    }
}
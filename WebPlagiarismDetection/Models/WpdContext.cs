using Microsoft.EntityFrameworkCore;

namespace WebPlagiarismDetection.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class WpdContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public WpdContext(DbContextOptions<WpdContext> options)
          : base(options)
        { }

        /// <summary>
        /// 检测
        /// </summary>
        /// <value></value>
        public DbSet<Wpd> Wpds { get; set; }

        /// <summary>
        /// 分句
        /// </summary>
        /// <value></value>
        public DbSet<Sentence> Sentences { get; set; }

        /// <summary>
        /// 句子搜索
        /// </summary>
        /// <value></value>
        public DbSet<SentenceSearch> SentenceSearchs { get; set; }
    }
}
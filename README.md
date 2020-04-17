# WebPlagiarismDetection

网络抄袭检测

## 流程

1. 文本分句（标点、搜索引擎文本最大字符数），分为m句
2. 将每个句子通过各搜索引擎（baidu/google/bing）进行搜索，取前n条
3. 将所有链接（m×n×搜索引擎数量），通过Readability等获取其正文，作为比对资源
4. 通过文本相似性算法，计算相似性，给出总相似比、相思文章列表、相似片段等

## 设计

1. 主服务
    * 输入：被比对文本
    * 过程：被比对文本--文本相似性服务（分句功能）-->句子集合--搜索引擎服务-->比对文章链接集合--正文提取服务-->比对文本集合--文本相似性服务-->比对结果---->比对报告
    * 输出：比对报告
2. 文本相似性服务（含分句功能）
    * 输入：被比对文本、比对文本集合
    * 输出：比对结果
3. 网页正文提取服务（通过url获取正文）
    * 输入：比对文章链接（集合）
    * 输出：比对文本（集合）
4. 搜索引擎服务
    * 输入：句子（集合）
    * 输出：比对文章链接（集合）
5. （可选）文档文本提取服务
    * tika

## 参考

* [mozilla/readability](https://github.com/mozilla/readability/)
* [Kenshin/simpread](https://github.com/Kenshin/simpread/)

# WebPlagiarismDetection

网络抄袭检测

## 流程

1. 文本分句（标点、搜索引擎文本最大字符数），分为m句
2. 将每个句子通过各搜索引擎（baidu/google/bing）进行搜索，取前n条
3. 将所有链接（m×n×搜索引擎数量），通过Readability等获取其正文，作为比对资源
4. 通过文本相似性算法，计算相似性，给出总相似比、相思文章列表、相似片段等

## 参考

* [mozilla/readability](https://github.com/mozilla/readability/)
* [Kenshin/simpread](https://github.com/Kenshin/simpread/)

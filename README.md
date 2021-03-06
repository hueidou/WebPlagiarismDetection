# WebPlagiarismDetection

网络抄袭检测

## 流程

1. 文本分句（标点、搜索引擎文本最大字符数），分为m句
2. 将每个句子通过各搜索引擎（baidu/google/bing）进行搜索，取前n条
3. 将所有链接（m×n×搜索引擎数量），通过Readability等获取其正文，作为比对资源
4. 通过文本相似性算法，计算相似性，给出总相似比、相似文章列表、相似片段等

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

## 其他

### 搜索引擎服务

根据关键字符串获取结果列表，需要支持：
* 返回指定的结果个数、结果总数
* 根据一定状态，支持在第一次返回结果后，返回更多的结果
* 真实的url地址（类似baidu等结果链接非真实url地址）

根据【关键词 vs】可以通过搜索引擎获取相近的词（n个相近词），放到句子内，来获取更多相关搜索结果：
* 分句 -> 分词
* 比如一个句子包含十个词，那通过组合，当n等于1时，每个词有两种选择，一共有2的10次方，1024种
* 太多的话，可以限制保留原词个数，比如【至少】保留7个原词，则一共有C(10,7)，120种

* [MagicBaidu](https://github.com/1049451037/MagicBaidu)
* [MagicGoogle](https://github.com/howie6879/magic_google)
* [toapi-search](https://github.com/toapi/toapi-search)
* [toapi](https://github.com/gaojiuli/toapi)


### Tika

参考：https://cwiki.apache.org/confluence/display/TIKA/TikaServer


# 开发环境

```sh
# ef
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update

# node
curl -sL https://deb.nodesource.com/setup_15.x | sudo -E bash -
sudo apt-get install -y nodejs
```

# 测试

您可以使用以下命令开始测试：

```
python -m unittest discover neo
```

请注意，一些单元测试使用庞大的区块链夹具数据库（约800mb）。 该文件不保存在存储库中。

第一次运行测试时，测试安装将尝试下载文件并将其解压到正确的目录。您将等待较长时间才能下载这些数据库夹具，之后速度会很快。

要使用`coverage`测试，使用以下命令：

```
coverage run -m unittest discover neo

```

之后，您可以使用以下命令生成命令行覆盖报告：

```
coverage report -m --omit=venv/*
```
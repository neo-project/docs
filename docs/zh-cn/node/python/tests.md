# 测试

您可以使用此命令开始测试：

```
make test
```

使用此命令运行样式检查：

```
make lint
```

使用此命令运行 neo-python 测试

```
python -m unittest discover neo
```

使用此命令运行 neo-boa 项目的测试：

```
python -m unittest discover boa_test

```

如果要添加测试或更改功能，可以只运行一个测试:

```
python -m unittest neo/test_settings.py
```

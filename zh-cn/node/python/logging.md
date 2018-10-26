# 设置和日志

neo-python提供一个设置模块，可以用来配置以下事情：

- 网络：主网、测试网、私网或自定义配置
- 日志：

  - 智能合约事件日志
  - 日志文件（可选择旋转）
  - Loglevel

要更改设置，导入设置示例：

```
from neo.Settings import settings
```

## 设置网络

您可以使用以下设置方法配置网络：

```
settings.setup_mainnet()
settings.setup_testnet()
settings.setup_privnet()
settings.setup(config_file)
```

`neo-python` 默认使用测试网。

### 数据保存路径

默认情况下， `neo-python` 将链数据保存在 `~/.neopython/Chains`。如果想指定 `Chains` 目录放置的路径，可以将 `--datadir` 标志传递给以下任意命令：`np-prompt`, `np-api-server`, 或 `np-bootstrap`。也可以使用 `settings` 模块手动设置：

```
settings.set_data_dir('your/path')
```

### 日志

neo-python 使用以下默认方式：

- 来自所有智能合约的事件都使用loglevel INFO进行记录
- loglevel 设置为 INFO
- 记录到 logfile 被取消激活 (prompt.py 记录到 prompt.log)

### 智能合约事件

要禁用所有智能合约事件的记录，参照以下示例：

```
settings.set_log_smart_contract_events(False)
```

### 更改日志级别

要更改日志级别，如也显示DEBUG日志或只显示错误日志，参照以下示例：

```
import logging

# Show everything, including debug logs:
settings.set_loglevel(logging.DEBUG)

# Only show errors:
settings.set_loglevel(logging.ERROR)
```

### 在 prompt 中更改

要在 `prompt` 中更改 log 级别，使用以下命令： 

```
neo> config sc-events on
neo> config sc-events off
```

### 配置日志文件

要启动日志文件的记录功能，参照以下示例：

```
# Just a single logfile, with no limits or rotation:
settings.set_logfile(your_logfile_path)

# To enable rotation with a maximum of 10MB per file and 3 rotations:
settings.set_logfile(your_logfile_path, 1e7, 3)

```

### 记录自定义代码

neo-python 使用 [logzero](https://logzero.readthedocs.io/) 进行记录。要在现有的neo日志记录配置中使用alogger，只需从logzero导入日志记录器，如下所示：

```
from logzero import logger

# These log messages are sent to the console
logger.debug("hello")
logger.info("info")
logger.warn("warn")
logger.error("error")

# This is how you'd log an exception
try:
    raise Exception("this is a demo exception")
except Exception as e:
    logger.exception(e)
```


# 設定とロギング

neo-pythonは設定モジュールがあり、以下のものを設定するのに利用できます。

- ネットワーク：メインネット、テストネット、プライベートネットワーク、またはカスタムコンフィグレーション
- ロギング：
  
  - スマートコントラクトイベントのロギング
  - ログファイル (オプションでローテーティング)
  - ログレベル

設定を変更するには、設定インスタンスを次のようにインポートします。

```
from neo.Settings import settings

```

## ネットワークの設定

次の設定方法を使い、ネットワークを設定することができます。

```
settings.setup_mainnet()
settings.setup_testnet()
settings.setup_privnet()
settings.setup(config_file)

```

デフォルトにより、`neo-python`はテストネットを使用します。

## ロギング

neo-pythonは以下のデフォルトを使います。

- スマートコントラクトによるすべてのイベントはログレベルINFOとともにログされます。
- ログレベルはINFOにセットされます。
- ログファイルへのロギングは無効化されます (prompt.py は prompt.log にログします) 。

### スマートコントラクトイベント

すべてのスマートコントラクトイベントのロギングを無効化したい場合は、以下を行います。

```
settings.set_log_smart_contract_events(False)

```

### ログレベルの変更

ログレベルの変更をするには（例えば、DEBUGログを表示したり、ただERRORSを表示したい場合）

```
import logging

# デバッグを含む全てのログを表示:
settings.set_loglevel(logging.DEBUG)

# エラーログのみを表示:
settings.set_loglevel(logging.ERROR)

```

### ログファイルの設定

ログファイルへのロギングを有効にするためには、以下を行います。

```
# 単一ファイルへの出力（制限またはローテーションなし）:
settings.set_logfile(your_logfile_path)

# ファイルごとに最大10MB、3世代までローテーションを行う:
settings.set_logfile(your_logfile_path, 1e7, 3)

```

### カスタムコードでのロギング

neo-pythonはロギングのために[logzero](https://logzero.readthedocs.io/)を使用します。loggerを既存のneoのロギング設定とともに用いるには、logzeroからloggerをインポートします。

```
from logzero import logger

# これらのログはコンソールへ出力されます
logger.debug("hello")
logger.info("info")
logger.warn("warn")
logger.error("error")

# 例外のロギングを行う
try:
    raise Exception("this is a demo exception")
except Exception as e:
    logger.exception(e)
```

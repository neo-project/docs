# Локальная сеть

Вы можете использовать локальную сеть в целях разработки (см [NEO-Local](https://github.com/CityOfZion/neo-local) ).

**Note:** Предназначен только для разработки. Компоненты Neo, использованные в изображениях этих докеров, могут быть не самыми актуальными. **Всегда проверяйте свой смарт-контракт с помощью Testnet.**

**Требуется Docker**
Данный проект использует Докер и инструмент его композиции. Он работает на компьютерах MacOS, Linux и Windows. Дополнительную информацию по Докеру см. на его [официальном сайтем](https://www.docker.com/).


![image](../../assets/neolocal.png)


## Содержание Neo-local 
NEO-local запускает несколько контейнеров:
  - 4 узла консенсуса – полностью рабочая сеть
  - Block explorer \(Neoscan\);
  - Сервер уведомлений \(Neo-python\);
  - Инструменты разработки \(Neo-python\);
  - Кошелек с GAS;
  - Developer faucet (для получения дополнительных GAS);

## Простая настройка
После установки докера и docker-compose:
  1. Клонирейте репозиторий:  https://github.com/CityOfZion/neo-local
  2. В терминале или powershell изменить на недавно клонированный каталог на вашем компьютере: ```cd ./neo-local ```. 
  3. Выполнить ```docker-compose up ```. 
  4. После завершения настройки проверьте, все ли запущено (доступ к `http://localhost:4000` осуществляется посредством вашего браузера).


Дополнительную информацию см. в [Neo-local wiki](https://github.com/CityOfZion/neo-local/wiki).
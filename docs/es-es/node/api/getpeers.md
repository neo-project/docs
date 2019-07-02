# Método Getpeers

Devuelve la lista de pares que estan conectados, desconectados o con problemas.

## Parámetros

No hay parámetros.

## Ejemplo de llamada

Petición

http://node:10332?jsonrpc=2.0&method=getpeers&params=[]&id=1

```json
{
	"jsonrpc": "2.0",
	"method": "getpeers",
	"params":[],
	"id": 1
}
```

Respuesta:

```json
{
   "jsonrpc":"2.0",
   "id":1,
   "result":{
      "unconnected":[
         {
            "address":"::ffff:66.234.193.111",
            "port":10333
         },
         {
            "address":"::ffff:136.63.93.161",
            "port":10333
         },
         {
            "address":"::ffff:122.108.255.60",
            "port":10333
         },
         {
            "address":"::ffff:70.79.246.55",
            "port":10333
         },
         {
            "address":"::ffff:71.187.177.127",
            "port":10333
         },
         {
            "address":"::ffff:108.202.183.210",
            "port":10333
         },
         {
            "address":"::ffff:209.6.216.220",
            "port":10333
         },
         {
            "address":"::ffff:47.196.165.202",
            "port":10333
         },
         {
            "address":"::ffff:139.224.36.76",
            "port":10333
         },
         {
            "address":"::ffff:45.28.140.116",
            "port":10333
         },
         {
            "address":"::ffff:173.73.172.105",
            "port":10333
         },
         {
            "address":"::ffff:70.127.36.23",
            "port":10333
         },
         {
            "address":"::ffff:68.70.15.151",
            "port":10333
         },
         {
            "address":"::ffff:70.191.112.178",
            "port":10333
         },
         {
            "address":"::ffff:24.167.204.81",
            "port":10333
         },
         {
            "address":"::ffff:24.72.20.27",
            "port":10333
         }
      ],
      "bad":[
         {
            "address":"::ffff:47.88.53.224",
            "port":10333
         },
         {
            "address":"::ffff:47.91.92.192",
            "port":10333
         },
         {
            "address":"::ffff:139.219.106.33",
            "port":10333
         },
         {
            "address":"::ffff:119.29.219.17",
            "port":10333
         }
      ],
      "connected":[
         {
            "address":"::ffff:139.219.226.107",
            "port":10333
         },
         {
            "address":"::ffff:132.147.84.54",
            "port":10333
         },
         {
            "address":"::ffff:96.55.123.123",
            "port":10333
         },
         {
            "address":"::ffff:66.68.51.182",
            "port":10333
         },
         {
            "address":"::ffff:174.2.172.22",
            "port":10333
         },
         {
            "address":"::ffff:198.27.223.78",
            "port":10333
         },
         {
            "address":"::ffff:220.255.209.37",
            "port":10333
         },
         {
            "address":"::ffff:24.242.196.62",
            "port":10333
         },
         {
            "address":"::ffff:50.24.233.1",
            "port":10333
         },
         {
            "address":"::ffff:98.214.241.225",
            "port":10333
         }
      ]
   }
}
```

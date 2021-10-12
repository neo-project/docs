# getstateroot Method

Queries the state root by the block height.

> [!Note]
>
> You must install the plugin [StateService](https://github.com/neo-project/neo-modules/releases) and [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- index: Block index

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getstateroot",
  "params": [160],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "version": 0,
        "index": 160,
        "roothash": "0x28870d1ed61ef167e99354249c622504b0d81d814eaa87dbf8612c91b9b303b7",
        "witness": {
            "invocation": "DEDN8o6cmOUt/pfRIexVzO2shhX2vTYFd+cU8vZDQ2Dvn3pe/vHcYOSlY3lPRKecb5zBuLCqaKSvZsC1FAbT00dWDEDoPojyFw66R+pKQsOy0MFmeBBgaC6Z1XGLAigVDHi2VuhAxfpwFpXSTUv3Uv5cIOY+V5g40+2zpU19YQIAWyOJDEDPfitQTjK90KnrloPXKvgTNFPn1520dxDCzQxhl/Wfp7S8dW91/3x3GrF1EaIi32aJtF8W8jUH1Spr/ma66ISs",
            "verification": "EwwhAwAqLhjDnN7Qb8Yd2UoHuOnz+gNqcFvu+HZCUpVOgtDXDCECAM1gQDlYokm5qzKbbAjI/955zDMJc2eji/a1GIEJU2EMIQKXhyDsbFxYdeA0d+FsbZj5AQhamA13R64ysGgh19j6UwwhA8klCeQozdf3pP3UqXxniRC0DxRl3d5PBJ9zJa8zgHkpFAtBE43vrw=="
        }
    }
}
```
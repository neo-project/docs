# コントラクト呼び出し

```c#
[AppCall]("XXXXXXXXXX") // スクリプトハッシュ
public static extern int AnotherContract (string arg);

public static void Main ()
{
     AnotherContract ("Hello");
}
```

これを使用してスマートコントラクト内で、チェーンに公開されている他のスマートコントラクトを呼び出すことができます。
1. AppCallと呼び出すコントラクトのスクリプトハッシュによるC#への宣言を追加します。
2. コード内で呼び出します。

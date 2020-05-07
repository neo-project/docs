# Iterator Class

Represents the enumerator.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Iterator<TKey, TValue>
```

## Attributes

| Name                       | Description                           |
| -------------------------- | ------------------------------------- |
| [Key](Iterator/Key.md)     | Gets the Key for the current cursor   |
| [Value](Iterator/Value.md) | Gets the value for the current cursor |

## Method

| Name                       | Description                                                  |
| -------------------------- | ------------------------------------------------------------ |
| [Next()](Iterator/Next.md) | Moves the cursor down and returns the cursor status (true: not to the end; false: to the end) |

## Constructor

The `Iterator\<TKey, TValue>` object is constructed through [Storage.Find(...)](Storage.md).
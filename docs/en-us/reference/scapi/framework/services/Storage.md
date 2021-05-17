# Storage Class

Provides a set of methods to insert, query, and delete data in the persistent storage.

Namespace：[Neo.SmartContract.Framework.Services](../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Storage
```

## Attributes

| Name                                   | Description |
| ---------------------------------------- | ---------- |
| [CurrentContext](Storage/CurrentContext.md) | Returns the current storage context |
| CurrentReadOnlyContext | Returns the read-only context of the current contract storage |

## Methods

| Name                                    | Description                    |
| ---------------------------------------- | -------------------------------- |
| [Delete](Storage/Delete.md) | Deletes the value corresponding to the key from the given storage context. This method has multiple overloads. |
| [Get](Storage/Get.md) | Gets the byte[] value corresponding to the given key from the given storage context. This method has multiple overloads. |
| [Put](Storage/Put.md) | Puts the key-value pair into the given storage context. This method has multiple overloads. |
| [Find](Storage/Find.md) | Finds the content in the given storage context. This method has multiple overloads. |

## Constructor

The Storage class is a static class and does not require a constructor.
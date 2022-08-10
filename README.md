# Udon Array Extensions

Collection of array extension methods compatible with UdonSharp 1.x which adds partial feature set from List
  
| **Method** | **Parameters** | **Description** |
| - | - | - |
| `Add` | `T` | *Adds an item to an array* |
| `AddUnique` | `T` | *Adds an item to an array and ensures duplicates are not added* |
| `AddRange` | `T[]` | *Adds the elements of the specified collection to the end of the array* |
| `Insert` | `Int, T` | *Inserts item to array at index* |
| `InsertRange` | `Int, T[]` | *Inserts the elements of a collection into the <T>[] at the specified index* |
| `Remove` | `T` | *Removes item from array* |
| `RemoveAt` | `Int` | *Removes item at index from array* |
| `Resize` | `Int` | *Resizes array* |
| `Reverse` | | *Reverses Array* |
| `Contains` | `T` | *Determines whether an element is in the array* |
| `GetRange` | `Int, Int` | *Creates a shallow copy of a range of elements in the source* |

## Usage Demonstration
```csharp
using UdonSharp;
using UnityEngine;
using Varneon.UdonArrayExtensions;

public class UdonArrayExtensionDemo : UdonSharpBehaviour
{
    [SerializeField]
    private string[] strings;

    [SerializeField]
    private string[] range;

    [SerializeField]
    private string text;

    [SerializeField]
    private int index;

    [SerializeField]
    private int count;

    public void Add()
    {
        strings = strings.Add(text);
    }

    public void AddRange()
    {
        strings = strings.AddRange(range);
    }

    public void AddUnique()
    {
        strings = strings.AddUnique(text);
    }

    public void Insert()
    {
        strings = strings.Insert(index, text);
    }

    public void InsertRange()
    {
        strings = strings.InsertRange(index, range);
    }

    public void Resize()
    {
        strings = strings.Resize(index);
    }

    public void Remove()
    {
        strings = strings.Remove(text);
    }

    public void RemoveAt()
    {
        strings = strings.RemoveAt(index);
    }

    public void Reverse()
    {
        strings = strings.Reverse();
    }

    public void GetRange()
    {
        Debug.Log(string.Join("\n", strings.GetRange(index, count)));
    }

    public void Contains()
    {
        Debug.Log(strings.Contains(text));
    }
}

```

## Installation via Unity Package Manager (git):
1. Navigate to your toolbar: `Window` > `Package Manager` > `[+]` > `Add package from git URL...` and type in: `https://github.com/Varneon/UdonArrayExtensions.git?path=/Packages/com.varneon.udon-array-extensions`

## Installation via Unitypackage:
1. Download latest UdonExplorer from [here](https://github.com/Varneon/UdonArrayExtensions/releases/latest)
2. Import the downloaded .unitypackage into your Unity project

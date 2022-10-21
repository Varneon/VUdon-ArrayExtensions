<div>

# VUdon - Array Extensions [![GitHub](https://img.shields.io/github/license/Varneon/VUdon-ArrayExtensions?color=blue&label=License&style=flat)](https://github.com/Varneon/VUdon-ArrayExtensions/blob/main/LICENSE) [![GitHub Repo stars](https://img.shields.io/github/stars/Varneon/VUdon-ArrayExtensions?style=flat&label=Stars)](https://github.com/Varneon/VUdon-ArrayExtensions/stargazers) [![GitHub all releases](https://img.shields.io/github/downloads/Varneon/VUdon-ArrayExtensions/total?color=blue&label=Downloads&style=flat)](https://github.com/Varneon/VUdon-ArrayExtensions/releases) [![GitHub tag (latest SemVer)](https://img.shields.io/github/v/tag/Varneon/VUdon-ArrayExtensions?color=blue&label=Release&sort=semver&style=flat)](https://github.com/Varneon/VUdon-ArrayExtensions/releases/latest)

</div>

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
using Varneon.VUdon.ArrayExtensions;

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

# Installation

<details><summary>

### Import with [VRChat Creator Companion](https://vcc.docs.vrchat.com/vpm/packages#user-packages):</summary>

> 1. Download `com.varneon.vudon.array-extensions.zip` from [here](https://github.com/Varneon/VUdon-ArrayExtensions/releases/latest)
> 2. Unpack the .zip somewhere
> 3. In VRChat Creator Companion, navigate to `Settings` > `User Packages` > `Add`
> 4. Navigate to the unpacked folder, `com.varneon.vudon.array-extensions` and click `Select Folder`
> 5. `VUdon - Array Extensions` should now be visible under `Local User Packages` in the project view in VRChat Creator Companion
> 6. Click `Add`

</details><details><summary>

### Import with [Unity Package Manager (git)](https://docs.unity3d.com/2019.4/Documentation/Manual/upm-ui-giturl.html):</summary>

> 1. In the Unity toolbar, select `Window` > `Package Manager` > `[+]` > `Add package from git URL...` 
> 2. Paste the following link: `https://github.com/Varneon/VUdon-ArrayExtensions.git?path=/Packages/com.varneon.vudon.array-extensions`

</details><details><summary>

### Import from [Unitypackage](https://docs.unity3d.com/2019.4/Documentation/Manual/AssetPackagesImport.html):</summary>

> 1. Download latest `com.varneon.vudon.array-extensions.unitypackage` from [here](https://github.com/Varneon/VUdon-ArrayExtensions/releases/latest)
> 2. Import the downloaded .unitypackage into your Unity project

</details>

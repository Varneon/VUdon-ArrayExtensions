<div>

# [VUdon](https://github.com/Varneon/VUdon) - Array Extensions ![](https://img.shields.io/badge/UdonSharp-Library-bb37fa) [![GitHub Repo stars](https://img.shields.io/github/stars/Varneon/VUdon-ArrayExtensions?style=flat&label=Stars)](https://github.com/Varneon/VUdon-ArrayExtensions/stargazers) [![GitHub all releases](https://img.shields.io/github/downloads/Varneon/VUdon-ArrayExtensions/total?color=blue&label=Downloads&style=flat)](https://github.com/Varneon/VUdon-ArrayExtensions/releases) [![GitHub tag (latest SemVer)](https://img.shields.io/github/v/tag/Varneon/VUdon-ArrayExtensions?color=blue&label=Release&sort=semver&style=flat)](https://github.com/Varneon/VUdon-ArrayExtensions/releases/latest)

</div>

Collection of array extension methods compatible with UdonSharp 1.x which adds partial feature set from List

| **Method** | **Parameters** | **Returns** | **Description** |
| - | - | - | - |
| `Add` | `T` | `T[]` | *Adds an item to an array* |
| `AddUnique` | `T` | `T[]` | *Adds an item to an array and ensures duplicates are not added* |
| `AddRange` | `T[]` | `T[]` | *Adds the elements of the specified collection to the end of the array* |
| `Insert` | `Int, T` | `T[]` | *Inserts item to array at index* |
| `InsertRange` | `Int, T[]` | `T[]` | *Inserts the elements of a collection into the <T>[] at the specified index* |
| `Remove` | `T` | `T[]` | *Removes item from array* |
| `RemoveAt` | `Int` | `T[]` | *Removes item at index from array* |
| `Resize` | `Int` | `T[]` | *Resizes array* |
| `Reverse` | | `T[]` | *Reverses Array* |
| `Contains` | `T` | `bool` | *Determines whether an element is in the array* |
| `GetRange` | `Int, Int` | `T[]` | *Creates a shallow copy of a range of elements in the source* |
| `GetElementTypeUdon` | | `Type` | *Gets the element type of the array type* |
| `FirstOrDefault` | | `T` | *Returns the first element, or default value if the array is empty* |
| `LastOrDefault` | | `T` | *Returns the last element, or default value if the array is empty* |

> ### :warning: For performance reasons this extension method library doesn't implement null checks! Please ensure the arrays you're accessing with the methods from this library are initialized.

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

<div align="center">

## Developed by Varneon with :hearts:

![Twitter Follow](https://img.shields.io/twitter/follow/Varneon?color=%231c9cea&label=%40Varneon&logo=Twitter&style=for-the-badge)
![YouTube Channel Subscribers](https://img.shields.io/youtube/channel/subscribers/UCKTxeXy7gyaxr-YA9qGWOYg?color=%23FF0000&label=Varneon&logo=YouTube&style=for-the-badge)
![GitHub followers](https://img.shields.io/github/followers/Varneon?color=%23303030&label=Varneon&logo=GitHub&style=for-the-badge)

</div>

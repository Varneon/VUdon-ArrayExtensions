<div>

# [VUdon](https://github.com/Varneon/VUdon) - Array Extensions ![](https://img.shields.io/badge/UdonSharp-Library-bb37fa) [![GitHub Repo stars](https://img.shields.io/github/stars/Varneon/VUdon-ArrayExtensions?style=flat&label=Stars)](https://github.com/Varneon/VUdon-ArrayExtensions/stargazers) [![GitHub all releases](https://img.shields.io/github/downloads/Varneon/VUdon-ArrayExtensions/total?color=blue&label=Downloads&style=flat)](https://github.com/Varneon/VUdon-ArrayExtensions/releases) [![GitHub tag (latest SemVer)](https://img.shields.io/github/v/tag/Varneon/VUdon-ArrayExtensions?color=blue&label=Release&sort=semver&style=flat)](https://github.com/Varneon/VUdon-ArrayExtensions/releases/latest)

</div>

Collection of array extension methods compatible with UdonSharp 1.x which adds partial feature set from List

| **Method** | **Parameters** | **Returns** | **Description** |
| - | - | - | - |
| `Add` | `T` | `T[]` | *Adds an item to an array* |
| `AddRange` | `T[]` | `T[]` | *Adds the elements of the specified collection to the end of the array* |
| `AddUnique` | `T` | `T[]` | *Adds an item to an array and ensures duplicates are not added* |
| `Contains` | `T` | `bool` | *Determines whether an element is in the array* |
| `FirstOrDefault` | | `T` | *Returns the first element, or default value if the array is empty* |
| `GetElementTypeUdon` | | `Type` | *Gets the element type of the array type* |
| `GetRange` | `Int, Int` | `T[]` | *Creates a shallow copy of a range of elements in the source* |
| `IndexOf` | `T` (`Int`, `Int`) | `Int` | *Returns the zero-based index of the first occurrence of a value in the T[]* |
| `Insert` | `Int, T` | `T[]` | *Inserts item to array at index* |
| `InsertRange` | `Int, T[]` | `T[]` | *Inserts the elements of a collection into the <T>[] at the specified index* |
| `LastIndexOf` | `T` (`Int`, `Int`) | `Int` | *Returns the zero-based index of the last occurrence of a value in the T[]* |
| `LastOrDefault` | | `T` | *Returns the last element, or default value if the array is empty* |
| `Remove` | `T` | `T[]` | *Removes item from array* |
| `RemoveAt` | `Int` | `T[]` | *Removes item at index from array* |
| `RemoveRange` | `Int, Int` | `T[]` | *Removes a range of elements from the T[]* |
| `Resize` | `Int` | `T[]` | *Resizes array* |
| `Reverse` | | `T[]` | *Reverses Array* |

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

    public void UsageDemo()
    {
        // Add item to array
        strings = strings.Add(text);

        // Add range of elements to array
        strings = strings.AddRange(range);
        
        // Check if item is contained in array
        Debug.Log(strings.Contains(text));

        // Get range of elements in array
        Debug.Log(string.Join("\n", strings.GetRange(index, count)));

        // Get the first index of element in array
        Debug.Log(strings.IndexOf(text));

        // Get the first index of element in array, starting at index
        Debug.Log(strings.IndexOf(text, index));

        // Get the first index of element in array in a range starting at index at the size of count
        Debug.Log(strings.IndexOf(text, index, count));

        // Insert item to array
        strings = strings.Insert(index, text);

        // Insert array of items to array
        strings = strings.InsertRange(index, range);

        // Get the last index of element in array
        Debug.Log(strings.LastIndexOf(text));

        // Get the last index of element in array, starting at index
        Debug.Log(strings.LastIndexOf(text, index));

        // Get the last index of element in array in a range starting at index at the size of count
        Debug.Log(strings.LastIndexOf(text, index, count));

        // Remove item from array
        strings = strings.Remove(text);

        // Remove item at index from array
        strings = strings.RemoveAt(index);

        // Remove range of elements from array
        strings = strings.RemoveRange(index, count);

        // Reverse array
        strings = strings.Reverse();

        // Get the first element in array
        Debug.Log(strings.FirstOrDefault());

        // Get the last element in array
        Debug.Log(strings.LastOrDefault());

        // Get the element type of a type
        Debug.Log(strings.GetType().GetElementTypeUdon());

        // Add unique item to array (if item exists in array, it won't be added)
        strings = strings.AddUnique(text);

        // Resize array
        strings = strings.Resize(index);
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

[![Twitter Follow](https://img.shields.io/static/v1?style=for-the-badge&label=@Varneon&message=4.9K&color=1b9df0&logo=twitter)](https://twitter.com/Varneon)
[![YouTube Channel Subscribers](https://img.shields.io/youtube/channel/subscribers/UCKTxeXy7gyaxr-YA9qGWOYg?color=%23FF0000&label=Varneon&logo=YouTube&style=for-the-badge)](https://www.youtube.com/Varneon)
[![GitHub followers](https://img.shields.io/github/followers/Varneon?color=%23303030&label=Varneon&logo=GitHub&style=for-the-badge)](https://github.com/Varneon)

</div>

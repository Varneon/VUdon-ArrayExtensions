/*
MIT License

Copyright (c) 2022 Varneon

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using UnityEngine;

namespace Varneon.VUdon.ArrayExtensions
{
    /// <summary>
    /// Array extension methods for adding partial feature set from List&lt;T&gt; and System.Linq, including replacements to methods not supported by Udon/UdonSharp and additional custom methods to UdonSharp
    /// </summary>
    public static class UdonArrayExtensions
    {
        #region System.Collections.Generic.List<T>

        /// <summary>
        /// Adds an object to the end of the array
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.add?view=net-6.0">List&lt;T&gt;.Add(T)</see>
        /// </para>
        /// </summary>
        /// <returns>Modified T[]</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="item">The object to be added to the end of the T[].</param>
        public static T[] Add<T>(this T[] array, T item)
        {
            int length = array.Length;

            T[] newArray = new T[length + 1];

            array.CopyTo(newArray, 0);

            newArray.SetValue(item, length);

            return newArray;
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the array
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.addrange?view=net-6.0">List&lt;T&gt;.AddRange(IEnumerable&lt;T&gt;)</see>
        /// </para>
        /// </summary>
        /// <returns>Modified T[]</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="collection">The collection whose elements should be added to the end of the T[].</param>
        public static T[] AddRange<T>(this T[] array, T[] collection)
        {
            int length = array.Length;

            int collectionLength = collection.Length;

            T[] newArray = new T[length + collectionLength];

            array.CopyTo(newArray, 0);

            collection.CopyTo(newArray, length);

            return newArray;
        }

        /// <summary>
        /// Determines whether an element is in the array
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains?view=net-6.0">List&lt;T&gt;.Contains(T)</see>
        /// </para>
        /// </summary>
        /// <returns><b><i>true</i></b> if <b><i>item</i></b> is found in the T[]; otherwise, <b><i>false</i></b>.</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="item">The object to locate in the T[].</param>
        public static bool Contains<T>(this T[] array, T item)
        {
            return Array.IndexOf(array, item) >= 0;
        }

        /// <summary>
        /// Creates a shallow copy of a range of elements in the source array
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.getrange?view=net-6.0">List&lt;T&gt;.GetRange(Int32, Int32)</see>
        /// </para>
        /// </summary>
        /// <returns>A shallow copy of a range of elements in the source T[].</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="index">The zero-based T[] index at which the range starts.</param>
        /// <param name="count">The number of elements in the range.</param>
        public static T[] GetRange<T>(this T[] array, int index, int count)
        {
            int length = array.Length;

            index = Mathf.Clamp(index, 0, length);

            count = Mathf.Clamp(count, 0, length - index);

            T[] newArray = new T[count];

            Array.Copy(array, index, newArray, 0, count);

            return newArray;
        }

        /// <summary>
        /// Returns the zero-based index of the first occurrence of a value in the T[].
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.indexof?view=net-6.0">List&lt;T&gt;.IndexOf(T)</see>
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to locate the object in.</param>
        /// <param name="item">The object to locate in the T[].</param>
        /// <returns>The zero-based index of the first occurrence of <b><i>item</i></b> within the range of elements in the T[], if found; otherwise, -1.</returns>
        public static int IndexOf<T>(this T[] array, T item)
        {
            return Array.IndexOf(array, item);
        }

        /// <summary>
        /// Returns the zero-based index of the first occurrence of a value in the T[] or in a portion of it.
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.indexof?view=net-6.0">List&lt;T&gt;.IndexOf(T, Int32)</see>
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to locate the object in.</param>
        /// <param name="item">The object to locate in the T[].</param>
        /// <param name="startIndex">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <returns>The zero-based index of the first occurrence of <b><i>item</i></b> within the range of elements in the T[] that starts at index, if found; otherwise, -1.</returns>
        public static int IndexOf<T>(this T[] array, T item, int startIndex)
        {
            return Array.IndexOf(array, item, startIndex);
        }

        /// <summary>
        /// Returns the zero-based index of the first occurrence of a value in the T[] or in a portion of it.
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.indexof?view=net-6.0">List&lt;T&gt;.IndexOf(T, Int32, Int32)</see>
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to locate the object in.</param>
        /// <param name="item">The object to locate in the T[].</param>
        /// <param name="startIndex">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The zero-based index of the first occurrence of <b><i>item</i></b> within the range of elements in the T[] that starts at index and contains count number of elements, if found; otherwise, -1.</returns>
        public static int IndexOf<T>(this T[] array, T item, int startIndex, int count)
        {
            return Array.IndexOf(array, item, startIndex, count);
        }

        /// <summary>
        /// Inserts an element into the array at the specified index
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.insert?view=net-6.0">List&lt;T&gt;.Insert(Int32, T)</see>
        /// </para>
        /// </summary>
        /// <returns>Modified T[]</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="index">The zero-based index at which <b><i>item</i></b> should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        public static T[] Insert<T>(this T[] array, int index, T item)
        {
            int length = array.Length;

            index = Mathf.Clamp(index, 0, length);

            T[] newArray = new T[length + 1];

            newArray.SetValue(item, index);

            if (index == 0)
            {
                Array.Copy(array, 0, newArray, 1, length);
            }
            else if (index == length)
            {
                Array.Copy(array, 0, newArray, 0, length);
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index, newArray, index + 1, length - index);
            }

            return newArray;
        }

        /// <summary>
        /// Inserts the elements of a collection into the array at the specified index
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.insertrange?view=net-6.0">List&lt;T&gt;.InsertRange(Int32, IEnumerable<T>)</see>
        /// </para>
        /// </summary>
        /// <returns>Modified T[]</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the T[].</param>
        public static T[] InsertRange<T>(this T[] array, int index, T[] collection)
        {
            int length = array.Length;

            int collectionLength = collection.Length;

            int newLength = length + collectionLength;

            index = Mathf.Clamp(index, 0, length);

            T[] newArray = new T[newLength];

            if (index == 0)
            {
                Array.Copy(array, 0, newArray, collectionLength, length);
                Array.Copy(collection, 0, newArray, 0, collectionLength);
            }
            else if (index == length)
            {
                Array.Copy(array, 0, newArray, 0, length);
                Array.Copy(collection, 0, newArray, index, collectionLength);
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(collection, 0, newArray, index, collectionLength);
                Array.Copy(array, index, newArray, index + collectionLength, newLength - index - collectionLength);
            }

            return newArray;
        }

        /// <summary>
        /// Returns the zero-based index of the last occurrence of a value in the T[].
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.lastindexof?view=net-6.0">List&lt;T&gt;.LastIndexOf(T)</see>
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to locate the object in.</param>
        /// <param name="item">The object to locate in the T[].</param>
        /// <returns>The zero-based index of the last occurrence of <b><i>item</i></b> within the range of elements in the T[], if found; otherwise, -1.</returns>
        public static int LastIndexOf<T>(this T[] array, T item)
        {
            return Array.LastIndexOf(array, item);
        }

        /// <summary>
        /// Returns the zero-based index of the last occurrence of a value in the T[] or in a portion of it.
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.lastindexof?view=net-6.0">List&lt;T&gt;.LastIndexOf(T, Int32)</see>
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to locate the object in.</param>
        /// <param name="item">The object to locate in the T[].</param>
        /// <param name="startIndex">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <returns>The zero-based index of the last occurrence of <b><i>item</i></b> within the range of elements in the T[] that starts at index, if found; otherwise, -1.</returns>
        public static int LastIndexOf<T>(this T[] array, T item, int startIndex)
        {
            return Array.LastIndexOf(array, item, startIndex);
        }

        /// <summary>
        /// Returns the zero-based index of the last occurrence of a value in the T[] or in a portion of it.
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.lastindexof?view=net-6.0">List&lt;T&gt;.LastIndexOf(T, Int32, Int32)</see>
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to locate the object in.</param>
        /// <param name="item">The object to locate in the T[].</param>
        /// <param name="startIndex">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The zero-based index of the last occurrence of <b><i>item</i></b> within the range of elements in the T[] that starts at index and contains count number of elements, if found; otherwise, -1.</returns>
        public static int LastIndexOf<T>(this T[] array, T item, int startIndex, int count)
        {
            return Array.LastIndexOf(array, item, startIndex, count);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the array
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.remove?view=net-6.0">List&lt;T&gt;.Remove(T)</see>
        /// </para>
        /// </summary>
        /// <returns>Modified T[]</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="item">The object to remove from the T[].</param>
        public static T[] Remove<T>(this T[] array, T item)
        {
            int index = Array.IndexOf(array, item);

            if (index == -1) { return array; }

            return array.RemoveAt(index);
        }

        /// <summary>
        /// Removes the element at the specified index of the array
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removeat?view=net-6.0">List&lt;T&gt;.RemoveAt(Int32)</see>
        /// </para>
        /// </summary>
        /// <returns>Modified T[]</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public static T[] RemoveAt<T>(this T[] array, int index)
        {
            int length = array.Length;

            if(index >= length || index < 0) { return array; }

            int maxIndex = length - 1;

            T[] newArray = new T[maxIndex];

            if (index == 0)
            {
                Array.Copy(array, 1, newArray, 0, maxIndex);
            }
            else if(index == maxIndex)
            {
                Array.Copy(array, 0, newArray, 0, maxIndex);
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index + 1, newArray, index, maxIndex - index);
            }

            return newArray;
        }

        /// <summary>
        /// Removes a range of elements from the T[].
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removerange?view=net-6.0">List&lt;T&gt;.RemoveRange(Int32, Int32)</see>
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="index">The zero-based T[] index at which the range starts.</param>
        /// <param name="count">The number of elements in the range.</param>
        /// <returns>Modified T[]</returns>
        public static T[] RemoveRange<T>(this T[] array, int index, int count)
        {
            int length = array.Length;

            if (index + count > length || index < 0 || count <= 0) { return array; }

            int maxIndex = length - count;

            T[] newArray = new T[maxIndex];

            if(index == 0)
            {
                Array.Copy(array, count, newArray, 0, maxIndex);
            }
            else if(index + count - 1 == maxIndex)
            {
                Array.Copy(array, 0, newArray, 0, maxIndex);
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index + count, newArray, index, maxIndex - index);
            }

            return newArray;
        }

        /// <summary>
        /// Reverses the order of the elements in the entire array
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.reverse?view=net-6.0">List&lt;T&gt;.Reverse</see>
        /// </para>
        /// </summary>
        /// <returns>Modified T[]</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        public static T[] Reverse<T>(this T[] array)
        {
            Array.Reverse(array);

            return array;
        }

        #endregion

        #region System.Linq

        /// <summary>
        /// Returns the first element of the sequence, or a specified default value if no such element is found.
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault?view=net-6.0">Enumerable.FirstOrDefault</see>
        /// </para>
        /// </summary>
        /// <returns>The first element of a sequence, or a default value if no element is found</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[].</param>
        public static T FirstOrDefault<T>(this T[] array)
        {
            if (array.Length == 0) { return default; }

            return array[0];
        }

        /// <summary>
        /// Returns the last element of a sequence, or a specified default value if the sequence contains no elements.
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.lastordefault?view=net-6.0">Enumerable.LastOrDefault</see>
        /// </para>
        /// </summary>
        /// <returns>The last element of a sequence, or a default value if no element is found</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[].</param>
        public static T LastOrDefault<T>(this T[] array)
        {
            int length = array.Length;

            if (length == 0) { return default; }

            return array[length - 1];
        }

        #endregion

        #region System.Type

        /// <summary>
        /// Gets the element type of the array type
        /// <para>
        /// Based on: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.type.getelementtype?view=net-6.0">Type.GetElementType</see>
        /// </para>
        /// </summary>
        /// <returns>The <see href="https://learn.microsoft.com/en-us/dotnet/api/system.type?view=net-6.0">Type</see> of the object encompassed or referred to by the current array</returns>
        /// <remarks>
        /// Type.GetElementType() is not exposed in Udon
        /// </remarks>
        /// <param name="type">Array type of which to get the element type.</param>
        public static Type GetElementTypeUdon(this Type type)
        {
            return Type.GetType(type.FullName.TrimEnd(']', '['));
        }

        #endregion

        #region Custom

        /// <summary>
        /// Adds an object to the end of the array while ensuring that duplicates are not added
        /// </summary>
        /// <returns>Modified T[]</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="item">The object to be added to the end of the T[].</param>
        public static T[] AddUnique<T>(this T[] array, T item)
        {
            if (Array.IndexOf(array, item) >= 0) { return array; }

            return array.Add(item);
        }

        /// <summary>
        /// Resizes the array
        /// </summary>
        /// <returns>Modified T[]</returns>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">Source T[] to modify.</param>
        /// <param name="newSize">New size of the array.</param>
        public static T[] Resize<T>(this T[] array, int newSize)
        {
            if (newSize < 0) { newSize = 0; }

            T[] newArray = new T[newSize];

            Array.Copy(array, 0, newArray, 0, Mathf.Min(newSize, array.Length));

            return newArray;
        }

        #endregion
    }
}

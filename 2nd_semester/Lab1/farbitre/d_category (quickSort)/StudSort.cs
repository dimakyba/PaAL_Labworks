using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if VALUE_IS_DOUBLE
	using ValueType = System.Double;
#else
#if VALUE_IS_SHORT
	using ValueType = System.Int16;
#else
#if VALUE_IS_LONG
	using ValueType = System.Int64;
#else
using ValueType = System.Int32;
#endif
#endif
#endif

using System;

using System;

namespace SortTest
{
  class StudSort
  {
    // You may add more method(s) here, if needed
    // (f.e., for recursive quicksort or recursive mergesort)

    public static ValueType[] Sort(ValueType[] data) // DON'T CHANGE this line!!!
    {
      QuickSort(data, 0, data.Length - 1);

      // Add code which actually sorts.
      // Use int type for indice and ValueType for values in array.
      // If you change ValueType[] data (it IS allowed andf weakly recommended),
      // just leave "return data" as is.
      // If you create another array with sorted data, change "return data" with returning of that new array
      return data;
    }

    public static void QuickSort(ValueType[] arr, int low, int high)
    {
      if (low < high)
      {
        int pi = Partition(arr, low, high);

        QuickSort(arr, low, pi - 1);
        QuickSort(arr, pi + 1, high);
      }
    }

    public static int Partition(ValueType[] arr, int low, int high)
    {
      ValueType pivot = arr[high];
      int i = (low - 1);

      for (int j = low; j < high; j++)
      {
        if (arr[j] < pivot)
        {
          i++;
          ValueType temp = arr[i];
          arr[i] = arr[j];
          arr[j] = temp;
        }
      }

      int temp1 = arr[i + 1];
      arr[i + 1] = arr[high];
      arr[high] = temp1;

      return i + 1;
    }


  }
}

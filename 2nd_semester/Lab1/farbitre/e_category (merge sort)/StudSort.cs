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

namespace SortTest
{
  class StudSort
  {
    // You may add more method(s) here, if needed
    // (f.e., for recursive quicksort or recursive mergesort)

    public static ValueType[] Sort(ValueType[] data) // DON'T CHANGE this line!!!
    {
      int l = 0, r = data.Length - 1;
      // int m = (l + r) / 2;
      MergeSort(data,l,r);




      // Add code which actually sorts.
      // Use int type for indice and ValueType for values in dataay.
      // If you change ValueType[] data (it IS allowed andf weakly recommended),
      // just leave "return data" as is.
      // If you create another dataay with sorted data, change "return data" with returning of that new dataay
      return data;
    }

    public static void MergeSort(ValueType[] data, int l, int r)
    {
      if (l < r)
      {
        int m = (l + r) / 2;
        MergeSort(data, l, m);
        MergeSort(data, m + 1, r);
        Merge(data, l, m, r);
      }
    }


    public static void Merge(ValueType[] arr, int l, int m, int r)
    {
      int n1 = m - l + 1;
      int n2 = r - m;

      ValueType[] L = new ValueType[n1];
      ValueType[] R = new ValueType[n2];
      int i, j;

      for (i = 0; i < n1; ++i)
        L[i] = arr[l + i];
      for (j = 0; j < n2; ++j)
        R[j] = arr[m + 1 + j];

      i = 0;
      j = 0;

      int k = l;
      while (i < n1 && j < n2)
      {
        if (L[i] <= R[j])
        {
          arr[k] = L[i];
          i++;
        }
        else
        {
          arr[k] = R[j];
          j++;
        }
        k++;
      }
      while (i < n1)
      {
        arr[k] = L[i];
        i++;
        k++;
      }

      while (j < n2)
      {
        arr[k] = R[j];
        j++;
        k++;
      }
    }
  }
}

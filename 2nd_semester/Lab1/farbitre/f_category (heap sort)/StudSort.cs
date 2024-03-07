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

    public static ValueType[] Sort(ValueType[] data)
    {

      int n = data.Length;

      for (int i = n / 2 - 1; i >= 0; i--)
      {
        Heapify(data, n, i);
      }

      for (int i = n - 1; i >= 0; i--)
      {
        ValueType temp = data[0];
        data[0] = data[i];
        data[i] = temp;

        Heapify(data, i, 0);
      }



      // Add code which actually sorts.
      // Use int type for indice and ValueType for values in dataay.
      // If you change ValueType[] data (it IS allowed andf weakly recommended),
      // just leave "return data" as is.
      // If you create another dataay with sorted data, change "return data" with returning of that new dataay
      return data;
    }

    static void Heapify(ValueType[] data, int n, int i)
    {
      int largest = i;
      int l = 2 * i + 1;
      int r = 2 * i + 2;

      if (l < n && data[l] > data[largest])
      {
        largest = l;
      }

      if (r < n && data[r] > data[largest])
      {
        largest = r;
      }

      if (largest != i)
      {
        ValueType swap = data[i];
        data[i] = data[largest];
        data[largest] = swap;

        Heapify(data, n, largest);
      }
    }
  }
}

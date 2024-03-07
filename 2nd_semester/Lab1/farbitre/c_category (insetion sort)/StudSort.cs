﻿using System;
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
      int length = data.Length;
      for (int i = 1; i < length; ++i)
      {
        ValueType key = data[i];
        int j = i - 1;

        while (j >= 0 && data[j] > key)
        {
          data[j + 1] = data[j];
          j--;
        }
        data[j + 1] = key;
      }




      // Add code which actually sorts.
      // Use int type for indice and ValueType for values in dataay.
      // If you change ValueType[] data (it IS allowed andf weakly recommended),
      // just leave "return data" as is.
      // If you create another dataay with sorted data, change "return data" with returning of that new dataay
      return data;
    }
  }
}

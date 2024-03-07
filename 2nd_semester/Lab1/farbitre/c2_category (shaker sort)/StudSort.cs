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
      int length = data.Length;
      bool isSwapped;
      do
      {
        isSwapped = false;
        for (int i = 0; i < length - 1; ++i)
        {
          if (data[i] > data[i + 1])
          {
            ValueType temp = data[i];
            data[i] = data[i + 1];
            data[i + 1] = temp;
            isSwapped = true;
          }
        }
        if (!isSwapped)
          break;

        isSwapped = false;
        for (int i = length - 2; i >= 0; i--)
        {
          if (data[i] > data[i + 1])
          {
            ValueType temp = data[i];
            data[i] = data[i + 1];
            data[i + 1] = temp;
            isSwapped = true;
          }
        }
      } while (isSwapped);




      // Add code which actually sorts.
      // Use int type for indice and ValueType for values in dataay.
      // If you change ValueType[] data (it IS allowed andf weakly recommended),
      // just leave "return data" as is.
      // If you create another dataay with sorted data, change "return data" with returning of that new dataay
      return data;
    }
  }
}

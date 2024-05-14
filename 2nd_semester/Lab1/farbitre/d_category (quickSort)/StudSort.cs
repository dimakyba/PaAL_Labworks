using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;

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
		static void Swap(ref ValueType a, ref ValueType b)
		{
			var temp = a; a = b; b = temp;
		}
		static void QuickSort(ValueType[] array, int left, int right)
		{
			var pivot = array[(right + left) / 2];
			int i = left; int j = right;
			do
			{
				while (array[i] < pivot) i++;
				while (array[j] > pivot) j--;
				if (i <= j)
				{
					Swap(ref array[i], ref array[j]);
					i++;
					j--;
				}
			}
			while (i < j);
			if (j > left) QuickSort(array, left, j);
			if (i < right) QuickSort(array, i, right);
		}
		public static ValueType[] Sort(ValueType[] data) // DON'T CHANGE this line!!!
		{
			QuickSort(data, 0, data.Length - 1);
			return data;
		}
	}
}

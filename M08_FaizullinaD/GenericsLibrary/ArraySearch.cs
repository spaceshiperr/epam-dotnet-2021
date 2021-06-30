using System;

namespace GenericsLibrary
{
    public static class ArraySearch
    {
		public static int BinarySearch<T>(T[] array, T x) where T : IComparable<T>
        {
			if (array is null)
				throw new ArgumentNullException(nameof(array) + ": array cannot be null");

			T[] sortedArray = new T[array.Length];

			array.CopyTo(sortedArray, 0);
			Array.Sort(sortedArray);

			var contains = BinarySearchRecursive(sortedArray, 0, sortedArray.Length - 1, x);

			if (contains)
            {
				for (int i = 0; i < array.Length; i++)
					if (array[i].Equals(x))
						return i;
				return -1;
			}
			else
				return -1;
        }

		private static bool BinarySearchRecursive<T>(T[] array, int left, int right, T x) 
			where T : IComparable<T>
		{
			if (right >= left)
			{
				int middle = left + (right - left) / 2;

				if (array[middle].Equals(x))
					return true;

				if (array[middle].CompareTo(x) > 0)
					return BinarySearchRecursive(array, left, middle - 1, x);

				return BinarySearchRecursive(array, middle + 1, right, x);
			}

			return false;
		}
	}
}

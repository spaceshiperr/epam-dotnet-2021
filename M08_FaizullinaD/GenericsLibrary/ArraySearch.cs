using System;

namespace GenericsLibrary
{
    public static class ArraySearch
    {
		public static int BinarySearch<T>(T[] array, T x) where T : IComparable<T>
        {
			if (array is null)
				throw new ArgumentNullException(nameof(array) + ": array cannot be null");

			return BinarySearchRecursive(array, 0, array.Length - 1, x);
        }

		private static int BinarySearchRecursive<T>(T[] array, int left, int right, T x) 
			where T : IComparable<T>
		{
			if (right >= left)
			{
				int middle = left + (right - left) / 2;

				if (array[middle].Equals(x))
					return middle;

				if (array[middle].CompareTo(x) > 0)
					return BinarySearchRecursive(array, left, middle - 1, x);

				return BinarySearchRecursive(array, middle + 1, right, x);
			}

			return -1;
		}
	}
}

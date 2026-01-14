namespace NETSimpleFunctions
{
    public class Sort
    {
        public static void BubbleSort<T>(T[] arr) where T : IComparable<T>
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
        }

        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[j].CompareTo(arr[minIdx]) < 0) minIdx = j;
                (arr[i], arr[minIdx]) = (arr[minIdx], arr[i]);
            }
        }

        public static void InsertionSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j].CompareTo(key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static void QuickSort<T>(T[] arr, int left, int right) where T : IComparable<T>
        {
            if (left >= right) return;
            int pivotIdx = Partition(arr, left, right);
            QuickSort(arr, left, pivotIdx - 1);
            QuickSort(arr, pivotIdx + 1, right);
        }

        private static int Partition<T>(T[] arr, int left, int right) where T : IComparable<T>
        {
            T pivot = arr[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[j].CompareTo(pivot) < 0)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);
            return i + 1;
        }

        public static void HeapSort<T>(T[] arr) where T : IComparable<T>
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--) Heapify(arr, n, i);
            for (int i = n - 1; i > 0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);
                Heapify(arr, i, 0);
            }
        }

        private static void Heapify<T>(T[] arr, int n, int i) where T : IComparable<T>
        {
            int largest = i, l = 2 * i + 1, r = 2 * i + 2;
            if (l < n && arr[l].CompareTo(arr[largest]) > 0) largest = l;
            if (r < n && arr[r].CompareTo(arr[largest]) > 0) largest = r;
            if (largest != i)
            {
                (arr[i], arr[largest]) = (arr[largest], arr[i]);
                Heapify(arr, n, largest);
            }
        }

        public static void CountingSort(int[] arr)
        {
            if (arr.Length == 0) return;
            int max = arr.Max(), min = arr.Min();
            int[] counts = new int[max - min + 1];
            foreach (int x in arr) counts[x - min]++;
            int idx = 0;
            for (int i = 0; i < counts.Length; i++)
                while (counts[i]-- > 0) arr[idx++] = i + min;
        }

        public static void RadixSortLSD(int[] arr)
        {
            int max = arr.Max();
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                int[] output = new int[arr.Length];
                int[] count = new int[10];
                foreach (int x in arr) count[(x / exp) % 10]++;
                for (int i = 1; i < 10; i++) count[i] += count[i - 1];
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                    count[(arr[i] / exp) % 10]--;
                }
                Array.Copy(output, arr, arr.Length);
            }
        }

        public static void ShellSort<T>(T[] arr) where T : IComparable<T>
        {
            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    T temp = arr[i];
                    int j;
                    for (j = i; j >= gap && arr[j - gap].CompareTo(temp) > 0; j -= gap)
                        arr[j] = arr[j - gap];
                    arr[j] = temp;
                }
            }
        }
    }
}

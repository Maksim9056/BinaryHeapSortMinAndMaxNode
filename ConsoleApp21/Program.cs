namespace ConsoleApp21
{
    using System;
    using System.Collections.Generic;

    class BinaryHeap<T> where T : IComparable<T>
    {
        public List<T> _heap;


        public BinaryHeap()
        {
            _heap = new List<T>();
        }

        public BinaryHeap(IEnumerable<T> collection)
        {
            _heap = new List<T>(collection);
            BuildHeap();
        }

        public int Size
        {
            get { return _heap.Count; }
        }

        public void Insert(T item)
        {
            _heap.Add(item);
            HeapifyUp(_heap.Count - 1);
        }

        public T ExtractMin()
        {
            if (_heap.Count == 0)
            {
                throw new Exception("Heap is empty");
            }

            T minItem = _heap[0];
            int lastIndex = _heap.Count - 1;

            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);

            if (_heap.Count > 1)
            {
                HeapifyDown(0);
            }

            return minItem;
        }

        public T ExtractMax()
        {
            if (_heap.Count == 0)
            {
                throw new Exception("Heap is empty");
            }

            T maxItem = _heap[0];
            int lastIndex = _heap.Count - 1;

            Console.WriteLine("ExtractMax:" + lastIndex);

            _heap[0] = _heap[lastIndex];
            Console.WriteLine("ExtractMax:" + _heap[0]);


            Console.WriteLine("ExtractMax:" + _heap[lastIndex]);
            _heap.RemoveAt(lastIndex);

            if (_heap.Count > 1)
            {
                HeapifyDown(0);
            }

            return maxItem;
        }
        public void BuildHeap()
        {
            int n = _heap.Count;
            for (int i = (n / 2) - 1; i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && _heap[index].CompareTo(_heap[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        public void HeapifyDown(int index)
        {
            int leftChildIndex = (2 * index) + 1;
            int rightChildIndex = (2 * index) + 2;

            int smallestIndex = index;

            if (leftChildIndex < _heap.Count && _heap[leftChildIndex].CompareTo(_heap[smallestIndex]) < 0)
            {
                smallestIndex = leftChildIndex;
            }

            if (rightChildIndex < _heap.Count && _heap[rightChildIndex].CompareTo(_heap[smallestIndex]) < 0)
            {
                smallestIndex = rightChildIndex;
            }

            if (smallestIndex != index)
            {
                Swap(index, smallestIndex);
                HeapifyDown(smallestIndex);
            }
        }


        public void HeapifyDow(int index)
        {
            int leftChildIndex = (2 * index) + 1;
            int rightChildIndex = (2 * index) + 2;

            Console.WriteLine("HeapifyDown Левому " + leftChildIndex);
            int largestIndex = index;

            Console.WriteLine("HeapifyDown Правому" + rightChildIndex);
            Console.WriteLine("HeapifyDown largestIndex" + largestIndex);

            if (leftChildIndex < _heap.Count && _heap[leftChildIndex].CompareTo(_heap[largestIndex]) < 0)
            {
                largestIndex = leftChildIndex;
            }

            if (rightChildIndex < _heap.Count && _heap[rightChildIndex].CompareTo(_heap[largestIndex]) < 0)
            {
                largestIndex = rightChildIndex;
            }

            if (largestIndex != index)
            {
                Swap(index, largestIndex);
                HeapifyDow(largestIndex);
            }
        }

        public void Swap(int i, int j)
        {
            T temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }

        public void PrintBinaryTree()
        {
            int height = (int)Math.Ceiling(Math.Log(_heap.Count, 2));
            int maxWidth = (int)Math.Pow(2, height) - 1;

            for (int i = 0; i < height; i++)
            {
                int level = (int)Math.Pow(2, i);
                int start = level - 1;
                int end = start + level;

                int space = maxWidth / (level + 1);
                Console.WriteLine();

                for (int j = start; j < end; j++)
                {
                    if (j >= _heap.Count)
                    {
                        break;
                    }

                    Console.Write(new string(' ', space));
                    Console.Write($"{_heap[j]}");
                    Console.Write(new string(' ', space));
                }

                maxWidth /= 2;
            }

            Console.WriteLine();
        }

        //public void Print()
        //{
        //    int count = _heap.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        for (int j = 0; j <Math.Pow(2, i) && j + Math.Pow(2, i) < count + 1; j++)
        //        {
        //            Console.Write(_heap[(int)(j + Math.Pow(2, i) - 1)] + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        //public void Print()
        //{
        //    int count = _heap.Count;
        //    for (int i = count - 1; i >= 0; i--)
        //    {
        //        for (int j = 0; j < Math.Pow(2, i) && j + Math.Pow(2, i) < count + 1; j++)
        //        {
        //            Console.Write(_heap[(int)(j + Math.Pow(2, i) - 1)] + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //}
        public void Print()
        {
            int count = _heap.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                for (int j = 0; j < Math.Pow(2, i) && j + Math.Pow(2, i) < count + 1; j++)
                {
                    Console.Write(_heap[(int)(j + Math.Pow(2, i) - 1)] + " ");

                    int parentIndex = (int)(j + Math.Pow(2, i) - 1) / 2;
                    if ((int)(j + Math.Pow(2, i) - 1) % 2 == 0)
                    {
                        Console.Write("/");
                    }
                    else if (parentIndex * 2 + 2 < _heap.Count)
                    {
                        Console.Write("\\");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 6, 4, 8, 2, 9, 1, 5, 7, 3 };

            List<int> mins = new List<int>();
            List<int> MAXs = new List<int>();

            BinaryHeap<int> heap = new BinaryHeap<int>(numbers);
            
            Console.WriteLine("Priority Queue (Min Heap):");
            while (heap.Size > 0)
            {
                int min = heap.ExtractMin();
                mins.Add(min);
                Console.WriteLine($"Priority: {min}");
            }

            Console.WriteLine("После сортировки");
            foreach (int i in mins)
            {
                Console.WriteLine("Сортировка Убыванию :" + i);
            }
            heap = new BinaryHeap<int>(mins);
            Console.WriteLine("Вывод ");
            heap.Print();
            Console.WriteLine("Добавили BinaryHeap Убыванию сортировки:");

            foreach (int i in heap._heap)
            {
                Console.WriteLine("BinaryHeap:" + i);

            }

            Console.WriteLine("Priority Queue (Max Heap):");

            while (heap.Size > 0)
            {
                var D= heap.ExtractMax();
                MAXs.Add(D);
                Console.WriteLine($"Priority BinaryHeap  сортировки: {D}");

            }
            heap = new BinaryHeap<int>(MAXs);
            Console.WriteLine("После сортировки на Priority Queue Max Heap:");

            foreach (int i in heap._heap)
            {
                Console.WriteLine("BinaryHeap  Max Heap:" + i);

            }

            heap.PrintBinaryTree();


            Console.WriteLine("Вывод ");
            heap. Print();
            Console.ReadLine();
        }
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    internal class DynamicArray<T> : IEnumerable<T>
    {
        public int Length { get; private set; }
        public int Capacity => DArray.Length;
        private T[] DArray { get; set; }
        public T this[int index]
        {
            get
            {
                if (index >= Length)
                {
                    throw new ArgumentOutOfRangeException("Index out of range");
                }
                return DArray[index];
            }
        }
        public DynamicArray() : this(8) { }
        public DynamicArray(int capacity)
        {
            DArray = new T[capacity];
        }
        public DynamicArray(IEnumerable<T> array)
        {
            DArray = array.ToArray();
        }
        private void CapacityIncrease()
        {
            var oldArray = DArray.ToArray();
            DArray = new T[Capacity * 2];

            for (int i = 0; i < oldArray.Length; i++)
            {
                DArray[i] = oldArray[i];
            }
        }
        public void Add(T element)
        {
            Length++;

            if (Length > Capacity)
            {
                CapacityIncrease();
            }

            DArray[Length - 1] = element;
        }

        public void AddRange(IEnumerable<T> array)
        {
            int startLength = Length;
            Length += array.ToArray().Length;

            while (Length > Capacity)
            {
                CapacityIncrease();
            }

            int j = 0;
            for (int i = startLength; i < Length; i++)
            {
                DArray[i] = array.ToArray()[j];
                j++;
            }
        }
        public bool Remove(int element)
        {
            int index = Array.IndexOf(DArray, element);
            if (index > -1)
            {
                Length--;
                for (int i = index; i < Length; i++)
                {
                    DArray[i] = DArray[i + 1];
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Insert(T element, int index)
        {
            if (index >= Length)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            Length++;

            if (Length > Capacity)
            {
                CapacityIncrease();
            }

            for (int i = Length - 1; i > index; i--)
            {
                DArray[i] = DArray[i - 1];
            }

            DArray[index] = element;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return DArray.GetEnumerator();
        }
    }

    internal class DynamicArrayEnumerator<T> : IEnumerator<T>
    {
        private int position = -1;
        private readonly DynamicArray<T> DynamicArray;
        public DynamicArrayEnumerator(DynamicArray<T> dynamicArray)
        {
            DynamicArray = dynamicArray;
        }
        public T Current
        {
            get
            {
                if (position == -1 || position > DynamicArray.Length)
                {
                    throw new InvalidOperationException();
                }
                return DynamicArray[position];
            }
        }

        public bool MoveNext()
        {
            if (position < DynamicArray.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        #region
        object IEnumerator.Current { get { return Current; } }
        public void Dispose() { }
        public void Reset()
        {
            position = -1;
        }
        #endregion
    }
}


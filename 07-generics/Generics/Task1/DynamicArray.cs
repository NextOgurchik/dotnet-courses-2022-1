using System;

namespace Task1
{
    internal class DynamicArray<T>
    {
        public int Length { get; private set; }
        public int Capacity => DArray.Length; 
        public T[] DArray { get; set; }
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
        public DynamicArray()
        {
            DArray = new T[8];
        }
        public DynamicArray(int capacity)
        {
            DArray = new T[capacity];
        }
        public DynamicArray(T[] array)
        {
            DArray = array;
        }
        private T[] Copy(T[] array)
        {
            var newArray = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }
        public void Add(T element)
        {
            var oldArray = Copy(DArray);

            Length++;

            if (Length > Capacity)
            {
                DArray = new T[Capacity * 2];
            }

            for (int i = 0; i < oldArray.Length; i++)
            {
                DArray[i] = oldArray[i];
            }

            DArray[Length - 1] = element;
        }

        public void AddRange(T[] array)
        {
            var oldArray = Copy(DArray);
            int capacity = DArray.Length;
            int startLength = Length;
            Length += array.Length;
            if (Length > capacity)
            {
                while (Length > capacity)
                {
                    capacity *= 2;
                }
                DArray = new T[capacity];
            }

            for (int i = 0; i < oldArray.Length; i++)
            {
                DArray[i] = oldArray[i];
            }

            int j = 0;
            for (int i = startLength; i < Length; i++)
            {
                DArray[i] = array[j];
                j++;
            }
        }
        public bool Remove(int index)
        {
            if (index < Length)
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

            var oldArray = Copy(DArray);

            Length++;
            if (Length > Capacity)
            {
                DArray = new T[Capacity * 2];
            }

            for (int i = 0; i < index; i++)
            {
                DArray[i] = oldArray[i];
            }

            DArray[index] = element;

            for (int i = index; i < Length; i++)
            {
                DArray[i + 1] = oldArray[i];
            }
        }
    }
}

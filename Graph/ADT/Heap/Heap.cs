using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Heap
{
    /*When we want T should be extended from a class then no need to write 'class' constraint since the Class name 
    itself indicate that it should be class type not any value or struct type or interface*/
    class MaxHeap<T> where T : class, IComparable
    {
        T []heapData;
        readonly int _capacity;
        private int _size;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public MaxHeap(int n)
        {
            _capacity = n;
            heapData = new T[n];
        }
        public bool Insert(T data)
        {
            if (Size<_capacity)
            {
                heapData[Size] = data;
                _swim(Size++);
                return true;
            }
            return false;
        }
        public T DeleteMax()
        {
            T max;
            max = heapData[0];
            heapData[0] = heapData[--Size];
            heapData[Size] = null;
            _sink(0);
            return max;

        }
        private void _swim(int index)
        {
            while(index>=0)
            {
                if (_less(index, ((index - 1) / 2)))
                    break;
                _exchange(index, ((index - 1) / 2));
                index = (index - 1) / 2;
            }
        }
        private void _sink(int index)
        {
            int i = 2 * index + 1;
            int j = 2 * index + 2;
            while (i<Size)
            {
                if (j < Size && _less(i, j))
                {
                    i++;
                }
                //If the parent element is greater then one of its two children, which is having greater value then heap is in correct order
                if(_less(i,index))
                {
                    break;
                }
                _exchange(index, i);
                index = i;
                i = 2 * index + 1;
                j = 2 * index + 2;
            }
        }
        private void _exchange(int i,int j)
        {
            T temp;
            temp = heapData[i];
            heapData[i] = heapData[j];
            heapData[j] = temp;
        }
        private bool _less(int i,int j)
        {
            if (heapData[i].CompareTo(heapData[j]) < 0)
                return true;
            return false;
        }
    }
}

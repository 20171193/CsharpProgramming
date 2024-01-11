﻿/*******************************************************
 * 리스트 (List)
 * 
 * 런타임 중 크기를 확장할 수 있는 배열기반의 자료구조
 * 배열요소의 갯수를 특정할 수 없는 경우 사용이 용이
 *******************************************************/

// <리스트 구현>
// 리스트는 배열기반의 자료구조이며, 배열은 크기를 변경할 수 없는 자료구조
// 리스트는 동작 중 크기를 확장하기 위해 포함한 데이터보다 더욱 큰 배열을 사용
//
// 크기 = 3, 용량 = 8       크기 = 4, 용량 = 8       크기 = 5, 용량 = 8
// ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
// │1│2│3│ │ │ │ │ │        │1│2│3│4│ │ │ │ │        │1│2│3│4│5│ │ │ │
// └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘


// <리스트 삽입>
// 중간에 데이터를 추가하기 위해 이후 데이터들을 뒤로 밀어내고 삽입 진행
//      ↓                        ↓                        ↓
// ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
// │1│2│3│4│ │ │ │ │   =>   │1│2│ │3│4│ │ │ │   =>   │1│2│A│3│4│ │ │ │
// └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘


// <리스트 삭제>
// 중간에 데이터를 삭제한 뒤 빈자리를 채우기 위해 이후 데이터들을 앞으로 당김
//      ↓                        ↓
// ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
// │1│2│A│3│4│ │ │ │   =>   │1│2│ │3│4│ │ │ │   =>   │1│2│3│4│ │ │ │ │
// └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘


// <리스트 용량>
// 용량을 가득 채운 상황에서 데이터를 추가하는 경우
// 더 큰 용량의 배열을 새로 생성한 뒤 데이터를 복사하여 새로운 배열을 사용
//
// 1. 리스트가 가득찬 상황에서 새로운 데이터 추가 시도
// 크기 = 8, 용량 = 8
// ┌─┬─┬─┬─┬─┬─┬─┬─┐
// │1│2│3│4│5│6│7│8│ ← A 추가
// └─┴─┴─┴─┴─┴─┴─┴─┘
//
// 2. 새로운 더 큰 배열 생성
// 크기 = 8, 용량 = 8          크기 = 0, 용량 = 16
// ┌─┬─┬─┬─┬─┬─┬─┬─┐           ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
// │1│2│3│4│5│6│7│8│ ← A 추가  │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │
// └─┴─┴─┴─┴─┴─┴─┴─┘           └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
//
// 3. 새로운 배열에 기존의 데이터 복사
// 크기 = 8, 용량 = 8          크기 = 8, 용량 = 16
// ┌─┬─┬─┬─┬─┬─┬─┬─┐           ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
// │1│2│3│4│5│6│7│8│ ← A 추가  │1│2│3│4│5│6│7│8│ │ │ │ │ │ │ │ │
// └─┴─┴─┴─┴─┴─┴─┴─┘           └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
//
// 4. 기본 배열 대신 새로운 배열을 사용
// 크기 = 8, 용량 = 16
// ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
// │1│2│3│4│5│6│7│8│ │ │ │ │ │ │ │ │ ← A 추가
// └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
//
// 5. 빈공간에 데이터 추가
// 크기 = 9, 용량 = 16
// ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
// │1│2│3│4│5│6│7│8│A│ │ │ │ │ │ │ │
// └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘


// <리스트 시간복잡도>
// 접근    탐색    삽입    삭제
// O(1)    O(n)    O(n)    O(n)


namespace _01._List
{
    internal class Program
    {
        void Main2()
        {
            List<string> list = new List<string>();

            // 삽입
            list.Add("0번 데이터");
            list.Add("1번 데이터");
            list.Add("2번 데이터");
            list.Insert(1, "중간 데이터1");
            list.Insert(3, "중간 데이터2");


            // 삭제
            list.Remove("1번 데이터");
            list.RemoveAt(1);


            // 접근
            list[0] = "데이터0";
            string value = list[0];


            // 탐색
            int indexOf = list.IndexOf("2번 데이터");
            int findIndex = list.FindIndex(x => x.Contains("중간"));
        }
    }
}

namespace DataStructure
{
    public class List<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;
        private int size;

        public List()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }
        
        public List(int capacity)
        {
            items = new T[capacity];
            size = 0;
        }

        public int Capacity { get {return items.Length;} }
        public int Count { get { return size; } }
        public bool IsFull { get { return items.Length == size; } }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (size >= items.Length)
                Grow();

            items[size++] = item;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || size < index)
                throw new ArgumentOutOfRangeException();

            if (size >= items.Length)
                Grow();

            if (index < size)
                Array.Copy(items, index, items, index + 1, size - index);

            items[index] = item;
            size++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        public void Clear()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }

        public int IndexOf(T item)
        {
            if(item == null)
            {
                for(int i =0; i<size; i++)
                {
                    if (null == items[i])
                        return i;
                }
            }
            else
            {
                for(int i =0; i<size; i++)
                {
                    if (items.Equals(items[i]))
                        return i;
                }
            }

            return -1;
        }

        public int FindIndex(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException();

            for(int i =0; i< size; i++)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }

        private void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, 0, newItems, 0, size);
            items = newItems;
        }

        //public decimal Average<T>(int? left = null, int? right = null) where T : struct
        //{
        //    if ((left < 0 || left >= size) || (right < 0 || right >= size)) 
        //        throw new IndexOutOfRangeException();
        //    if (right <= left)
        //        throw new ArgumentOutOfRangeException();

        //    if (left == null && right == null)
        //    {
                
        //    }
        //    else
        //    {
        //        if (left == null) left = int.MinValue;
        //        if (right == null) right = int.MaxValue;

        //        decimal sum = 0;
        //        for(int i = Math.Max(0,left); i < Math.Min(size, right); i++)
        //        {
        //        }
        //    }
        //}

        //public T MaxValue<T>() where T : struct
        //{

        //}
        //public int MaxValue<T>() where T : struct
        //{

        //}
    }
}
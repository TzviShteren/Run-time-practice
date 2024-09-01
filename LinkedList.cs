using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp0109
{
    interface ListR<T>
    {
        T? Get(int index);
        void Set(int index, T value);
        T? RemoveAt(int index);
        void Push(T item);
        T? Pop();
        void Unshift(T item);
        T? Shift();
        void Reverse();
        ListR<R> Map<R>(Func<T, R> mapper);
        ListR<R> Where<R>(Func<T, bool> func);
        T? FirstOrDefault(Func<T, bool> func);
        bool All(Func<T, bool> func);
        bool Any(Func<T, bool> func);

    }
    internal class Node<T>
    {
        internal T data;
        internal Node<T>? next;
        public Node(T d)
        {
            data = d;
            next = null;
        }
    }
    internal class MyLinkedList<T> : ListR<T>
    {
        private Node<T>? _head;
        private Node<T>? _tail;
        public int Length { get; set; } = 0;

        public void Push(T item)
        {
            Node<T>? newNode = new(item);
            if (Length == 0)
            {
                _head = newNode;
                _tail = newNode;
                Length++;
                return;

            }
            var temp = _tail;
            temp.next = newNode;
            _tail = newNode;
            Length++;
        }
        public T? Pop()
        {
            if (Length == 0) return default;
            if (Length == 1)
            {
                Length = 0;
                T value = _head.data;
                _head = _tail = null;
                return value;
            }
            var temp = _head;
            var pre = _head;
            while (temp.next != null)
            {
                pre = temp;
                temp = temp.next;
            }
            pre.next = null;
            _tail = pre;
            Length--;
            return temp.data;

        }

        public T? Shift()
        {
            if (Length == 0) return default;
            T item = _head.data;
            if (Length == 1) 
            { 
                _tail = null;
                _head = null;
                Length--;
                return item;
            }
            _head = _head.next;
            Length--;
            return item;
        }

        public void Unshift(T item)
        {
            Node<T>? newNode = new(item);
            if (Length == 0)
            {
                _head = newNode;
                _tail = newNode;
                Length++;
                return;
            }
            var temp = _head;
            _head = newNode;
            _head.next = temp;
        }
        public override string ToString()
        {
            if (Length == 0) return "[]";
            string repr = "[";
            Node<T>? tamp = _head;
            repr += $"{tamp.data}";
            while (tamp.next != null)
            {
                tamp = tamp.next;
                repr += $", {tamp.data}";
            }
            return $"{repr}]";
        }
        public void Reverse()
        {
            if (Length <= 1) { return; }
            var temp = _head!;
            _head = _tail;
            _tail = temp;
            var next = temp.next;
            Node<T>? prev = null;
            for (int i = 0; i < Length; i++)
            {
                next = temp!.next;
                temp.next = prev;
                prev = temp;
                temp = next;
            }
            _tail.next = null;
        }

        public T? Get(int index)
        {
            if (index >= Length)
                return default;

            Node<T>? tamp = _head;
            for (int i = 0; i < index; i++)
            {
                tamp = tamp?.next;
            }
            return tamp!.data;
        }

        public void Set(int index, T value)
        {
            if (index >= Length)
                return;

            Node<T>? tamp = _head;
            for (int i = 0; i < index; i++)
            {
                tamp = tamp?.next;
            }
            tamp!.data = value;
        }

        public T? RemoveAt(int index)
        {
            if (index >= Length) return default;
            if (Length == 0) return default;
            if (Length == 1)
            {
                Length = 0;
                T value = _head!.data;
                _head = _tail = null;
                return value;
            }
            var tamp = _head;
            for (int i = 0; i < index; i++)
            {
                tamp = tamp!.next;
            }

            tamp.next = tamp.next.next ;
            tamp = null;
            Length--;
            return tamp!.data;
        }
        public T? FirstOrDefault(Func<T, bool> func)
        {
            throw new NotImplementedException();
        }
        public ListR<R> Map<R>(Func<T, R> mapper)
        {
            MyLinkedList<R> list = new();
            var tamp = _head;
            while (tamp != null) 
            {
                list.Push(mapper(tamp.data));
                tamp = tamp.next;
            }
            return list;
        }
        public bool All(Func<T, bool> func)
        {
            var tamp = _head;
            int numOfTrue = 0;
            while (tamp!.next != null)
            {
                if (func(tamp.data)) numOfTrue++;
                tamp = tamp.next;
            }
            return numOfTrue == Length - 1;
        }

        public bool Any(Func<T, bool> func)
        {
            var tamp = _head;
            while (tamp!.next != null)
            {
                if (func(tamp.data)) return true;
                tamp = tamp.next;
            }
            return false;
        }

        public ListR<R> Where<R>(Func<T, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}

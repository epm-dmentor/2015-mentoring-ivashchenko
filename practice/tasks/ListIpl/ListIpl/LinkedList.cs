using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ListIpl
{
    public class Node<T>
    {
        private T _element;
        private Node<T> _next;

        public Node(T element)
        {
            this._element = element;
        }

        public T Value
        {
            get { return _element; }
            set { _element = value; }
        }

        public Node<T> Next
        {
            get { return this._next; }
            set { this._next = value; }
        }
    }

    public class LinkedList<T>
    {
        private Node<T> _first;
        private Node<T> _current;
        private Node<T> _last;
        private uint _size;        

        public LinkedList()
        {
            _size = 0;
            _first = _last = _current = null;
        }

        public bool isEmpty //проверка на пустоту
        {
            get
            {
                return _size == 0;
            }
        }

        public void AddHead(T newElem)
        {
            Node<T> newNode = new Node<T>(newElem);

            if (_first == null)
            {
                _first = _last = newNode;
            }
            else
            {
                newNode.Next = _first;
                _first = newNode; 
            }
            _size++;
        }

        public void AddTail(T newElem)
        {
            Node<T> newNode = new Node<T>(newElem);

            if (_first == null)
                _first = _last = _current = newNode;
            else
            {
                _last.Next = newNode;
                _last = newNode;
            }
            _size++;
        }

        public void InsertAt(uint idx, T newElem)
        {
            if(idx > _size)
                throw new ArgumentException("Out of index");

            if(idx == 0)
                AddHead(newElem);
            else if(idx == _size  && _size > 2)
                AddTail(newElem);
            else
            {
                uint cc = 0;
                _current = _first;
                Node<T> newNode = new Node<T>(newElem);

                for (uint i = 0; i < idx-1; i++)
                {
                    _current = _current.Next;
                }

                newNode.Next = _current.Next;
                _current.Next = newNode;
                _size++;
            }
        }

        public void RemoveTail()
        {
            if(isEmpty)
                return;

            if (_size == 1)
            {
                _first = _last = _current = null;
                _size = 0;
                return;
            }
            _current = _first;

            uint cc = 0;
            while (cc != _size - 2)
            {
                _current = _current.Next;
                cc++;
            }
            _current.Next = null;
            _last = _current;
            --_size;
        }

        public void RemoveHead()
        {
            if (isEmpty)
                return;

            _first = _first.Next;
            _size--;

        }

        public void Print()
        {
            _current = _first;
            uint cc = 0;
            while ( cc < _size)
            {
                Console.WriteLine(_current.Value);
                _current = _current.Next;
                ++cc;
            }
        }
    }
}

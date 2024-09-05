using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery_Queue
{
    public class MyQueue
    {
        public int number;
        public CellType rear;
        public CellType front;
        public int size = 0, users = 0;
        public MyQueue next;

        public MyQueue(int number)
        {
            this.number = number;
        }

        public bool isEmpty()
        {

            if (size == 0)
            {
                return true;
            }

            return false;

        }

        public void add(MyQueue myQueue, int i, int number)
        {

            MyQueue newQueue = this;
            while (newQueue.next != null)
            {
                newQueue = newQueue.next;
            }

            if (i == number)
            {
                myQueue.next = this;
            }

            newQueue.next = myQueue;

        }

        public void enQueue(int count)
        {

            if (isEmpty())
            {

                rear = new CellType((number * 1000) + (users + 1));
                front = rear;

            }
            else
            {

                CellType cellType = new CellType((number * 1000) + (users + 1));
                rear.next = cellType;
                rear = cellType;

            }

            size++;
            users++;

        }

        public CellType deQueue()
        {

            CellType cellType = null;

            if (!isEmpty())
            {

                cellType = front;

                if (size != 1)
                {
                    front = front.next;
                }
                else
                {
                    rear = null;
                    front = null;
                }

            }

            size--;

            return cellType;

        }
        public MyQueue createQueue(int number)//اینجا گیر داده نمیدونم چرا؟
        {

            MyQueue myQueue = new MyQueue(1);


            for (int i = 2; i <= number; i++)
            {

                myQueue.add(new MyQueue(i), i, number);

            }

            return myQueue;

        }
    }
}

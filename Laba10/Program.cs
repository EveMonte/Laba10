using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Laba10
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionOfFigures fig = new CollectionOfFigures();
            /*fig.Add();
            fig.Add();
            fig.Add();
            fig.Add();
            fig.Output();
            fig.Remove("Square");
            fig.Output();
            fig.Search("Triangle");
            fig.Search("Square");*/
            Stack<int> stk = new Stack<int>();
            stk.Push(1);
            stk.Push(2);
            stk.Push(3);
            stk.Push(4);
            stk.Push(5);
            Array myArr = new Array[stk.Count];
            myArr = stk.ToArray();
            foreach (int elem in myArr)
            {
                Console.WriteLine($"Name of the figure: { elem }");
            }
            Console.WriteLine("Enter n:");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < stk.Count)
            {
                for (int i = 0; i < stk.Count; i++)
                {
                    stk.Pop();
                }
                Console.WriteLine("Elements deleted");
            }
            else Console.WriteLine("Wrong number!");
            stk.Push(11);
            stk.Push(12);
            stk.Push(13);
            stk.Push(14);
            stk.Push(15);
            Array myArr2 = new Array[stk.Count];
            myArr2 = stk.ToArray();
            foreach (var elem in myArr2)
            {
                Console.WriteLine($"Element of stack: { elem }");
            }
            List<int> list = new List<int>();
            Console.WriteLine("--------List:--------");
            foreach (int elem in myArr2)
            {
                list.Add(elem);
            }
            foreach(int i in list)
            {
                Console.WriteLine($"Element of list: { i }");

            }
            Console.WriteLine("Enter m:");
            int m = Convert.ToInt32(Console.ReadLine());
            foreach (int i in list)
            {
                if(i == m)
                    Console.WriteLine($"Your element was founded: { i }");
            }

            Figure f = new Figure();
            ObservableCollection<Figure> observList = new ObservableCollection<Figure>();

            observList.CollectionChanged += Changes;
            observList.Add(f);
            observList.RemoveAt(0);
        }

        private static void Changes(object sender, NotifyCollectionChangedEventArgs e)   // объект NotifyCollectionChangedEventArgs e.
                                                                                         //Его свойство Action позволяет узнать характер изменений. 
                                                                                         //Оно хранит одно из значений из перечисления NotifyCollectionChangedAction.
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Figure newFig = e.NewItems[0] as Figure;
                    Console.WriteLine($"Добавлен новый объект: {newFig.Name}");
                    break;                                          //Свойства NewItems и OldItems позволяют получить соответственно добавленные и удаленные объекты.
                                                                    //Таким образом, мы получаем полный контроль над обработкой добавления,
                                                                    //удаления и замены объектов в коллекции.

                case NotifyCollectionChangedAction.Remove: // если удаление
                    Figure oldUser = e.OldItems[0] as Figure;
                    Console.WriteLine($"Удален объект: {oldUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    Figure replacedUser = e.OldItems[0] as Figure;
                    Figure replacingUser = e.NewItems[0] as Figure;
                    Console.WriteLine($"Объект {replacedUser.Name} заменен объектом {replacingUser.Name}");
                    break;
            }

        }
    }
}

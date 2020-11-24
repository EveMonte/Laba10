using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba10
{
    public class Figure
    {
        public string Name { get; set; }
        public int Square { get; set; }
        public int Perimetr { get; set; }
    }
    class CollectionOfFigures : IEnumerator
    {
        
        public Stack<Figure> figures = new Stack<Figure>();
        //private int LengthOfFigures;
        private int CurrentIndex = 0;
        
        private Figure CurrentFigure;
        //public string this[int index]
        //{
        //    get
        //    {
        //        return figures[index].Name;
        //    }
        //    set
        //    {
        //        figures[index].Name = value;
        //    }
        //}
        public Figure Current 
        { get
            {
                if (CurrentIndex == -1 || CurrentIndex >= figures.Count)
                    throw new InvalidOperationException();
                return figures.Peek();
            } 
        }

        public bool MoveNext()
        {
            if(CurrentIndex < figures.Count - 1)
            {
                CurrentIndex++;
                return true;
            }

            return false;
        }
        public void Reset()
        {
            CurrentIndex = 0;
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        

        public void Add()
        {
            Figure f = new Figure();
            Console.WriteLine("Enter name of your figure:");
            f.Name = Console.ReadLine();
            Console.WriteLine("Enter square of your figure:");
            f.Square = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter perimetr of your figure:");
            f.Perimetr = Convert.ToInt32(Console.ReadLine());
            figures.Push(f);
        }

        public void Output()
        {
            Array myArr = new Array[figures.Count];
            myArr = figures.ToArray();
            foreach(Figure elem in myArr)
            {
                Console.WriteLine($"Name of the figure: { elem.Name}");
            }
            
        }
        public void Remove(string Name)
        {
            Stack<Figure> newFigures = new Stack<Figure>();
            Array myArr = new Array[figures.Count];
            myArr = figures.ToArray();
            Array.Reverse(myArr);
            foreach(Figure f in myArr)
            {
                if(f.Name != Name)
                {
                    newFigures.Push(f);
                }
            }
            figures = newFigures;
        }

        public void Search(string Name)
        {
            Array myArr = new Array[figures.Count];
            myArr = figures.ToArray();
            foreach (Figure f in myArr)
            {
                if (f.Name == Name)
                {
                    Console.WriteLine("Your element was founded");
                    Console.WriteLine($"Name of figure: {f.Name}    Square of figure: {f.Square}    Perimetr of figure: {f.Perimetr}");
                    return;
                }
            }
            Console.WriteLine("Element wasn't founded! Please try again!");
        }
    }

}

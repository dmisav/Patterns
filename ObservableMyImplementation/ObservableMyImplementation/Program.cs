using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableMyImplementation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<IObservable> observables = new List<IObservable>();
            var observable1 = new Observable1();
            var observable2 = new Observable2();
            observables.Add(observable1);
            observables.Add(observable2);

            using (var observer = new Observer(observables))
            {
                observable1.DoSomething("call");
                observable2.DoSomething("call");
                observable1.DoSomething("call");
                observable1.DoSomething("call");
                observable2.DoSomething("call");
            }
            Console.ReadLine();
        }

        public delegate void SomeDelegate(string Message);

        public class Observer : IDisposable
        {
            private List<IObservable> observables;

            public Observer(List<IObservable> observables)
            {
                this.observables = observables;
                foreach (IObservable item in observables)
                {
                    this.AddObservable(item);
                }
            }

            private void AddObservable(IObservable observable)
            {
                observable.someDelegate += ReactOndoSomething;
            }

            private void RemoveObservable(IObservable observable)
            {
                observable.someDelegate -= ReactOndoSomething;
                observables.Remove(observable);
            }

            private void ReactOndoSomething(string message)
            {
                Console.WriteLine("React on do something {0}", message);
            }

            public void Dispose()
            {
                for (int i = observables.Count; i > 0; i--)
                {
                    this.RemoveObservable(observables[i - 1]);
                }
            }
        }

        public interface IObservable
        {
            event SomeDelegate someDelegate;
            void DoSomething(string message);
        }

        public class Observable1 : IObservable
        {
            public event SomeDelegate someDelegate;
            public void DoSomething(string message)
            {
                someDelegate("Observable1: " + message);
            }
        }

        public class Observable2 : IObservable
        {
            public event SomeDelegate someDelegate;

            public void DoSomething(string message)
            {
                someDelegate("Observable2: " + message);
            }
        }
    }
}

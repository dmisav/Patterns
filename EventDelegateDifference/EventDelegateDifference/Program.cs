using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateDifference
{
  delegate void someEventDelegate();

class EventTester
{
    public event someEventDelegate someEvent; ///!!!!  if we add 'event' modifier - then we are safe from accidentally 
    ///assigning null to delegate variable and loosing all signed methods to this delegate ' evt.someEvent = null;' It won't compile
    ///If remove 'event' then we just use delegate and are allowed to do ' evt.someEvent = null;' which is not safe

    public void doEvent()
    {
        if (someEvent != null) someEvent();
    }

}

class Program
{
    static void EventHandler1()
    {
        Console.WriteLine("Event handler 1 called..");
    }

    static void EventHandler2()
    {
        Console.WriteLine("Event handler 2 called..");
    }
    static void EventHandler3()
    {
        Console.WriteLine("Event handler 3 called..");
    }


    static void Main(string[] args)
    {
        EventTester evt = new EventTester();
        evt.someEvent += EventHandler1;
        evt.someEvent += EventHandler2;
        evt.someEvent += EventHandler3;
     //   evt.someEvent = null;  // removing all signers. Impossible when use event. Possible when use delegate
        evt.doEvent();
        Console.ReadKey();

    }
}
}

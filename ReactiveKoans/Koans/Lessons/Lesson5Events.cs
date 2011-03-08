using System;
using System.Collections.Generic;
using System.Concurrency;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson5Events
    {
        public event EventHandler<TextChangedEventArgs> TextChanged;

        [TestMethod]
        public void TheMainEvent()
        {
            var received = new StringBuilder();
            IObservable<IEvent<TextChangedEventArgs>> textChanges = Observable.FromEvent<TextChangedEventArgs>(this,
                                                                                                               "TextChanged");
            using (textChanges.Subscribe(e => received.Append(e.EventArgs.value)))
            {
                TextChanged(null, new TextChangedEventArgs {value = "B"});
                TextChanged(null, new TextChangedEventArgs {value = "A"});
                TextChanged(null, new TextChangedEventArgs {value = "R"});
            }
            TextChanged(null, new TextChangedEventArgs {value = "T"});
            Assert.AreEqual(___, received.ToString());
        }

        [TestMethod]
        public void Linq()
        {
            var numbers = Observable.Range(1, 100);
            var results = from x in numbers
                          where x%11 == 0
                          select x.ToString();
            var strings = results.ToEnumerable();
            Assert.AreEqual("11,22,33,44,55,66,77,88,99", String.Join(",",strings));
        }


        #region Ignore

        public const int ____ = 1000;
        public object ___ = "Please Fill in the blank";

        public Lesson5Events()
        {
            TextChanged += (o, e) => { };
        }

        #endregion

        /*
         *obseverable from event multisubscriped
         *
         */
    }

    public class TextChangedEventArgs : EventArgs
    {
        public string value;
    }
}
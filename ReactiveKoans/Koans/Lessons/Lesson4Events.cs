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
    public class Lesson4Events
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
        // [Timeout(2000)]
        public void TheBloodyHardAsyncInvokationPatter()
        {
            // You need to fill in the 3 ___'s with A,B & C in the order they will execute
            String called = "";
            var sub = new Subject<double>();
            Func<int, double> inc = x =>
                                        {
                                            called += ___;
                                            return x + 1.5;
                                        };
            double? result = 0;
            sub.Subscribe(n =>
                              {
                                  called += ___;
                                  result = n;
                              });
            inc.BeginInvoke(1, iar =>
                                   {
                                       called += ___;
                                       sub.OnNext(inc.EndInvoke(iar));
                                       sub.OnCompleted();
                                   }, null);
            WaitUntil(() => result != 0);
            Assert.AreEqual(2.5, result);
            Assert.AreEqual("ABC", called);
        }

        [TestMethod]
        // [Timeout(2000)]
        public void NiceAndEasyFromAsyncPattern()
        {
            Func<int, double> inc = x => x + 1.5;
            double result = 0;
            Func<int, IObservable<double>> incAsync = Observable.FromAsyncPattern<int, double>(inc.BeginInvoke,
                                                                                               inc.EndInvoke);
            incAsync(1).Run(n => result = n);
            Assert.AreEqual(2.5, result);
        }

        [TestMethod]
        [Timeout(____)]
        public void AsyncLongRunning()
        {
            Func<int, double> inc = x =>
            {
                Thread.Sleep(1500);
                return x + 1.5;
            };
            double result = 0;
            Func<int, IObservable<double>> incAsync = Observable.FromAsyncPattern<int, double>(inc.BeginInvoke,
                                                                                               inc.EndInvoke);
            incAsync(1).Merge(incAsync(1)).Sum().Run(n => result = n);
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void AsyncLongRunningTimeout()
        {
            Func<int, string> highFive = x =>
            {
                Thread.Sleep(1500);
                return "Give me " + x;
            };
            string result = null;
            var incAsync = highFive.ToAsync();
            var timeout = TimeSpan.FromMilliseconds(500);
            incAsync(5).Timeout(timeout,Observable.Return("Too Slow Joe")).Run(n => result = n);
            Assert.AreEqual(___, result);
        }

        
        [TestMethod]
        public void AsyncLongRunningTimeout2()
        {
            Func<int, string> highFive = x =>
                                             {
                                                 Thread.Sleep(x*100);
                                                 return "" + x;
                                             };
            string disposed = null;
            Func<int, IObservable<string>> incAsync = highFive.ToAsync();
            TimeSpan timeout = TimeSpan.FromMilliseconds(500);
            Func<int, IObservable<string>> launch = (int i) => incAsync(i).Finally(() => disposed += "D" + i+",") ;
            var all = launch(1).Merge(launch(2)).Merge(launch(3)).Merge(launch(4)).Merge(launch(5));
            all.Run();
            
            Assert.AreEqual("D1,D2,D3,D4,D5,", disposed);
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


        private void WaitUntil(Func<bool> func)
        {
            while (!func())
            {
                Thread.Sleep(100);
            }
        }

        #region Ignore

        public const int ____ = 1000;
        public object ___ = "Please Fill in the blank";

        public Lesson4Events()
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
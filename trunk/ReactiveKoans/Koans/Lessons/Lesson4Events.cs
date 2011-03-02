using System;
using System.Collections.Generic;
using System.Linq;
using Koans.Utils;
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
            var received = new List<String>();
            var textChanges = Observable.FromEvent<TextChangedEventArgs>(this, "TextChanged");
            using (textChanges.Subscribe(e => received.Add(e.EventArgs.value)))
            {
                TextChanged(null, new TextChangedEventArgs { value = "B" });
                TextChanged(null, new TextChangedEventArgs { value = "A" });
                TextChanged(null, new TextChangedEventArgs { value = "R" });
            }
            TextChanged(null, new TextChangedEventArgs { value = "T" });
            Assert.AreEqual(___, received.AsString());
        }

        #region Ignore

        public object ___ = "Please Fill in the blank";
      
        public Lesson4Events()
        {
            TextChanged += (o,e) => { };
        }
        #endregion
    }

    public class TextChangedEventArgs : EventArgs
    {
        public string value;
    }
}
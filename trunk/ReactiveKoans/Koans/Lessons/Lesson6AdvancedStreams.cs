﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Lessons
{
	[TestClass]
	public class Lesson6AdvancedStreams
	{
		[TestMethod]
		public void Merging()
		{
			var easy = new StringBuilder();
			var you = new object[] {1, 2, 3}.ToObservable();
			var me = new object[] {"A", "B", "C"}.ToObservable();
			you.Merge(me).Subscribe(a => easy.Append(a + " "));
			Assert.AreEqual(easy.ToString(), ___);
		}


		[TestMethod]
		public void SplittingUp()
		{
			var oddsAndEvens = new[] {"", ""};
			var numbers = Observable.Range(1, 9);
			var split = numbers.GroupBy(n => n%____);
			split.Subscribe(group => group.Subscribe(n => oddsAndEvens[group.Key] += n));
			var evens = oddsAndEvens[0];
			var odds = oddsAndEvens[1];
			Assert.AreEqual("2468", evens);
			Assert.AreEqual("13579", odds);
		}

		[TestMethod]
		public void NeedToSubscribeImediatelyWhenSplitting()
		{
			var averages = new[] {0.0, 0.0};
			var numbers = new[] {22, 22, 99, 22, 101, 22}.ToObservable();
			var split = numbers.GroupBy(n => n%2);
			split.Subscribe(g => g.Average().____(a => averages[g.Key] = a));
			Assert.AreEqual(22, averages[0]);
			Assert.AreEqual(100, averages[1]);
		}

		[TestMethod]
		public void MultipleSubscriptions()
		{
			var numbers = new Subject<int>();
			double sum = 0;
			double average = 0;
			numbers.Sum().Subscribe(n => sum = n);
			numbers.OnNext(1, 1, 1, 1, 1);
			numbers.Average().Subscribe(n => average = n);
			numbers.OnNext(2, 2, 2, 2, 2);
			numbers.OnCompleted();
			Assert.AreEqual(15, sum);
			Assert.AreEqual(average, ___);
		}

		#region Ignore

		public object ___ = "Please Fill in the blank";
		public int ____ = 1;

		#endregion

		/*
				 * async,
				 * behavor
				 * replay
				 */
	}
}
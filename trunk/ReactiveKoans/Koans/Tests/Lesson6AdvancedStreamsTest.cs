using System;
using Koans.Lessons;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Tests
{
	[TestClass]
	public class Lesson6AdvancedStreamsTest
	{
		[TestMethod]
		public void TestAllQuestions()
		{
			Verify(l => l.Merging(), "1 A 2 B 3 C ");
			Verify(l => l.SplittingUp(), 2);
			KoanUtils.AssertLesson<Lesson6AdvancedStreams>(l => l.NeedToSubscribeImediatelyWhenSplitting(), l => StringUtils.call = (s,p) => ObservableExtensions.Subscribe((IObservable<double>)s, (Action<double>) p[0]));
			Verify(l => l.MultipleSubscriptions(), 2.0);
		}


		public void Verify(Action<Lesson6AdvancedStreams> test, object answer)
		{
			KoanUtils.AssertLesson(test, l=> FillAll(l,answer));
		}

		private void FillAll(Lesson6AdvancedStreams l, object answer)
		{
			l.___ = answer;
			if (answer is int)
			{
				l.____ = (int) answer;
			}
		}
	}
}
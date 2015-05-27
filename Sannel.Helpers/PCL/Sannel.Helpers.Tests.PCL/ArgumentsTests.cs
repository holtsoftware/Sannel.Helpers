/*
Copyright 2015 Sannel Software, L.L.C.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
#if NET_4_5 || NET_4_5_1
using System.Threading.Tasks;
#endif
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sannel.Helpers.Tests
{
	[TestClass]
	public class ArgumentsTests
	{
		[TestMethod]
		[TestCategory("Arguments")]
		public void ParseTest()
		{
			Arguments arguments = new Arguments();
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { arguments.Parse(null); });
			String[] args = new String[]
			{
				"file arg 1",
				"--test",
				"--testValue=value1",
				"--test-value=\"value 2\"",
				"/?",
				"--help",
				"-d",
				"-5=cheese",
				"../Test/"
			};

			arguments.Parse(args);
			Assert.IsTrue(arguments.HasArgument("test"), "argument test was not detected");
			Assert.IsTrue(arguments.HasArgument("testvalue"), "argument testvalue was not detected");
			Assert.IsTrue(arguments.HasArgument("test-value"), "argument test-value was not detected");
			Assert.IsTrue(arguments.HasArgument("?"), "argument ? was not detected");
			Assert.IsTrue(arguments.HasArgument("help"), "argument help was not detected");
			Assert.IsTrue(arguments.HasArgument("d"), "argument d was not detected");
			Assert.IsTrue(arguments.HasArgument("5"), "argument 5 was not detected");
			Assert.IsFalse(arguments.HasArgument("testdir"), "argument testdir was detected and should not have been.");
			Assert.IsNull(arguments.ArgumentValue("test"), "argument test should not have a value");
			Assert.AreEqual("value1", arguments.ArgumentValue("testvalue"), "testvalue was not the correct value");
			Assert.AreEqual("value 2", arguments.ArgumentValue("test-value"), "test-value was not the correct value");
			Assert.IsNull(arguments.ArgumentValue("?"), "argument ? should not have a value");
			Assert.IsNull(arguments.ArgumentValue("help"), "argument help should not have a value");
			Assert.IsNull(arguments.ArgumentValue("d"), "argument d should not have a value");
			Assert.AreEqual("cheese", arguments.ArgumentValue("5"), "argument 5 value is not what we expected");
			var list = arguments.NonArgumentValues;
			Assert.IsNotNull(list, "list is null and should not be");
			Assert.AreEqual(2, list.Count, "list count does not match");

			Assert.AreEqual("file arg 1", list[0]);
			Assert.AreEqual("../Test/", list[1]);

			var argNameValues = arguments.ArgumentValues;
			Assert.IsNotNull(argNameValues, "argNameValues is null and should not be.");
			Assert.AreEqual(7, argNameValues.Count, "argNameValues.Keys.Count");
			var enumerator = argNameValues.Keys.GetEnumerator();
			Assert.IsTrue(enumerator.MoveNext(), "unable to move next");
			Assert.AreEqual("test", enumerator.Current);
			Assert.IsTrue(enumerator.MoveNext(), "unable to move next");
			Assert.AreEqual("testvalue", enumerator.Current);
			Assert.AreEqual("value1", argNameValues[enumerator.Current]);
			Assert.IsTrue(enumerator.MoveNext(), "unable to move next");
			Assert.AreEqual("test-value", enumerator.Current);
			Assert.AreEqual("value 2", argNameValues[enumerator.Current]);
			Assert.IsTrue(enumerator.MoveNext(), "unable to move next");
			Assert.AreEqual("?", enumerator.Current);
			Assert.IsTrue(enumerator.MoveNext(), "unable to move next");
			Assert.AreEqual("help", enumerator.Current);
			Assert.IsTrue(enumerator.MoveNext(), "unable to move next");
			Assert.AreEqual("d", enumerator.Current);
			Assert.IsTrue(enumerator.MoveNext(), "unable to move next");
			Assert.AreEqual("5", enumerator.Current);
			Assert.AreEqual("cheese", argNameValues[enumerator.Current]);
			Assert.IsFalse(enumerator.MoveNext(), "was able to move next and should not have been able to");

		}

		[TestMethod]
		[TestCategory("Arguments")]
		public void ConstructorTest()
		{
			String[] args = new String[]
			{
				"file arg 1",
				"--test",
				"--testValue=value1",
				"--test-value=\"value 2\"",
				"/?",
				"--help",
				"-d",
				"-5=cheese",
				"../Test/"
			};

			Arguments arguments = new Arguments(args);

			Assert.IsTrue(arguments.HasArgument("test"), "argument test was not detected");
			Assert.IsTrue(arguments.HasArgument("testvalue"), "argument testvalue was not detected");
			Assert.IsTrue(arguments.HasArgument("test-value"), "argument test-value was not detected");
			Assert.IsTrue(arguments.HasArgument("?"), "argument ? was not detected");
			Assert.IsTrue(arguments.HasArgument("help"), "argument help was not detected");
			Assert.IsTrue(arguments.HasArgument("d"), "argument d was not detected");
			Assert.IsTrue(arguments.HasArgument("5"), "argument 5 was not detected");
			Assert.IsFalse(arguments.HasArgument("testdir"), "argument testdir was detected and should not have been.");
			Assert.IsNull(arguments.ArgumentValue("test"), "argument test should not have a value");
			Assert.AreEqual("value1", arguments.ArgumentValue("testvalue"), "testvalue was not the correct value");
			Assert.AreEqual("value 2", arguments.ArgumentValue("test-value"), "test-value was not the correct value");
			Assert.IsNull(arguments.ArgumentValue("?"), "argument ? should not have a value");
			Assert.IsNull(arguments.ArgumentValue("help"), "argument help should not have a value");
			Assert.IsNull(arguments.ArgumentValue("d"), "argument d should not have a value");
			Assert.AreEqual("cheese", arguments.ArgumentValue("5"), "argument 5 value is not what we expected");
			var list = arguments.NonArgumentValues;
			Assert.IsNotNull(list, "list is null and should not be");
			Assert.AreEqual(2, list.Count, "list count does not match");

			Assert.AreEqual("file arg 1", list[0]);
			Assert.AreEqual("../Test/", list[1]);
		}

#if NET_4_5 || NET_4_5_1 || PORTABLE
		[TestMethod]
		[TestCategory("Arguments")]
		public async Task ParseAsyncTest()
		{
			Arguments arguments = new Arguments();
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { arguments.Parse(null); });
			String[] args = new String[]
			{
				"file arg 1",
				"--test",
				"--testValue=value1",
				"--test-value=\"value 2\"",
				"/?",
				"--help",
				"-d",
				"-5=cheese",
				"../Test/"
			};

			await arguments.ParseAsync(args);
			Assert.IsTrue(arguments.HasArgument("test"), "argument test was not detected");
			Assert.IsTrue(arguments.HasArgument("testvalue"), "argument testvalue was not detected");
			Assert.IsTrue(arguments.HasArgument("test-value"), "argument test-value was not detected");
			Assert.IsTrue(arguments.HasArgument("?"), "argument ? was not detected");
			Assert.IsTrue(arguments.HasArgument("help"), "argument help was not detected");
			Assert.IsTrue(arguments.HasArgument("d"), "argument d was not detected");
			Assert.IsTrue(arguments.HasArgument("5"), "argument 5 was not detected");
			Assert.IsFalse(arguments.HasArgument("testdir"), "argument testdir was detected and should not have been.");
			Assert.IsNull(arguments.ArgumentValue("test"), "argument test should not have a value");
			Assert.AreEqual("value1", arguments.ArgumentValue("testvalue"), "testvalue was not the correct value");
			Assert.AreEqual("value 2", arguments.ArgumentValue("test-value"), "test-value was not the correct value");
			Assert.IsNull(arguments.ArgumentValue("?"), "argument ? should not have a value");
			Assert.IsNull(arguments.ArgumentValue("help"), "argument help should not have a value");
			Assert.IsNull(arguments.ArgumentValue("d"), "argument d should not have a value");
			Assert.AreEqual("cheese", arguments.ArgumentValue("5"), "argument 5 value is not what we expected");
			var list = arguments.NonArgumentValues;
			Assert.IsNotNull(list, "list is null and should not be");
			Assert.AreEqual(2, list.Count, "list count does not match");

			Assert.AreEqual("file arg 1", list[0]);
			Assert.AreEqual("../Test/", list[1]);
		}
#endif
	}
}

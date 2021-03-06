#region (c)2009 Lokad - New BSD license

// Copyright (c) Lokad 2009 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

using System;
using Lokad.Testing;
using NUnit.Framework;

namespace Lokad.Rules
{
	[TestFixture]
	public sealed class EnforceArgumentScopeTests
	{
		[Test, Expects.ArgumentException]
		public void Test()
		{
			try
			{
				using (var scope = Scope.ForEnforceArgument("Test", Scope.WhenError))
				{
					ScopeTestHelper.FireErrors(scope);
				}
			}
			catch (ArgumentException ex)
			{
				ScopeTestHelper.ShouldBeClean(ex);
				ScopeTestHelper.ShouldHave(ex, "ErrA");
				ScopeTestHelper.ShouldNotHave(ex, "ErrB", "ErrC");
				throw;
			}
		}

		[Test]
		[ExpectedException(typeof (ArgumentException))]
		public void Test2()
		{
			try
			{
				var arg = 0;
				Enforce.Argument(() => arg, ScopeTestHelper.RunNesting);
			}
			catch (ArgumentException ex)
			{
				ScopeTestHelper.ShouldBeClean(ex);
				ScopeTestHelper.ShouldHave(ex, "Error1", "Group1", "Group2");
				throw;
			}
		}
	}
}
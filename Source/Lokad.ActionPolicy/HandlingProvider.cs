#region (c)2009 Lokad - New BSD license

// Copyright (c) Lokad 2009 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

using System;
using System.Globalization;
using Lokad.Quality;

namespace Lokad
{
	/// <summary>
	/// Simple reliability layer for the <see cref="IProvider{TKey,TValue}"/>
	/// </summary>
	/// <typeparam name="TKey">type of the Key item</typeparam>
	/// <typeparam name="TValue">type of the values</typeparam>
	[Serializable]
	[Immutable]
	public sealed class HandlingProvider<TKey, TValue> : IProvider<TKey, TValue>
	{
		readonly IProvider<TKey, TValue> _provider;
		readonly ActionPolicy _policy;

		/// <summary>
		/// Creates generic reliability wrapper around the <see cref="IProvider{TKey,TValue}"/>
		/// </summary>
		/// <param name="provider"></param>
		/// <param name="policy"></param>
		public HandlingProvider(IProvider<TKey, TValue> provider, ActionPolicy policy)
		{
			_provider = provider;
			_policy = policy;
		}

		/// <summary>
		/// <see cref="IProvider{TKey,TValue}.Get"/>
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public TValue Get(TKey key)
		{
			try
			{
				return _policy.Get(() => _provider.Get(key));
			}
			catch (Exception ex)
			{
			    Type valueType = typeof (TValue);
			    throw new ResolutionException(string.Format(CultureInfo.InvariantCulture, "Error while resolving {0} with key '{1}'", valueType, (object) key), ex);
			}
		}
	}

	/// <summary>
	/// This shortcuts simplifies creation of <see cref="HandlingProvider"/> instances
	/// </summary>
	public static class HandlingProvider
	{
		/// <summary>
		/// Creates new instance of <see cref="HandlingProvider{TKey,TValue}"/>
		/// by wrapping another <see cref="IProvider{TKey,TValue}"/> instance
		/// </summary>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="provider">The provider to wrap.</param>
		/// <param name="policy">The action policy.</param>
		/// <returns>new provider instance</returns>
		public static IProvider<TKey, TValue> For<TKey, TValue>(IProvider<TKey, TValue> provider, ActionPolicy policy)
		{
			return new HandlingProvider<TKey, TValue>(provider, policy);
		}
	}
}
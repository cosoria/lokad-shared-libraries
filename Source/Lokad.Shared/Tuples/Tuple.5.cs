#region (c)2009 Lokad - New BSD license

// Copyright (c) Lokad 2009 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

using System;
using System.Diagnostics;
using Lokad.Quality;

namespace Lokad
{
	/// <summary>
	/// Tuple class with 5 items (also called <em>Quintuple</em>)
	/// </summary>
	/// <typeparam name="T1">The type of the first item.</typeparam>
	/// <typeparam name="T2">The type of the second item.</typeparam>
	/// <typeparam name="T3">The type of the third item.</typeparam>
	/// <typeparam name="T4">The type of the fourth item.</typeparam>
	/// <typeparam name="T5">The type of the fifth item.</typeparam>
	[Serializable]
	[DebuggerDisplay("({Item1},{Item2},{Item3},{Item4},{Item5})")]
	[Immutable]
	public sealed class Tuple<T1, T2, T3, T4, T5> : IEquatable<Tuple<T1, T2, T3, T4, T5>>
	{
		readonly T1 _item1;
		readonly T2 _item2;
		readonly T3 _item3;
		readonly T4 _item4;
		readonly T5 _item5;

		/// <summary>
		/// Gets or sets the item1.
		/// </summary>
		/// <value>The item1.</value>
		public T1 Item1
		{
			get { return _item1; }
		}

		/// <summary>
		/// Gets or sets the item2.
		/// </summary>
		/// <value>The item2.</value>
		public T2 Item2
		{
			get { return _item2; }
		}

		/// <summary>
		/// Gets or sets the item3.
		/// </summary>
		/// <value>The item3.</value>
		public T3 Item3
		{
			get { return _item3; }
		}

		/// <summary>
		/// Gets or sets the item4.
		/// </summary>
		/// <value>The item4.</value>
		public T4 Item4
		{
			get { return _item4; }
		}

		/// <summary>
		/// Gets or sets the item5.
		/// </summary>
		/// <value>The item5.</value>
		public T5 Item5
		{
			get { return _item5; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Tuple{T1,T2,T3,T4}"/> class.
		/// </summary>
		/// <param name="first">The first item.</param>
		/// <param name="second">The second item.</param>
		/// <param name="third">The third item.</param>
		/// <param name="fourth">The fourth item.</param>
		/// <param name="fifth">The fifth item.</param>
		public Tuple(T1 first, T2 second, T3 third, T4 fourth, T5 fifth)
		{
			_item1 = first;
			_item2 = second;
			_item3 = third;
			_item4 = fourth;
			_item5 = fifth;
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="Tuple{T1,T2,T3,T4,T5}"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="Tuple{T1,T2,T3,T4,T5}"/>.
		/// </returns>
		public override string ToString()
		{
			return string.Format("({0},{1},{2},{3},{4})", Item1, Item2, Item3, Item4, Item5);
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="Tuple{T1,T2,T3,T4,T5}"/>.
		/// </summary>
		/// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="Tuple{T1,T2,T3,T4,T5}"/>.</param>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="Tuple{T1,T2,T3,T4,T5}"/>; otherwise, false.
		/// </returns>
		/// <exception cref="T:System.NullReferenceException">
		/// The <paramref name="obj"/> parameter is null.
		/// </exception>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				throw new NullReferenceException("obj is null");
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Tuple<T1, T2, T3, T4, T5>)) return false;
			return Equals((Tuple<T1, T2, T3, T4, T5>) obj);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="obj" /> parameter; otherwise, false.
		/// </returns>
		/// <param name="obj">
		/// An object to compare with this object.
		/// </param>
		public bool Equals(Tuple<T1, T2, T3, T4, T5> obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj.Item1, Item1)
				&& Equals(obj.Item2, Item2)
					&& Equals(obj.Item3, Item3)
						&& Equals(obj.Item4, Item4)
							&& Equals(obj.Item5, Item5);
		}

		/// <summary>
		/// Serves as a hash function for a particular type. 
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="Tuple{T1,T2,T3,T4,T5}" />.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			return SystemUtil.GetHashCode(Item1, Item2, Item3, Item4, Item5);
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(Tuple<T1, T2, T3, T4, T5> left, Tuple<T1, T2, T3, T4, T5> right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Tuple<T1, T2, T3, T4, T5> left, Tuple<T1, T2, T3, T4, T5> right)
		{
			return !Equals(left, right);
		}
	}
}
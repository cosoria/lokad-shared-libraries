﻿using System;

namespace Lokad
{
	/// <summary>
	/// 	Decimal that also has currency type assotiated. It is used
	/// 	for enforcing logical consistency within the Lokad Billing.
	/// 
	/// 	We want to reduce chances of messing up by mixing different
	/// 	currencies together.
	/// </summary>
	public sealed class CurrencyAmount : IEquatable<CurrencyAmount>
	{
		/// <summary>Currency type</summary>
		public readonly CurrencyType Currency;

		/// <summary>
		/// 	Value in the given currency
		/// </summary>
		public readonly decimal Value;

		/// <summary>
		/// 	Initializes a new instance of the
		/// 	<see cref="CurrencyAmount" />
		/// 	struct.
		/// </summary>
		/// <param name="currency">The currency.</param>
		/// <param name="value">The value.</param>
		public CurrencyAmount(CurrencyType currency, decimal value)
		{
			Currency = currency;
			Value = value;
		}


		/// <summary>
		/// 	Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">
		/// 	An object to compare with this object.
		/// </param>
		/// <returns>
		/// 	true if the current object is equal to the
		/// 	<paramref name="other" />
		/// 	parameter; otherwise, false.
		/// </returns>
		public bool Equals(CurrencyAmount other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Currency, Currency) && other.Value == Value;
		}

		/// <summary>
		/// 	Determines whether the specified
		/// 	<see cref="System.Object" />
		/// 	is equal to this instance.
		/// </summary>
		/// <param name="obj">
		/// 	The
		/// 	<see cref="System.Object" />
		/// 	to compare with this instance.
		/// </param>
		/// <returns>
		/// 	<c>true</c>
		/// 	if the specified
		/// 	<see cref="System.Object" />
		/// 	is equal to this instance; otherwise,
		/// 	<c>false</c>
		/// 	.
		/// </returns>
		/// <exception cref="T:System.NullReferenceException">
		/// 	The
		/// 	<paramref name="obj" />
		/// 	parameter is null.
		/// </exception>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(CurrencyAmount)) return false;
			return Equals((CurrencyAmount)obj);
		}

		/// <summary>
		/// 	Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// 	A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
		/// </returns>
		public override int GetHashCode()
		{
			unchecked
			{
				return (Currency.GetHashCode() * 397) ^ Value.GetHashCode();
			}
		}

		/// <summary>
		/// 	Returns a
		/// 	<see cref="System.String" />
		/// 	that represents this instance.
		/// </summary>
		/// <returns>
		/// 	A
		/// 	<see cref="System.String" />
		/// 	that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format(@"{1} {0}", Currency, Value);
		}

		// extensions

		/// <summary>
		/// 	Rounds the specified amount to the specified amount of decimals.
		/// </summary>
		/// <param name="decimals">The decimals.</param>
		/// <returns>rounded instance</returns>
		public CurrencyAmount Round(int decimals)
		{
			return new CurrencyAmount(Currency, Math.Round(Value, decimals));
		}

		/// <summary>
		/// 	Converts this aurrency amount by applying the specified
		/// 	transformation function to the amount and returning new result instance.
		/// </summary>
		/// <param name="conversion">The conversion.</param>
		/// <returns>new result instance</returns>
		public CurrencyAmount Convert(Func<decimal, decimal> conversion)
		{
			return new CurrencyAmount(Currency, conversion(Value));
		}


		/// <summary>
		/// 	Implements the operator /.
		/// </summary>
		/// <param name="originalValue">The original value.</param>
		/// <param name="value">The value.</param>
		/// <returns>
		/// 	The result of the operator.
		/// </returns>
		public static CurrencyAmount operator /(CurrencyAmount originalValue, decimal value)
		{
			return new CurrencyAmount(originalValue.Currency, originalValue.Value / value);
		}


		/// <summary>
		/// 	Implements the operator *.
		/// </summary>
		/// <param name="originalValue">The original value.</param>
		/// <param name="value">The value.</param>
		/// <returns>
		/// 	The result of the operator.
		/// </returns>
		public static CurrencyAmount operator *(CurrencyAmount originalValue, decimal value)
		{
			return new CurrencyAmount(originalValue.Currency, originalValue.Value * value);
		}

		/// <summary>
		/// 	Implements the operator +.
		/// </summary>
		/// <param name="originalValue">The original value.</param>
		/// <param name="value">The value.</param>
		/// <returns>
		/// 	The result of the operator.
		/// </returns>
		public static CurrencyAmount operator +(CurrencyAmount originalValue, decimal value)
		{
			return new CurrencyAmount(originalValue.Currency, originalValue.Value + value);
		}

		/// <summary>
		/// 	Implements the operator +.
		/// </summary>
		/// <param name="originalValue">The original value.</param>
		/// <param name="amount">The amount to add.</param>
		/// <returns>
		/// 	The result of the operator.
		/// </returns>
		/// ///
		/// <exception cref="CurrencyMismatchException">
		/// 	If currency types do not match
		/// </exception>
		public static CurrencyAmount operator +(CurrencyAmount originalValue, CurrencyAmount amount)
		{
			ThrowIfMismatch(originalValue, amount, "+");
			return new CurrencyAmount(originalValue.Currency, originalValue.Value + amount.Value);
		}


		/// <summary>
		/// 	Implements the operator -.
		/// </summary>
		/// <param name="originalValue">The original value.</param>
		/// <param name="amount">
		/// 	The amount to subtract.
		/// </param>
		/// <returns>
		/// 	The result of the operator.
		/// </returns>
		/// <exception cref="CurrencyMismatchException">
		/// 	If currency types do not match
		/// </exception>
		public static CurrencyAmount operator -(CurrencyAmount originalValue, CurrencyAmount amount)
		{
			ThrowIfMismatch(originalValue, amount, "-");
			return new CurrencyAmount(originalValue.Currency, originalValue.Value - amount.Value);
		}


		/// <summary>
		/// 	Implements the operator &gt;.
		/// </summary>
		/// <param name="originalValue">The original value.</param>
		/// <param name="amount">
		/// 	The amount to compare with.
		/// </param>
		/// <returns>
		/// 	The result of the operator.
		/// </returns>
		/// <exception cref="CurrencyMismatchException">
		/// 	If currency types do not match
		/// </exception>
		public static bool operator >(CurrencyAmount originalValue, CurrencyAmount amount)
		{
			ThrowIfMismatch(originalValue, amount, ">");
			return originalValue.Value > amount.Value;
		}



		/// <summary>
		/// 	Implements the operator &gt;=.
		/// </summary>
		/// <param name="originalValue">The original value.</param>
		/// <param name="amount">
		/// 	The amount to compare with.
		/// </param>
		/// <returns>
		/// 	The result of the operator.
		/// </returns>
		/// <exception cref="CurrencyMismatchException">
		/// 	If currency types do not match
		/// </exception>
		public static bool operator >=(CurrencyAmount originalValue, CurrencyAmount amount)
		{
			ThrowIfMismatch(originalValue, amount, ">=");
			return originalValue.Value >= amount.Value;
		}

		/// <summary>
		/// 	Implements the operator &lt;=.
		/// </summary>
		/// <param name="originalValue">The original value.</param>
		/// <param name="amount">
		/// 	The amount to compare with.
		/// </param>
		/// <returns>
		/// 	The result of the operator.
		/// </returns>
		/// <exception cref="CurrencyMismatchException">
		/// 	If currency types do not match
		/// </exception>
		public static bool operator <=(CurrencyAmount originalValue, CurrencyAmount amount)
		{
			ThrowIfMismatch(originalValue, amount, "<=");
			return originalValue.Value >= amount.Value;
		}

		/// <summary>
		/// 	Implements the operator &gt;.
		/// </summary>
		/// <param name="originalValue">The original value.</param>
		/// <param name="amount">
		/// 	The amount to subtract.
		/// </param>
		/// <returns>
		/// 	The result of the operator.
		/// </returns>
		/// <exception cref="CurrencyMismatchException">
		/// 	If currency types do not match
		/// </exception>
		public static bool operator <(CurrencyAmount originalValue, CurrencyAmount amount)
		{
			ThrowIfMismatch(originalValue, amount, "<");
			return originalValue.Value < amount.Value;
		}

		static void ThrowIfMismatch(CurrencyAmount originalValue, CurrencyAmount amount, string operationName)
		{
			if (originalValue.Currency != amount.Currency)
				throw CurrencyMismatchException.Create("Can't apply the '{0}' operation to mismatching currencies '{1}' and '{2}'",
					operationName, originalValue.Currency, amount.Currency);
		}
	}
}
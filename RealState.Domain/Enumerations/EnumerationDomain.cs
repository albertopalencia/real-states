// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 02-08-2021
// ***********************************************************************
// <copyright file="EnumerationDomain.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Domain.Enumerations
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;
	using System.Reflection;


	/// <summary>
	/// Class EnumerationDomain.
	/// Implements the <see cref="RealState.Domain.Enumerations.IEnumerationDomain" />
	/// </summary>
	/// <seealso cref="RealState.Domain.Enumerations.IEnumerationDomain" />
	[ExcludeFromCodeCoverage]
	public abstract class EnumerationDomain : IEnumerationDomain
	{

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; private set; }


		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int Id { get; private set; }


		/// <summary>
		/// Initializes a new instance of the <see cref="EnumerationDomain"/> class.
		/// </summary>
		protected EnumerationDomain()
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EnumerationDomain"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		protected EnumerationDomain(int id, string name)
		{
			Id = id; Name = name;
		}


		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString() => Name;


		/// <summary>
		/// Gets all.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		public static IEnumerable<T> GetAll<T>() where T : EnumerationDomain
		{
			var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.NonPublic);
			return fields.Select(f => f.GetValue(null)).Cast<T>();
		}


		/// <summary>
		/// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			if (!(obj is EnumerationDomain value)) return false;
			var typeMatches = GetType().Equals(obj.GetType());
			var valueMatches = Id.Equals(value.Id);
			return typeMatches && valueMatches;
		}


		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => Id.GetHashCode();


		/// <summary>
		/// Absolutes the difference.
		/// </summary>
		/// <param name="firstValue">The first value.</param>
		/// <param name="secondValue">The second value.</param>
		/// <returns>System.Int32.</returns>
		public static int AbsoluteDifference(EnumerationDomain firstValue, EnumerationDomain secondValue)
		{
			var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
			return absoluteDifference;
		}


		/// <summary>
		/// Froms the value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value">The value.</param>
		/// <returns>T.</returns>
		public static T FromValue<T>(int value) where T : EnumerationDomain
		{
			var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
			return matchingItem;
		}


		/// <summary>
		/// Froms the display name.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="displayName">The display name.</param>
		/// <returns>T.</returns>
		public static T FromDisplayName<T>(string displayName) where T : EnumerationDomain
		{
			var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
			return matchingItem;
		}


		/// <summary>
		/// Parses the specified value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="K"></typeparam>
		/// <param name="value">The value.</param>
		/// <param name="description">The description.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>T.</returns>
		/// <exception cref="InvalidOperationException">'{value}' is not a valid {description} in {typeof(T)}</exception>
		private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : EnumerationDomain
		{
			var matchingItem = GetAll<T>().FirstOrDefault(predicate);
			if (matchingItem == null) throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
			return matchingItem;
		}


		/// <summary>
		/// Compares to.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns>System.Int32.</returns>
		public int CompareTo(object obj) => Id.CompareTo(((EnumerationDomain)obj).Id);
	}
}
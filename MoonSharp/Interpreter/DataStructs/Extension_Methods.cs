﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MoonSharp.Interpreter
{
	/// <summary>
	/// Extension methods used in the whole project.
	/// </summary>
	internal static class Extension_Methods
	{
		/// <summary>
		/// Gets a value from the dictionary or returns the default value
		/// </summary>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="dictionary">The dictionary.</param>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
		{
			return dictionary.TryGetValue(key, out var v) ? v : default(TValue);
		}


		/// <summary>
		/// Gets a value from the dictionary or creates it
		/// </summary>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="dictionary">The dictionary.</param>
		/// <param name="key">The key.</param>
		/// <param name="creator">A function which will create the value if it doesn't exist.</param>
		/// <returns></returns>
		public static TValue GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> creator)
		{
			TValue v;

			if (!dictionary.TryGetValue(key, out v))
			{
				v = creator();
				dictionary.Add(key, v);
			}

			return v;
		}


	}
}

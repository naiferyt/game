namespace System.Collections.Generic
{
	public interface IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		TValue this[TKey key] { get; set; }

		void Add(TKey key, TValue value);

		bool ContainsKey(TKey key);

		bool Remove(TKey key);

		bool TryGetValue(TKey key, out TValue value);
	}
}

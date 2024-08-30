using System;

/// <summary>
/// Generic Class for Singleton
/// </summary>
/// <typeparam name="T">Inherited Class</typeparam>
public class Singleton<T> where T : new()
{
	// [Lazy<T>] Let the instance of Singleton to be created with thread-safe, lazy creation.
	private static readonly Lazy<T> _instance = new(new T());
	public static T Instance => _instance.Value;

	// [Private / Protected Constructor] Prevents other classes from creating instance of Singleton by constructor.
	protected Singleton() { }
}
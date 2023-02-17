public abstract class Resolve { }

/// <summary>
/// Abstract class representing the Resolve of a Result type.
/// Exists due to some limitations with generics.
/// </summary>
public class Ok<T> : Resolve
{
    public T Value { get; private set; }
    public Ok(T value) { Value = value; }
}

public class Err<E> : Resolve
{
    public E Failure { get; private set; }
    public Err(E value) { Failure = value; }
}

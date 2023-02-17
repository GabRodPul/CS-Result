public abstract class Resolve { }

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

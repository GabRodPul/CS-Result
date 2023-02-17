public class Result<T, E>  
{
    public Resolve Resolve { get; private set; }
    public bool IsOk()    => Resolve is Ok<T>;
    public bool IsError() => Resolve is Err<E>;

    private Result(T okValue)  => Resolve = new Ok<T>(okValue);
    private Result(E errValue) => Resolve = new Err<E>(errValue);

    public static Result<T, E> Ok(T okValue)   => new Result<T, E>(okValue);
    public static Result<T, E> Err(E errValue) => new Result<T, E>(errValue);
}

/// <summary>
/// Functional programming inspired Result class.
/// To make error handling more graceful. 
/// </summary>
/// <typeparam name="T">Expected Success type</typeparam>
/// <typeparam name="E">Expected Failure type</typeparam>
public class Result<T, E>  
{
    /// <summary>
    /// Returns the Resolve of the Result.
    /// Meant to be used with switch or pattern matching.
    /// </summary>
    /// <value>Ok of T | Err of E</value>
    /// <example>
    /// Given this function:
    /// <code>
    /// public Result<int, string> AddPositives(int a, int b)
    /// {
    ///     if (a < 0) return Result<int, string>.Err("First parameter is lower than 0.");
    ///     if (b < 0) return Result<int, string>.Err("Second parameter is lower than 0.");
    ///     return Result<int, string>.Ok(a + b);
    /// }
    /// </code>
    /// 
    /// You'd handle the errors like so:
    /// <code>
    /// switch (AddPositives(3, 1))
    /// {
    ///     case Resolve.Ok<int>:
    ///         // code to handle Ok
    ///     
    ///     case Resolve.Err<string>:
    ///         // code to handle Err
    /// }
    /// 
    /// ----
    /// 
    /// AddPositives(3, 1) switch
    /// {
    ///     Ok<int>     ok  => // code to handle Ok
    ///     Err<string> err => // code to handle Err
    /// }
    /// </code>
    /// </example>
    public Resolve Resolve { get; private set; }
    public bool IsOk()    => Resolve is Ok<T>;
    public bool IsError() => Resolve is Err<E>;

    private Result(T okValue)  => Resolve = new Ok<T>(okValue);
    private Result(E errValue) => Resolve = new Err<E>(errValue);

    public static Result<T, E> Ok(T okValue)   => new Result<T, E>(okValue);
    public static Result<T, E> Err(E errValue) => new Result<T, E>(errValue);
}

<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	const int column0 = 50;
	const int column1 = 50;
	const int N = 1_000;
	var sw = new Stopwatch();
	sw.Start();
	for ( int i = 0; i < N; ++i ) {
		var r = RunWithResult();
	}
	String.Format("{0, -52}{1,20}", "Using Result:", sw.Elapsed).Dump();
	sw.Restart();
	for ( int i = 0; i < N; ++i ) {
		var r = RunWithException();
	}
	String.Format("{0, -48}{1,20}", "Exception catching:", sw.Elapsed).Dump();
	sw.Restart();
	for ( int i = 0; i < N; ++i ) {
		var r = RunWithExceptionEx();
	}
	String.Format("{0, -30}{1,20}", "Exception catching with no throwing: ", sw.Elapsed).Dump();
}

// Define other methods, classes and namespaces here
public Result RunWithResult()
{
	var res = GetResult();
	return res;
}


public Result< Foo > GetResult()
{
	return Result<Foo>.Failure<Foo>( new Foo() );
}


public Result RunWithException()
{
	try {
		var res = GetResultEx();
	}
	catch {
		return Result.Failure();
	}
	return Result.Success();
}


public Foo GetResultEx()
{
	throw new InvalidOperationException();
}

public Result RunWithExceptionEx()
{
	try {
		var res = GetResultExEx();
	}
	catch {
		return Result.Failure();
	}
	return Result.Success();
}


public Foo GetResultExEx()
{
	return new Foo();
}


public class Foo
{
	public object Obj { get; } = new object();
}







    public class Result
    {
        /// <summary>
        /// Instantiate succeeded <see cref="Result"/>.
        /// </summary>
        protected Result()
        {
            Succeeded = true;
        }

        /// <summary>
        /// Instantiate failed <see cref="Result"/> with errors.
        /// </summary>
        /// <param name="errors"></param>
        protected Result( IEnumerable< string > errors )
        {
            Errors = (errors as string[]) ?? errors.ToArray();
        }

        /// <summary>
        /// Instantiate failed <see cref="Result"/> with error.
        /// </summary>
        /// <param name="error"></param>
        protected Result( string error  )
        {
            Errors = new []{ error };
        }

        protected Result( Exception ex  )
        {
            var errors = new List< string >();

            if ( ex is AggregateException ae ) {
                foreach (Exception e in ae.Flatten().InnerExceptions ) {
                    AddExceptionMessages( e );
                }
            }
            else {
                AddExceptionMessages( ex );
            }

            Errors = errors.ToArray();

            void AddExceptionMessages( Exception e )
            {
                errors.Add( e.Message + " " );
                    if ( e.InnerException != null ) {
                        errors.Add( e.InnerException.Message + " " );
                    }
            }
        }

        public bool Succeeded { get; }
        public string[] Errors { get; } = new string[0];


        public static Result Success() => new Result();
        public static Result Failure() => new Result("");
        public static Result Failure( IEnumerable< string > errors ) => new Result(errors);
        public static Result Failure( string error ) => new Result(error);
        public static Result Failure( Exception ex ) => new Result(ex);

        public override string ToString()
        {
            if ( Errors.Any() ) {
                string error = Errors.Aggregate( "", (acc, err) => acc + err + "; " );
                return error.Substring(0, error.Length - 2) + "."; // cut "; "
            }

            return
                Succeeded ? "Succeeded." : "Failed.";
        }

        public static implicit operator bool( Result result ) => result.Succeeded;
    }

    public class Result< TDto > : Result
    {
        protected Result( TDto data = default ) : base() {
            Data = data;
        }

        /// <summary>
        /// Instantiate failed <see cref="Result{ TDto }"/> with error.
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        protected Result( string error, TDto data = default ) : base( error )
        {
            Data = data;
        }


        /// <summary>
        /// Instantiate failed <see cref="Result{ TDto }"/> with errors.
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="data"></param>
        protected Result( IEnumerable< string > errors, TDto data = default ) : base( errors )
        {
            Data = data;
        }

        protected Result( Exception ex ) : base( ex ) {}

        public TDto Data { get; }

#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public static Result< TDto > Success<TDto>( TDto dto ) => new Result<TDto>( dto );
        public static Result< TDto > Success<TDto>() => new Result<TDto>();
        public static Result< TDto > Failure<TDto>( TDto dto ) => new Result<TDto>( "", dto );
        public static Result< TDto > Failure<TDto>( string error ) => new Result< TDto >( error );
        public static Result< TDto > Failure<TDto>( string error, TDto dto ) => new Result<TDto>( error, dto );
        public static Result< TDto > Failure<TDto>( IEnumerable< string > errors )  => new Result<TDto>( errors );
        public static Result< TDto > Failure<TDto>( IEnumerable< string > errors, TDto dto ) => new Result<TDto>( errors, dto );
        public static Result< TDto > Failure<TDto>( Exception ex ) => new Result<TDto>( ex );
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type


        public override bool Equals( object obj )
        {
            if ( obj == null || obj.GetType() != GetType() ) {
                return false;
            } 

            var other = (Result<TDto>)obj;

            if ( typeof(TDto).IsClass ) {
                return ((Data == null && other.Data == null) || Data.Equals( other.Data )) && Succeeded.Equals( other.Succeeded );
            }

            return Data.Equals( other.Data ) && Succeeded.Equals( other.Succeeded );
        }

        public override int GetHashCode()
        {
            if ( typeof(TDto).IsClass ) {
                return Data?.GetHashCode() ?? 113 * (Succeeded.GetHashCode() * 7);
            }

            return Data.GetHashCode() * (Succeeded.GetHashCode() * 113);
        }

        public override string ToString()
        {
            return base.ToString() + $"{nameof(Data)}: {Data}.";
        }

        
    }

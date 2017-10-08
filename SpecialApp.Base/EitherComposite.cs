using Monad;
using SpecialApp.Base.ServiceResponse;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using SpecialApp.Entity.Specials;

namespace SpecialApp.Base
{
    public class EitherComposite
    {
        private readonly IEnumerable<bool> enumerable;
        private IEnumerable<Lazy<IErrorResponse>> enumerable1;

        public EitherComposite(IEnumerable<bool> enumerable)
        {
            this.enumerable = enumerable;
        }

        public EitherComposite(List<bool> enumerable, IEnumerable<Lazy<IErrorResponse>> enumerable1) : this(enumerable)
        {
            this.enumerable = enumerable;
            this.enumerable1 = enumerable1;
        }

        public bool IsFailure => enumerable.Any(er => er);

        public string Error => IsFailure ? string.Join(",", enumerable1.Select(er => er.Value.Error)) : string.Empty;

        public static EitherComposite Combine<T, T1, T2>(Either<IErrorResponse, T> arg1,
            Either<IErrorResponse, T1> arg2, Either<IErrorResponse, T2> arg3)
        {
            var errorListBool = GetErrorsBool(arg1.IsLeft(), arg2.IsLeft(), arg3.IsLeft());

            var errorList = new List<Lazy<IErrorResponse>>();

            if (arg1.IsLeft())
                errorList.Add(new Lazy<IErrorResponse>(arg1.Left));
            if (arg2.IsLeft())
                errorList.Add(new Lazy<IErrorResponse>(arg2.Left));
            if (arg3.IsLeft())
                errorList.Add(new Lazy<IErrorResponse>(arg3.Left));

            return new EitherComposite(errorListBool, errorList);
        }

        private static List<bool> GetErrorsBool(params bool[] args)
        {
            return args.ToList();
        }
    }

}

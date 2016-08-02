using System;
using ExceptionHandling_T1.Core.ExceptionHandling;

namespace ExceptionHandling_T1
{
    public abstract class Urun : MarshalByRefObject, IUrun
    {
        [ExceptionHandling]
        [Validate]
        public virtual bool Sorgula(string parameter)
        {
            return InternalUrunSorgula(parameter);
        }



        protected abstract bool InternalUrunSorgula(string parameter);


        private static void Validate(string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter))
                throw new ArgumentException("parameter boş olamaz", nameof(parameter));
            if (parameter.Length > 40) throw new ArgumentOutOfRangeException();
            if (parameter.Length < 5) throw new ArgumentOutOfRangeException();
        }
    }
}
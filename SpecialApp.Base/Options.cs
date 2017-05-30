using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialApp.Base
{
    public class Option<T> : IOption<T>
    {
        private readonly IEnumerable<T> Content;

        public Option(IEnumerable<T> content)
        {
            this.Content = content;
        }

        public IOption<T> Some(T value) => new Option<T>(new[] { value });

        public IOption<T> None() => new Option<T>(new T[0]);

        public IEnumerator<T> GetEnumerator() => this.Content.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }

    public interface IOption<T> : IEnumerable<T>
    {
        IOption<T> Some(T value);

        IOption<T> None();

    }
}

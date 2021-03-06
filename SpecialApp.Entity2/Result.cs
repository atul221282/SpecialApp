﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity
{
    public class Result<T>
    {
        public T Value { get; set; }

        public List<HateoasLinks> Links { get; set; }

        public static Result<T> Ok(T value, List<HateoasLinks> links)
        {
            return new Result<T> { Links = links, Value = value };
        }
    }

    public class HateoasLinks
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}

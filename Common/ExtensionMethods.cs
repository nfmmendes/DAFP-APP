﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ExtensionMethods {

        public static bool None<T>(this IEnumerable<T> enumerable) => !enumerable.Any();
     }
}

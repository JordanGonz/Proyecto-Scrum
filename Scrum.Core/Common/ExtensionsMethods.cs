﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Core.Common
{
    public static class ExtensionsMethods
    {

        public static T[] ToArray<T>(this ICollection<T> collection, int index = 0)
        {
            lock (collection)
            {
                var arr = new T[collection.Count - index];
                collection.CopyTo(arr, index);
                return arr;
            }
        }
    }
}

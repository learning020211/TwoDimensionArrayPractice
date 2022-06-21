using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDimensionArrayPractice
{
    public class TwoDimensionArrayIterator<T> : IIterator<T>
    {
        private int index = 0;
        private int columnCount => _values.GetLength(1);

        private T[,] _values;
        public TwoDimensionArrayIterator(T[,] data)
        {
            // pre condition
            if (data == null) throw new ArgumentNullException(nameof(data));

            _values = data;
        }

        public bool HasNext() => index < _values.Length;

        public T Next()
        {
            var res = _values[index / columnCount, index % columnCount];
            index++;
            return res;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDimensionArrayPractice
{

    public class LocationHelper<T>
    {
        private T[,] data;
        private Location currentLocation;
        private int rowCount => data.GetLength(0);
        private int columnCount => data.GetLength(1);

        public LocationHelper(T[,] data)
        {
            // pre condition
            if (data == null) throw new ArgumentNullException(nameof(data));

            this.data = data;
        }

        public ArrayItem<T> SetCurrentLocation(int newRowIndex, int newColumnIndex)
        {
            if (newRowIndex >= rowCount) throw new ArgumentOutOfRangeException(nameof(newRowIndex));
            if (newColumnIndex >= columnCount) throw new ArgumentOutOfRangeException(nameof(newColumnIndex));

            currentLocation.RowIndex = newRowIndex;
            currentLocation.ColumnIndex = newColumnIndex;

            return new ArrayItem<T>()
            {
                Location = currentLocation,
                Value = data[currentLocation.RowIndex, currentLocation.ColumnIndex]
            };
        }

        public ArrayItem<T> SetCurrentLocation(Location location)
        => SetCurrentLocation(location.RowIndex, location.ColumnIndex);

        public bool CanMoveRight(int offsetColumn = 1) => currentLocation.ColumnIndex + offsetColumn < columnCount;
        public ArrayItem<T> MoveRight(int offsetColumn = 1) => SetCurrentLocation(currentLocation.MoveRight(offsetColumn));

        public bool CanMoveUp(int offsetRow = 1) => currentLocation.RowIndex - offsetRow >= 0;
        public ArrayItem<T> MoveUp(int offsetRow = 1) => SetCurrentLocation(currentLocation.MoveUp(offsetRow));

        public bool CanMoveLeft(int offsetColumn = 1) => currentLocation.ColumnIndex - offsetColumn >= 0;
        public ArrayItem<T> MoveLeft(int offsetColumn = 1) => SetCurrentLocation(currentLocation.MoveLeft(offsetColumn));

        public bool CanMoveDown(int offsetRow = 1) => currentLocation.RowIndex + offsetRow < rowCount;
        public ArrayItem<T> MoveDown(int offsetRow = 1) => SetCurrentLocation(currentLocation.MoveDown(offsetRow));
    }
}

namespace TwoDimensionArrayPractice
{
    public struct Location
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public Location(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        public Location Offset(int rowOffset, int columnOffset)
        {
            RowIndex += rowOffset;
            ColumnIndex += columnOffset;
            return this;
        }

        public Location MoveLeft(int columnOffset) => Offset(0, -columnOffset);
        public Location MoveRight(int columnOffset) => Offset(0, columnOffset);

        public Location MoveUp(int rowOffset) => Offset(-rowOffset, 0);
        public Location MoveDown(int rowOffset) => Offset(rowOffset, 0);

        public override string ToString() => $"[{RowIndex}, {ColumnIndex}]";
    }
}

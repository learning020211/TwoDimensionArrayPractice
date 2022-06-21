namespace TwoDimensionArrayPractice
{
    public class ArrayItem<T>
    {
        public Location Location { get; set; }
        public T Value { get; set; }

        public override string ToString() => $"{Location}, value = {Value}";
    }
}

namespace ConsoleApp2
{
    public struct Parallelepiped : ICalculatable
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double CalculateSquare()
        {
            return 2 * (Length * Width + Length * Height + Width * Height);
        }
        public double CalculateVolume()
        {
            return Length * Width * Height;
        }
    }
}

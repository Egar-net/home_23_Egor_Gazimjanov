namespace ConsoleApp2
{
    public struct Pyramid : ICalculatable
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double CalculateSquare()
        {
            double area = Length * Width;

            double slant1 = Math.Sqrt(Math.Pow(Width / 2, 2) + Math.Pow(Height, 2));
            double slant2 = Math.Sqrt(Math.Pow(Length / 2, 2) + Math.Pow(Height, 2));

            double sideArea = 0.5 * (Length * slant1 + Width * slant2);

            return area + sideArea;
        }

        public double CalculateVolume()
        {
            return (1 / 3) * (Length * Width) * Height;
        }
    }
}

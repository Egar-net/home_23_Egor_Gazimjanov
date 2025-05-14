namespace ConsoleApp2
{
    public struct Cylinder : ICalculatable
    {
        public double Radius { get; set; }
        public double Height { get; set; }

        public double CalculateSquare()
        {
            return 2 * Math.PI * Radius * (Radius * Height);
        }

        public double CalculateVolume()
        {
            return Math.PI * Math.Pow(Radius, 2) * Height;
        }
    }
}

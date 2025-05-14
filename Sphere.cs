namespace ConsoleApp2
{
    public struct Sphere : ICalculatable
    {
        public double Radius { get; set; }

        public double CalculateSquare()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public double CalculateVolume()
        {
            return (4 / 3) * Math.PI * Math.Pow(Radius, 3);
        }
    }
}

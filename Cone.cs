namespace ConsoleApp2
{
    public struct Cone : ICalculatable
    {
        public double Radius { get; set; }
        public double Height { get; set; }

        public double CalculateSquare()
        {
            double l = Math.Sqrt(Radius * Radius + Height * Height); 
            return Math.PI * Radius *(Radius * l);
        }

        public double CalculateVolume()
        {
            return 1 / 3 * Math.PI * Math.Pow(Radius, 2) * Height;
        }
    }
}

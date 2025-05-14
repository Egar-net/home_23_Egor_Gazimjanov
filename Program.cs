using ConsoleApp2;
using System.Text.Json;

internal class Program
{

    static void Main(string[] args)
    {
        ICalculatable[] figures = new ICalculatable[]
        {
        new Parallelepiped(),
        new Pyramid(),
        new Sphere(),
        new Cylinder(),
        new Cone()
        };
        Menu(figures);
    }

    static void Menu(ICalculatable[] figures)
    {
        while (true)
        {
            try
            {
                string[] figureNames = { "Parallelepiped", "Pyramid", "Sphere", "Cylinder", "Cone" };

                Console.WriteLine("List of figures:\"0 EXIT\", \"1 Parallelepiped\", \"2 Pyramid\", \"3 Sphere\", \"4 Cylinder\", \"5 Cone\" ");
                Console.WriteLine("Choise figure: ");
                int user = Convert.ToInt32(Console.ReadLine());
                if (user == 0)
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
                if (user >= 1 && user <= figures.Length)
                {
                    int index = user - 1;
                    Console.WriteLine($"You selected: {figureNames[index]}");

                    switch (figures[index])
                    {
                        case Parallelepiped parallelepiped:
                            {
                                Console.Write("Enter length: ");
                                parallelepiped.Length = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter width: ");
                                parallelepiped.Width = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter height: ");
                                parallelepiped.Height = Convert.ToDouble(Console.ReadLine());
                                figures[index] = parallelepiped;
                                break;
                            }

                        case Pyramid pyramid:
                            {
                                Console.Write("Enter length: ");
                                pyramid.Length = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter width: ");
                                pyramid.Width = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter height: ");
                                pyramid.Height = Convert.ToDouble(Console.ReadLine());
                                figures[index] = pyramid;
                                break;
                            }

                        case Sphere sphere:
                            {
                                Console.Write("Enter radius: ");
                                sphere.Radius = Convert.ToDouble(Console.ReadLine());
                                figures[index] = sphere;
                                break;
                            }

                        case Cylinder cylinder:
                            {
                                Console.Write("Enter radius: ");
                                cylinder.Radius = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter height: ");
                                cylinder.Height = Convert.ToDouble(Console.ReadLine());
                                figures[index] = cylinder;
                                break;
                            }

                        case Cone cone:
                            {
                                Console.Write("Enter radius: ");
                                cone.Radius = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter height: ");
                                cone.Height = Convert.ToDouble(Console.ReadLine());
                                figures[index] = cone;
                                break;
                            }

                        default:
                            Console.WriteLine("Unknown figure.");
                            return;
                    }
                    int maxVolumeIndex = 0;
                    int maxSquareIndex = 0;

                    for (int i = 0; i < figures.Length; i++)
                    {
                        if (figures[i].CalculateVolume() > figures[maxVolumeIndex].CalculateVolume())
                            maxVolumeIndex = i;
                        if (figures[i].CalculateSquare() > figures[maxSquareIndex].CalculateSquare())
                            maxSquareIndex = i;
                    }


                    Console.WriteLine($" Figure{new String(' ', figureNames[index].Length-6)}| Volume{new String(' ', 2)}| Area");
                    Console.WriteLine($" {figureNames[index]}| {figures[index].CalculateVolume():F2}{new String(' ', 2)} | {figures[index].CalculateSquare():F2}");

                    var result = new ResultOfFigure
                    {
                        Figure = figureNames[index],
                        Volume = figures[index].CalculateVolume(),
                        Square = figures[index].CalculateSquare()
                    };

                    SaveResult(result);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Err!" + ex.Message);
            }
        }
    }

    static void SaveResult(ResultOfFigure result)
    {
        string filePath = "results.json";
        ResultOfFigure[] results;

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            results = JsonSerializer.Deserialize<ResultOfFigure[]>(json) ?? new ResultOfFigure[0];
        }
        else
        {
            results = new ResultOfFigure[0];
        }

        ResultOfFigure[] updatedResults = new ResultOfFigure[results.Length + 1];
        for (int i = 0; i < results.Length; i++)
        {
            updatedResults[i] = results[i];
        }
        updatedResults[updatedResults.Length - 1] = result;

        string updatedJson = JsonSerializer.Serialize(updatedResults, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, updatedJson);
    }
}


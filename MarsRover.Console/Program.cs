namespace MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter plateau size: ");
            string plateauInput = Console.ReadLine();
            (int,int) processedPlateau = InputParser.PlateauParser(plateauInput);
            Console.WriteLine($"Reformatted Plateau: {processedPlateau}");


            Console.WriteLine("Enter starting position: ");
            string positionInput = Console.ReadLine();
            Position processedPosition = InputParser.PositionParser(positionInput);
            Console.WriteLine($"Reformatted Position: {processedPosition.ToString()}");

            Console.WriteLine("Enter instructions: ");
            string instructions1 = Console.ReadLine();
            List<Instruction> processedInstructions = InputParser.InstructionParser(instructions1);
            string reformattedInstructions = String.Join("", processedInstructions);
            Console.WriteLine($"Reformatted Instructions: {reformattedInstructions}");

        }
    }
}

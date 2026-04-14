using System.Runtime.CompilerServices;

namespace MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter plateau size: ");
            string plateauInput = Console.ReadLine();
            PlateauSize processedPlateau = InputParser.PlateauParser(plateauInput);
            Console.WriteLine($"Reformatted Plateau: {processedPlateau}");


            Console.WriteLine("Enter starting position: ");
            string positionInput = Console.ReadLine();
            Position processedPosition = InputParser.PositionParser(positionInput);
            Console.WriteLine($"Reformatted Position: {processedPosition.ToString()}");

            Console.WriteLine("Enter instructions: ");
            string instructions = Console.ReadLine();
            List<Instruction> processedInstructions = InputParser.InstructionParser(instructions);
            string reformattedInstructions = String.Join("", processedInstructions);
            Console.WriteLine($"Reformatted Instructions: {reformattedInstructions}");

            Position currentPosition = processedPosition;
            
            Console.WriteLine($"\nStarting Position: {currentPosition.ToString()}" );

            foreach (Instruction instruction in processedInstructions)
            {
                if (instruction == Instruction.L || instruction == Instruction.R)
                {
                    var newFacing = Rover.Rotate(currentPosition.facing, instruction);
                    currentPosition = new Position(currentPosition.x, currentPosition.y, newFacing);
                }

                else if (instruction == Instruction.M) 
                {
                    var positionAfterInstruction = Rover.Move(processedPlateau, currentPosition, instruction);
                    currentPosition = new Position(positionAfterInstruction.x, positionAfterInstruction.y, positionAfterInstruction.facing);
                }
            }

            Console.WriteLine($"New position after instructions is: {currentPosition.ToString()}");

        }
    }
}

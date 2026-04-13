using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class InputParser
    {
        public static (int, int) PlateauParser(string? rawPlateau) 
        {
            if (string.IsNullOrWhiteSpace(rawPlateau))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }

            string[] plateauCoords = rawPlateau.Split(" ");

            if (plateauCoords.Length != 2)
            {
                throw new ArgumentException("Need a string of exactly 2 numbers!");
            }

            if (!int.TryParse(plateauCoords[0], out int maxX) || !int.TryParse(plateauCoords[1], out int maxY))
            {
                throw new FormatException("Input must contain valid integers.");
            }

            if (maxX <= 0 || maxY <= 0)
            {
                throw new ArgumentOutOfRangeException("Coordinates must be positive integers.");
            }
            return (maxX, maxY);
        }

        public static Position PositionParser(string? rawPosition) 
        {
            if (string.IsNullOrWhiteSpace(rawPosition))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }

            string[] positionParts = rawPosition.Split(" ");

            if (positionParts.Length != 3) 
            {
                throw new ArgumentException("Input must contain exactly 3 values.");
            }

            if (!int.TryParse(positionParts[0], out int startingX) || !int.TryParse(positionParts[1], out int startingY)) 
            { 
                throw new FormatException("Input must contain valid integers.");
            }

            string directionInput = positionParts[2].ToUpper();
            if (!"NESW".Contains(directionInput) || directionInput.Length != 1)
            {
                throw new FormatException("Invalid compass direction.");
            }
            CompassDirection facing = Enum.Parse<CompassDirection>(directionInput);

            return new Position(startingX, startingY, facing);
        }

        public static List<Instruction> InstructionParser(string rawInstruction) 
        {
            List<Instruction> processedInstructions = new List<Instruction> ();
            foreach (char letter in rawInstruction.ToUpper()) 
            {
                if ("L".Contains(letter))
                {
                    processedInstructions.Add(Instruction.L);
                }
                else if ("R".Contains(letter))
                {
                    processedInstructions.Add(Instruction.R);
                }
                else if ("M".Contains(letter))
                    processedInstructions.Add(Instruction.M);
            }
            return processedInstructions;
        }
    }
}

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
        public static (int, int) PlateauParser(string rawPlateau) 
        {
            string[] plateauCoords = rawPlateau.Split(" ");

            if (string.IsNullOrWhiteSpace(rawPlateau))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }

            if (plateauCoords.Length != 2)
            {
                throw new ArgumentException("Parsing failed: Need a string of exactly 2 numbers!");
            }

            if (!int.TryParse(plateauCoords[0], out int x) || !int.TryParse(plateauCoords[1], out int y))
            {
                throw new FormatException("Parsing failed: Input must contain valid integers.");
            }
            if (x <= 0 || y <= 0)
            {
                throw new ArgumentOutOfRangeException("Coordinates must be positive integers.");
            }
            return (x, y);
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

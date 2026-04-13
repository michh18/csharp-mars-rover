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
            try
            {
                string[] plateauCoords = rawPlateau.Split(" ");
                if (plateauCoords.Length != 2)
                {
                    throw new Exception("Parsing failed: Need a string of exactly 2 numbers!");
                }

                int x = int.Parse(plateauCoords[0]);
                int y = int.Parse(plateauCoords[1]);

                return new(x, y);
            }
            catch (FormatException formatEx) 
            {
                throw new FormatException("Parsing failed: Input string didn't contain two numbers");
            }
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

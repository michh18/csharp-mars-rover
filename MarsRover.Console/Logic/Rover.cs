using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        public static CompassDirection Rotate(CompassDirection facing, Instruction rotateInstruction) 
        {            
            if (rotateInstruction != Instruction.L && rotateInstruction != Instruction.R) 
            {
                throw new FormatException("Invalid rotation instruction.");
            }
            int newFacingIndex = ((int)facing + (int)rotateInstruction + 4) % 4;
            return (CompassDirection)newFacingIndex;
        }

        public static Position Move(PlateauSize plateauSize, Position startPosition, Instruction moveInstruction) 
        { 
            if (moveInstruction != Instruction.M)
            {
                throw new FormatException("Invalid move instruction.");
            }

            switch (startPosition.facing) 
            {
                case CompassDirection.N:
                    if (startPosition.y + 1 > plateauSize.maxY) 
                    {
                        throw new ArgumentOutOfRangeException("Rover moved out of plateau.");
                    }
                    return new Position(startPosition.x, startPosition.y + 1, startPosition.facing);
                case CompassDirection.E:
                    if (startPosition.x + 1 > plateauSize.maxX)
                    {
                        throw new ArgumentOutOfRangeException("Rover moved out of plateau.");
                    }
                    return new Position(startPosition.x + 1, startPosition.y, startPosition.facing);
                case CompassDirection.S:
                    if (startPosition.y - 1 < 0)
                    {
                        throw new ArgumentOutOfRangeException("Rover moved out of plateau.");
                    }
                    return new Position(startPosition.x, startPosition.y - 1, startPosition.facing);
                case CompassDirection.W:
                    if (startPosition.x - 1 < 0)
                    {
                        throw new ArgumentOutOfRangeException("Rover moved out of plateau.");
                    }
                    return new Position(startPosition.x - 1, startPosition.y, startPosition.facing);
            }
            return null;
        }

        public static Position ExecuteInstructions(PlateauSize plateauSize, Position startPosition, List<Instruction> instructions) 
        {
            Position currentPosition = startPosition;

            Console.WriteLine($"\nStarting Position: {currentPosition.ToString()}");

            foreach (Instruction instruction in instructions)
            {
                if (instruction == Instruction.L || instruction == Instruction.R)
                {
                    var newFacing = Rover.Rotate(currentPosition.facing, instruction);
                    currentPosition = new Position(currentPosition.x, currentPosition.y, newFacing);
                }

                else if (instruction == Instruction.M)
                {
                    var positionAfterInstruction = Rover.Move(plateauSize, currentPosition, instruction);
                    currentPosition = new Position(positionAfterInstruction.x, positionAfterInstruction.y, positionAfterInstruction.facing);
                }
            }
            Console.WriteLine($"New position after instructions is: {currentPosition.ToString()}");
            return currentPosition;
        }
    }
}

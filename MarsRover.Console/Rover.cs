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
        private CompassDirection _facing { get; set; }
        private Instruction _rotateInfo { get; set; }

        public Rover(CompassDirection facing, Instruction rotateInfo) 
        {
            _facing = facing;
            _rotateInfo = rotateInfo;
        }
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
                    if (startPosition.y + 1>= plateauSize.maxY) 
                    {
                        throw new ArgumentOutOfRangeException("Rover moved out of plateau.");
                    }
                    return new Position(startPosition.x, startPosition.y + 1, CompassDirection.N);
                case CompassDirection.E:
                    if (startPosition.x + 1 >= plateauSize.maxX)
                    {
                        throw new ArgumentOutOfRangeException("Rover moved out of plateau.");
                    }
                    return new Position(startPosition.x + 1, startPosition.y, CompassDirection.E);
                case CompassDirection.S:
                    if (startPosition.y - 1 < 0)
                    {
                        throw new ArgumentOutOfRangeException("Rover moved out of plateau.");
                    }
                    return new Position(startPosition.x, startPosition.y - 1, CompassDirection.S);
                case CompassDirection.W:
                    if (startPosition.x - 1 < 0)
                    {
                        throw new ArgumentOutOfRangeException("Rover moved out of plateau.");
                    }
                    return new Position(startPosition.x - 1, startPosition.y, CompassDirection.W);
            }
            return null;
        }
    }
}

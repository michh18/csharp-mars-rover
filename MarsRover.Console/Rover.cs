using System;
using System.Collections.Generic;
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
    }
}

using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Tests
{
    public class Rover_Tests
    {
        class RotateTests
        {
            // ================================ Rotate Tests =========================================
            [TestCase(CompassDirection.N, Instruction.R, CompassDirection.E)]
            [TestCase(CompassDirection.E, Instruction.R, CompassDirection.S)]
            [TestCase(CompassDirection.S, Instruction.R, CompassDirection.W)]
            [TestCase(CompassDirection.W, Instruction.R, CompassDirection.N)]
            public void Rotate_ShouldReturnCorrectDirection_WhenRotatingRight(CompassDirection facing, Instruction rotateInstruction, CompassDirection expected)
            {
                var result = Rover.Rotate(facing, rotateInstruction);
                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(CompassDirection.N, Instruction.L, CompassDirection.W)]
            [TestCase(CompassDirection.E, Instruction.L, CompassDirection.N)]
            [TestCase(CompassDirection.S, Instruction.L, CompassDirection.E)]
            [TestCase(CompassDirection.W, Instruction.L, CompassDirection.S)]
            public void Rotate_ShouldReturnCorrectDirection_WhenRotatingLeft(CompassDirection facing, Instruction rotateInstruction, CompassDirection expected)
            {
                var result = Rover.Rotate(facing, rotateInstruction);
                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(CompassDirection.N, Instruction.M)]
            public void Rotate_ShouldThrowFormatException_WhenUsingInstructionM(CompassDirection facing, Instruction rotateInstruction)
            {
                string expected = "Invalid rotation instruction.";
                var ex = Assert.Throws<FormatException>(() => Rover.Rotate(facing, rotateInstruction));
                Assert.That(ex.Message.ToString(), Does.Contain(expected));
            }
        }
        // ================================ Move Tests =========================================
        class MoveTests
        {
            [Test]
            public void Move_ShouldReturnCorrectPosition_WhenMoving()
            {
                var plateauSize = new PlateauSize(5, 5);
                var moveInstruction = Instruction.M;

                var startPosition1 = new Position(0, 0, CompassDirection.N);
                var startPosition2 = new Position(0, 0, CompassDirection.E);
                var startPosition3 = new Position(5, 5, CompassDirection.S);
                var startPosition4 = new Position(5, 5, CompassDirection.W);

                var result1 = new Position(0, 1, CompassDirection.N);
                var result2 = new Position(1, 0, CompassDirection.E);
                var result3 = new Position(5, 4, CompassDirection.S);
                var result4 = new Position(4, 5, CompassDirection.W);

                var startPositionList = new List<Position>() { startPosition1, startPosition2, startPosition3, startPosition4 };
                var resultList = new List<Position>() { result1, result2, result3, result4 };
                for (int i = 0; i < startPositionList.Count; i++)
                {
                    var result = Rover.Move(plateauSize, startPositionList[i], moveInstruction);
                    Assert.That(result, Is.EqualTo(resultList[i]));
                }
            }
            [Test]
            public void Move_ShouldThrowArgumentOutOfRangeException_WhenRoverMovesOutOfPlateau()
            {
                var plateauSize = new PlateauSize(5, 5);
                var moveInstruction = Instruction.M;

                var startPosition1 = new Position(5, 5, CompassDirection.N);
                var startPosition2 = new Position(5, 5, CompassDirection.E);
                var startPosition3 = new Position(0, 0, CompassDirection.S);
                var startPosition4 = new Position(0, 0, CompassDirection.W);

                var startPositionList = new List<Position>() { startPosition1, startPosition2, startPosition3, startPosition4 };
                foreach (var startPosition in startPositionList)
                {
                    string expected = "Rover moved out of plateau.";
                    var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Rover.Move(plateauSize, startPosition, moveInstruction));
                    Assert.That(ex.Message.ToString(), Does.Contain(expected));
                }   
            }
        } 
    }
}

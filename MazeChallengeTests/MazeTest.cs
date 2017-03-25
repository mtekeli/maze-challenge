using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MazeChallange;
namespace MazeChallengeTests
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Maze_WhenFileNotFound_ShouldThrowFileNotFound()
        {
            ETravelMaze maze = new ETravelMaze("TestCase\\Maze000.txt");
        }

        [TestMethod]
        public void Maze_ShouldSolve001()
        {
            ETravelMaze maze = new ETravelMaze("TestCase\\Maze001.txt");
            IMazeSolver bfsSolver = new BFSMazeSolver();
            bfsSolver.Solve(maze, Assert.IsNotNull);
        }

        [TestMethod]
        public void Maze_ShouldSolve002()
        {
            ETravelMaze maze = new ETravelMaze("TestCase\\Maze002.txt");
            IMazeSolver bfsSolver = new BFSMazeSolver();
            bfsSolver.Solve(maze, Assert.IsNotNull);
        }

        [TestMethod]
        public void Maze_WhenGoalIsMoreThanOne_ShouldThrowInvalidData()
        {
            try
            {
                ETravelMaze maze = new ETravelMaze("TestCase\\Maze003.txt");
            }
            catch (InvalidDataException e)
            {
                StringAssert.Contains(e.Message, ETravelMaze.MazeCanOnlyHaveOneGoalMessage);
            }
        }

        [TestMethod]
        public void Maze_WhenStartIsMoreThanOne_ShouldThrowInvalidData()
        {
            try
            {
                ETravelMaze maze = new ETravelMaze("TestCase\\Maze004.txt");
            }
            catch (InvalidDataException e)
            {
                StringAssert.Contains(e.Message, ETravelMaze.MazeCanOnlyHaveOneStartPointMessage);
            }
        }

        [TestMethod]
        public void Maze_WhenRowsHaveDifferentNumberOfCells_ShouldThrowInvalidData()
        {
            try
            {
                ETravelMaze maze = new ETravelMaze("TestCase\\Maze005.txt");
            }
            catch (InvalidDataException e)
            {
                StringAssert.Contains(e.Message, ETravelMaze.MazeRowsMustHaveSameNumberOfCellsMessage);
            }
        }

        [TestMethod]
        public void Maze_WhenNoStartPointAvailable_ShouldThrowInvalidData()
        {
            try
            {
                ETravelMaze maze = new ETravelMaze("TestCase\\Maze006.txt");
            }
            catch (InvalidDataException e)
            {
                StringAssert.Contains(e.Message, ETravelMaze.MazeMustHaveStartPointMessage);
            }
        }

        [TestMethod]
        public void Maze_ShouldSolve007()
        {
            ETravelMaze maze = new ETravelMaze("TestCase\\Maze007.txt");
            IMazeSolver bfsSolver = new BFSMazeSolver();
            bfsSolver.Solve(maze, Assert.IsNotNull);
        }

        [TestMethod]
        public void Maze_ShouldSolve008()
        {
            ETravelMaze maze = new ETravelMaze("TestCase\\Maze008.txt");
            IMazeSolver bfsSolver = new BFSMazeSolver();
            bfsSolver.Solve(maze, Assert.IsNotNull);
        }
    }
}

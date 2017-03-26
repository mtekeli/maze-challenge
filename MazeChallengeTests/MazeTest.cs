using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MazeChallenge;

namespace MazeChallengeTests
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Maze_WhenFileNotFound_ShouldThrowFileNotFound()
        {
            Maze maze = new StandardMaze("TestCase\\Maze000.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Maze_WhenAlgorithmParameterBelowMinimum_ShouldThrowOverFlow()
        {
            Maze maze = new StandardMaze("TestCase\\Maze001.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, "-1");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Maze_WhenAlgorithmParameterOverMaximum_ShouldThrowOverFlow2()
        {
            Maze maze = new StandardMaze("TestCase\\Maze001.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, "65536");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Maze_WhenAlgorithmParameterOutOfRange_ShouldThrowArgumentOutOfRange()
        {
            Maze maze = new StandardMaze("TestCase\\Maze001.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, "3");
        }

        [TestMethod]
        public void Maze_ShouldSolve001BFS()
        {
            Maze maze = new StandardMaze("TestCase\\Maze001.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, Algorithm.Bfs);
            solver.Solve(Assert.IsNotNull);
        }

        [TestMethod]
        public void Maze_ShouldSolve001DFS()
        {
            Maze maze = new StandardMaze("TestCase\\Maze001.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, Algorithm.Dfs);
            solver.Solve(Assert.IsNotNull);
        }

        [TestMethod]
        public void Maze_ShouldSolve002BFS()
        {
            Maze maze = new StandardMaze("TestCase\\Maze002.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, Algorithm.Bfs);
            solver.Solve(Assert.IsNotNull);
        }

        [TestMethod]
        public void Maze_ShouldSolve002DFS()
        {
            Maze maze = new StandardMaze("TestCase\\Maze002.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, Algorithm.Dfs);
            solver.Solve(Assert.IsNotNull);
        }

        [TestMethod]
        public void Maze_WhenGoalIsMoreThanOne_ShouldThrowInvalidData()
        {
            try
            {
                Maze maze = new StandardMaze("TestCase\\Maze003.txt");
            }
            catch (InvalidDataException e)
            {
                StringAssert.Contains(e.Message, StandardMaze.MazeCanOnlyHaveOneGoalMessage);
            }
        }

        [TestMethod]
        public void Maze_WhenStartIsMoreThanOne_ShouldThrowInvalidData()
        {
            try
            {
                Maze maze = new StandardMaze("TestCase\\Maze004.txt");
            }
            catch (InvalidDataException e)
            {
                StringAssert.Contains(e.Message, StandardMaze.MazeCanOnlyHaveOneStartPointMessage);
            }
        }

        [TestMethod]
        public void Maze_WhenRowsHaveDifferentNumberOfCells_ShouldThrowInvalidData()
        {
            try
            {
                Maze maze = new StandardMaze("TestCase\\Maze005.txt");
            }
            catch (InvalidDataException e)
            {
                StringAssert.Contains(e.Message, StandardMaze.MazeRowsMustHaveSameNumberOfCellsMessage);
            }
        }

        [TestMethod]
        public void Maze_WhenNoStartPointAvailable_ShouldThrowInvalidData()
        {
            try
            {
                Maze maze = new StandardMaze("TestCase\\Maze006.txt");
            }
            catch (InvalidDataException e)
            {
                StringAssert.Contains(e.Message, StandardMaze.MazeMustHaveStartPointMessage);
            }
        }

        [TestMethod]
        public void Maze_ShouldSolve007BFS()
        {
            Maze maze = new StandardMaze("TestCase\\Maze007.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, Algorithm.Bfs);
            solver.Solve(Assert.IsNotNull);
        }

        [TestMethod]
        public void Maze_ShouldSolve007DFS()
        {
            Maze maze = new StandardMaze("TestCase\\Maze007.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, Algorithm.Dfs);
            solver.Solve(Assert.IsNotNull);
        }

        [TestMethod]
        public void Maze_ShouldSolve008BFS()
        {
            Maze maze = new StandardMaze("TestCase\\Maze008.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, Algorithm.Bfs);
            solver.Solve(Assert.IsNotNull);
        }

        [TestMethod]
        public void Maze_ShouldSolve008DFS()
        {
            Maze maze = new StandardMaze("TestCase\\Maze008.txt");
            var solver = new MazeSolutionBuilder().BuildMazeSolver(maze, Algorithm.Dfs);
            solver.Solve(Assert.IsNotNull);
        }
    }
}

using UnityEngine;

public class MechGrid {

	public enum Direction {
		RIGHT,
		UP,
		LEFT,
		DOWN
	}

	private bool[,] grid;
	private int width;
	private int height;

	public MechGrid(int w, int h)
	{
		width = w;
		height = h;
		grid = new bool[width, height];
		for (int i = 0; i < grid.GetLength(0); i++)
			for (int j = 0; j < grid.GetLength(1); j++)
				grid[i, j] = false;
	}

	public void placeBlock(int row, int col)
	{
		if (insideGrid(row, col))
			grid[row, col] = true;
	}

	public Vector2 moveBlock(int row, int col, Direction d)
	{
		if (!insideGrid(row, col) || !grid[row, col])
			return new Vector2(row, col);

		int dRow = 0;
		int dCol = 0;

		switch (d) {
		case Direction.UP:
			dRow = -1;
			break;
		case Direction.DOWN:
			dRow = 1;
			break;
		case Direction.LEFT:
			dCol = -1;
			break;
		case Direction.RIGHT:
			dCol = 1;
			break;
		}
		
		int newRow = row;
		int newCol = col;
		int nextRow = row + dRow;
		int nextCol = col + dCol;
		while (insideGrid(nextRow, nextCol) && !isOccupied(nextRow, nextCol)) {
			newRow = nextRow;
			newCol = nextCol;
			nextRow += dRow;
			nextCol += dCol;
		}

		grid[row, col] = false;
		grid[newRow, newCol] = true;
		return new Vector2(newRow, newCol);
	}

	private bool insideGrid(int row, int col)
	{
		return (row >= 0
		        && row < width
		        && col >= 0
		        && col < height);
	}

	private bool isOccupied(int row, int col)
	{
		return grid[row, col];
	}

	public void printGrid()
	{
		for (int i = 0; i < grid.GetLength(0); i++) {
			string s = "";
			for (int j = 0; j < grid.GetLength(1); j++) {
				s += (grid[i, j] ? "1" : "0") + " ";
			}
			Debug.Log(s);
		}
	}
}

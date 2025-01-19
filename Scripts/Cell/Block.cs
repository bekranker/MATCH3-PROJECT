using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Graph Item
/// </summary>
/// <typeparam name="T">Generic type for using all of the cases</typeparam>
/// <typeparam name="U">Generic type for using Block's Data</typeparam>
public class Block<T>
{
    public Vector2Int BlockData;
    public bool InUse;
    /// <summary>
    /// Type of the root Cell
    /// </summary>
    public BlockColor BlockColor;
    /// <summary>
    /// Neighboors of the Root Cells (i.e up, down, right, left)
    /// </summary>
    public Block<T> Up;
    public Block<T> Down;
    public Block<T> Right;
    public Block<T> Left;

    /// <summary>
    /// The Root Cell of the Neihboors
    /// </summary>
    public T Root;

    /// <summary>
    /// It is a DFS algorithm function thats giving us the matched neighboors.
    /// </summary>
    /// <returns>A list of Blocks that are matched by color.</returns>
    public List<Block<T>> GetMatchedNeighboors()
    {
        InUse = true;
        List<Block<T>> Neighboors = new List<Block<T>>{
            Up,
            Down,
            Right,
            Left
        };
        //matched list.
        List<Block<T>> matchedNeighbors = new();
        // Add the current Block to the visited set to avoid revisiting it.
        // Iterate through all neighbors to find matched cells.
        foreach (Block<T> neighbor in Neighboors)
        {
            if (neighbor != null)
            {
                // Check if the neighbor has the same cell type and hasn't been visited yet.
                if (neighbor.BlockColor == BlockColor && !neighbor.InUse)
                {
                    // Add the matched neighbor to the list.
                    matchedNeighbors.Add(neighbor);

                    // Recursively find matches starting from this neighbor.
                    matchedNeighbors.AddRange(neighbor.GetMatchedNeighboors());
                }
            }
        }
        // Finally, return all the matched neighbors found.
        return matchedNeighbors;
    }
}
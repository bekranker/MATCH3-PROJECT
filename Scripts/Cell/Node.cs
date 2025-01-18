using System.Collections.Generic;

/// <summary>
/// The Graph Item
/// </summary>
/// <typeparam name="T">Generic type for using all of the cases</typeparam>
public class Node<T>
{
    /// <summary>
    /// Type of the root Cell
    /// </summary>
    public CellType CellType;
    /// <summary>
    /// Neighboors of the Root Cells (i.e up, down, right, left)
    /// </summary>
    public List<Node<T>> Neighboors;
    /// <summary>
    /// The Root Cell of the Neihboors
    /// </summary>
    public Node<T> Root => this;
    /// <summary>
    /// It is checking is there have any neighboors
    /// </summary>
    /// <returns></returns>
    public bool HasNeighboors() => Neighboors.Count > 0;
    /// <summary>
    /// It is a recursive function thats giving us the matched color neighboors and them matched neighboors either.
    /// </summary>
    /// <param name="visited">A set to track visited nodes and prevent infinite recursion.</param>
    /// <returns>A list of nodes that are matched by color.</returns>
    public List<Node<T>> GetMatchedNeighboors(HashSet<Node<T>> visited = null)
    {
        // If this is the first call, initialize the visited set. We use Hashset bc there will be not same items in the List and it is much more fast bc a Hashset complex is O(1) for adding or removing items.
        visited ??= new HashSet<Node<T>>();
        //matched list.
        List<Node<T>> matchedNeighbors = new();
        // Add the current node to the visited set to avoid revisiting it.
        visited.Add(this);
        // Iterate through all neighbors to find matched cells.
        foreach (Node<T> neighbor in Neighboors)
        {
            // Check if the neighbor has the same cell type and hasn't been visited yet.
            if (neighbor.CellType == CellType && !visited.Contains(neighbor))
            {
                // Add the matched neighbor to the list.
                matchedNeighbors.Add(neighbor);

                // Recursively find matches starting from this neighbor.
                matchedNeighbors.AddRange(neighbor.GetMatchedNeighboors(visited));
            }
        }
        // Finally, return all the matched neighbors found.
        return matchedNeighbors;
    }
}
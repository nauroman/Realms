using UnityEngine;
using System.Collections;

public class Cell// : Vector3
{
    public float x, y;

    public Cell()
    {
    }

    public Cell(float x, float y)
    {
        this.x = x;
        this.y = y;  
    }

    public Cell(Cell cell)
    {
        x = cell.x;
        y = cell.y;   
    }

    public Cell(Vector3 v)
    {
        this.Vector3 = v;
    }

    public Vector3 Vector3
    {
        set
        {
            x = Mathf.Round(value.x / 16);
            y = Mathf.Round(value.y / 16);
        }

        get
        {
            return new Vector3(x * 16, y * 16, 0);
        }
    }

    /*
    public Vector3 GetPosition()
    {
        return new Vector3(x * 16, y * 16, z);
    }
    */

    public static Cell operator +(Cell a, Cell b)
    {
        return new Cell(a.x + b.x, a.y + b.y);
    }

    public static Cell operator -(Cell a, Cell b)
    {
        return new Cell(a.x - b.x, a.y - b.y);
    }




    public static bool operator ==(Cell a, Cell b)
    {
        // If both are null, or both are same instance, return true.
        if (System.Object.ReferenceEquals(a, b))
        {
            return true;
        }
        
        // If one is null, but not both, return false.
        if (((object)a == null) || ((object)b == null))
        {
            return false;
        }
        /*
        if (lhs == null || rhs == null)
            return false;
*/

//        return a != null && b != null && a.x == b.x && a.y == b.y;
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(Cell a, Cell b)
    {
        return !(a == b);
    }

    /*
    public static bool operator !=(Cell lhs, Cell rhs)
    {
//        if (lhs == null || rhs == null)
        //          return true;

        return lhs == null || rhs == null || lhs.x != rhs.x || lhs.y != rhs.y;
    }
    */

    public string Direction
    {
        get
        {
            if (x > 0)
            {
                return  "Right";
            }
            if (x < 0)
            {
                return "Left";
            }
            if (y > 0)
            {
                return "Back";
            }
            if (y < 0)
            {
                return "Front";
            }

            return "Right";
        }
    }


}

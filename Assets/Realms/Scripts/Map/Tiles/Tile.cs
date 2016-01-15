using UnityEngine;
using System.Collections;

namespace com.flashunity.realms.tiles
{
    public class Tile : MonoBehaviour
    {
        private static float MAX_TILES = 2048f;

        public int Index;
        public bool Walkable;
        public Cell cell;// = new Cell();



        // Use this for initialization
        void Start()
        {
            UpdateZ();
            UpdateIndex();
            cell = new Cell(transform.localPosition);
            //cell.Vector3 = transform.localPosition;

        }
	
        // Update is called once per frame
        void Update()
        {
	
        }

        private void UpdateIndex()
        {
            //   cell = new Cell(transform.localPosition);
        }

        private void UpdateZ()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, GetZ());//-childLocalPosition.x / 1024 - childLocalPosition.y);
        }

        private float GetZ()
        {
            return -transform.localPosition.x / MAX_TILES - transform.localPosition.y;
        }

        /*
        public int GetCellX()
        {
            return (int)(transform.localPosition.x / 16);
        }

        public int GetCellY()
        {
            return (int)(transform.localPosition.y / 16);
        }
        */

        /*
        public Vector3 GetCell()
        {
            return new Vector3(Mathf.Round(transform.localPosition.x / 16), Mathf.Round(transform.localPosition.y / 16), transform.localPosition.z);
        }

        public static bool IsEqualCells(Vector3 v0, Vector3 v1)
        {
            return v0.x == v1.x && v0.y == v1.y;
        }

        public static Vector3 GetCell(Vector3 position)
        {
            return new Vector3(Mathf.Round(position.x / 16), Mathf.Round(position.y / 16), position.z);
        }

        public static bool IsEqualCell(Vector3 v)
        {
            Vector3 cell = GetCell();

            return cell.x == v.x && cell.y == v.y;
        }
        */

        /*
        public static int GetCellX(float x)
        {
            return (int)(x / 16);
        }

        public static int GetCellY(float y)
        {
            return (int)(y / 16);
        }
        */

        /*
		public bool Walkable {
			get {
				return true;
			}
		}

		public bool Talkable {
			get {
				return false;
			}
		}
		*/
    }
}

using UnityEngine;
using System.Collections;
using DG.Tweening;
using com.flashunity.realms.sprites;
using com.flashunity.realms.tiles;

namespace com.flashunity.realms.person
{
    public class Person : MonoBehaviour
    {
        private int state = PersonStates.WAIT;

        public float TweenDuration = 0.5f;
        public Transform Tiles;

        public Cell cell = new Cell();//transform.localPosition);

        void Start()
        {
            ActiveChildName = "Front";
        }
	
        void Update()
        {
            UpdateInput();
        }

        private void UpdateInput()
        {
            if (state == PersonStates.WAIT)
            {

                if (Input.GetKey(KeyCode.RightArrow))
                { 
                    Walk(new Cell(1, 0));
                    return;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Walk(new Cell(- 1, 0));
                    return;
                }
		
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Walk(new Cell(0, 1));
                    return;
                }
		
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Walk(new Cell(0, - 1));
                    return;
                }

                AnimationEnabled = false;
            }
        }

	
        private string ActiveChildName
        {
            set
            {
                for (int i=0; i<transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);

                    child.gameObject.SetActive(child.name == value);
                }
            }
        }

        private Transform ActiveChild
        {
            get
            {
                for (int i=0; i<transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
					
                    if (child.gameObject.activeSelf)
                    {
                        return child;	
                    }
                }
                return null;
            }
        }

        private bool AnimationEnabled
        {
            set
            {
                Transform child = ActiveChild;
				
                if (child)
                {
                    SpritesAnim spritesAnim = child.gameObject.GetComponent("SpritesAnim") as SpritesAnim;
                    spritesAnim.AnimationEnabled = value;
                }

            }
        }

        /*
        private Vector3 Direction
        {
            set
            {
                if (value.x > 0)
                {
                    ActiveChildName = "Right";
                    return;
                }
                if (value.x < 0)
                {
                    ActiveChildName = "Left";
                    return;
                }
                if (value.y > 0)
                {
                    ActiveChildName = "Back";
                    return;
                }
                if (value.y < 0)
                {
                    ActiveChildName = "Front";
                    return;
                }
            }
        }
        */

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

        private void Walk(Cell directionCell)
        {
//            Vector3 cellPosition = cell.SetPosition(transform.localPosition);
//            Vector3 cellDirection = new Vector3(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y), Mathf.Round(transform.localPosition.z));

            //      Vector3 positionRound = new Vector3(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y), Mathf.Round(transform.localPosition.z));

//            Cell cell


            cell.Vector3 = transform.localPosition;

            Cell toCell = new Cell(cell + directionCell);


//            cellDirection = cell + vector;

            Transform tile = GetTile(toCell);

            //    Debug.Log("tile: " + tile);

            //    return;

            ActiveChildName = directionCell.Direction;

            //    Direction = cellDirection - cell;//transform.localPosition;

            if (tile)
            {
                Tile tileScript = tile.GetComponent("Tile") as Tile;

                if (tileScript.Walkable)
                {
                    state = PersonStates.WALK;
                    AnimationEnabled = true;

                    Vector3 toPosition = new Vector3(toCell.Vector3.x, toCell.Vector3.y, transform.localPosition.z);

//                    Tween(toCell.Vector3);
                    Tween(toPosition);
                } else
                {
                    AnimationEnabled = false;
                }
            } else
            {
                AnimationEnabled = false;
            }
        }

        private Transform GetTile(Cell cell)
        {
            //   Debug.Log("cell: " + cell);

            if (Tiles)
            {
                for (int i=0; i<Tiles.childCount; i++)
                {
                    Transform tile = Tiles.GetChild(i);

                    Tile tileScript = tile.GetComponent("Tile") as Tile;


                    //       if (tileScript == null)
                    //     {
                    //    Debug.Log("tile" + tile);
                    //Debug.Log("tileScript.cell: " + tileScript.cell);
                    //   }
                    //Debug.Log("tileScript.cell: " + tileScript.cell);

                    /*
                    if (tileScript == null || tileScript.cell == null)
                    {
                        Debug.Log("tileScript.cell: " + tileScript.cell);
                    }
                    */



                    if (cell != null && tileScript != null && tileScript.cell == cell)
                    {
                        return tile;
                    }




                }
            }

            return null;
        }

//		private bool Walkable(Tra)

        private void Tween(Vector3 position)
        {
//			Vector3 dPosition = position - transform.localPosition;
//
//			Direction = dPosition;

//			DOTween.Kill (transform);

            // position.z = -100;

            transform.DOLocalMove(position, TweenDuration).SetEase(Ease.Linear).OnComplete(OnEndTween);
        }

        private void OnEndTween()
        {
            state = PersonStates.WAIT;
        }
    }
}

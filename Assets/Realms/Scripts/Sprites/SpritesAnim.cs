using UnityEngine;
using System.Collections;
//using System.Timers;

namespace com.flashunity.realms.sprites
{
    public class SpritesAnim : MonoBehaviour
    {
        public float Delay = 0.15f;
        private int childIndex = -1;
        private bool _animationEnabled = true; 
        //	private Timer _timer = new Timer ();

        // Use this for initialization
        void Start()
        {
            ChildIndex = 0;

            StartCoroutine("SwitchSprite");

            /*
		_timer.Interval = 1000f;//Delay;// * 1000f;

		_timer.Elapsed += new ElapsedEventHandler (_timer_Elapsed);
		_timer.Enabled = true; // Enable it
		_timer.Start ();
		*/
        }

        public bool AnimationEnabled
        {
            get
            {
                return _animationEnabled;
            }
            set
            {
                _animationEnabled = value;

                if (!_animationEnabled)
                {
                    ChildIndex = 0;
                }
            }
        }
        /*
		public void DisableAnimation ()
		{
			running = false;
		}

		public void EnableAnimation ()
		{
			running = true;
		}
		*/

        void OnDisable()
        {
            //print("script was removed");
        }

        void OnEnable()
        {
            _animationEnabled = true;
            StartCoroutine("SwitchSprite");

            //Debug.Log ("OnEnable");
            //print("script was removed");
        }

        void Awake()
        {
            //ChildIndex = 0;
            /*
			_timer.Interval = 1000f;//Delay;// * 1000f;

			_timer.Elapsed += OnTimerElapsed;
			_timer.Enabled = true; // Enable it
			//	_timer.Start ();
*/

        }

        /*
		private void OnTimerElapsed (object source, ElapsedEventArgs ee)
		{
			if (isActiveAndEnabled) {
				if (ChildIndex == transform.childCount - 1) {
					ChildIndex = 0;
				} else {
					ChildIndex++;
				}
			}
			//	_l.Add (DateTime.Now); // Add date on each timer event
		}
		*/
        //StartCoroutine ("SwitchSprite");

	
        // Update is called once per frame
        void Update()
        {
	
        }

        private int ChildIndex
        {
            set
            {
                if (childIndex != value)
                {
                    childIndex = value;

                    for (int i=0; i<transform.childCount; i++)
                    {
                        Transform child = transform.GetChild(i);

                        child.gameObject.SetActive(i == value);
                    }
                }
            }

            get
            {
                return childIndex;
            }

        }


        private IEnumerator SwitchSprite()
        {
            if (_animationEnabled)
            {
                if (ChildIndex == transform.childCount - 1)
                {
                    ChildIndex = 0;
                } else
                {
                    ChildIndex++;
                }
            }
		
            yield return new WaitForSeconds(Delay);
            StartCoroutine("SwitchSprite");
        }
	
    }
}

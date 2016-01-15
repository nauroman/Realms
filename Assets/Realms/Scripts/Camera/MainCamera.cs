using UnityEngine;
using System.Collections;
using DG.Tweening;


namespace com.flashunity.realms.camera
{
    public class MainCamera : MonoBehaviour
    {
        public Transform target;

        // Use this for initialization
        void Start()
        {
            if (target)
            {
                transform.localPosition = TargetPosition;
            }
	
        }
	
        // Update is called once per frame
        void Update()
        {
            //		transform.localPosition = new Vector3 (transform.localPosition.x - 0.01f, transform.localPosition.y - 0.005f, transform.localPosition.z);
            if (target != null)
            {

			
                Tween(TargetPosition);

            }
        }

        private Vector3 TargetPosition
        {
            get
            {
                return target != null ? new Vector3(target.localPosition.x + 0.5f, target.localPosition.y + 0.5f, transform.localPosition.z) : new Vector3(0, 0, 0.2f);
            }

        }

        private void Tween(Vector3 position)
        {
//			Vector3 dPosition = position - transform.localPosition;
			
            //transform.DOLocalMove (position, 0.1f).SetEase (Ease.InOutCirc);
            transform.DOLocalMove(position, 0.2f);
        }
    }
}

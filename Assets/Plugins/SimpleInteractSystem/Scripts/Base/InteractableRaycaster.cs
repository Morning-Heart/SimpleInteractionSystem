using System;
using UnityEngine;

namespace SimpleInteractSystem
{
    public class InteractableRaycaster : MonoBehaviour
    {
        public InteractControl control;
        public LayerMask interactableMask;
        public GameObject mainPlayer;

        public QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Collide;

        private void Start()
        {
            if (mainPlayer == null)
            {
                mainPlayer = GameObject.FindGameObjectWithTag("Player");
            }
        }

        private void Update()
        { 
                Vector2 vTouchPos = Input.mousePosition; 
                // The ray to the touched object in the world
                Ray ray = Camera.main.ScreenPointToRay(vTouchPos); 
                // Your raycast handling
                RaycastHit vHit;
                if (Physics.Raycast(ray.origin, ray.direction, out vHit,10000,interactableMask.value,queryTriggerInteraction))
                {
                    OnGetRayCast(vHit);
                }
                // no raycast target, close the previous opened ui
                else 
                {
                    control.InteractableTargetMiss();
                } 
        }

        public void OnGetRayCast(RaycastHit vHit)
        {
            
            var interactable =
                vHit.collider.gameObject.GetComponent<Interactable>();
            if (interactable!=null && interactable.IsInteractableWith(mainPlayer))
            {
                control.DetectInteractable(interactable);  
            }
        }
    }
}
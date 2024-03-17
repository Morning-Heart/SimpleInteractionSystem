using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SimpleInteractSystem
{
    // criteria that decides if it's interactable
    public enum InteractableCheck
    {
        BOOLEAN,DISTANCE,METHOD
    }
    public class Interactable : MonoBehaviour
    {
        public string displayName;
        [SerializeReference]
        public List<InteractOption> options;


        public InteractableCheck InteractableCheck  = InteractableCheck.BOOLEAN;
        public float InteractableDistance = 1.0f;
        [SerializeField] private bool _isInteractable = true;
        public virtual bool IsCurrentlyInteractable(GameObject go)
        {
            // Can be decided by the distance to the player
            return true;
        }


        public UnityEvent onDetected;
        public UnityEvent onEnterInteract;
        public UnityEvent onExitInteract;
        public UnityEvent onMissAsTarget;

        public Action<InteractOption> OnOptionInteractStart;
        public Action<InteractOption> OnOptionInteractComplete;


        public void SetOptionUsable(int optionIndex, bool isUsable)
        {
            if (options.Count > optionIndex || options[optionIndex]!=null)
            {
                options[optionIndex].isUsable = isUsable;
            }
        }
        private void OnEnable()
        {
            gameObject.layer = LayerMask.NameToLayer("Interactable");
        }

        public void MissDetect()
        {
            onMissAsTarget?.Invoke();
        }

        public void GetDetected()
        {
            onDetected?.Invoke();
        }

        public async void OnSelectToInteract(InteractOption option)
        {
            if (options.Contains(option) == false)
            {
                Debug.LogWarningFormat("Interactable {0} has no option {1} but still try to interact it",this.name,option.displayName);
                return;
            }
            OnOptionInteractStart?.Invoke(option);
            await option.OnInteract();
            OnOptionInteractComplete?.Invoke(option);
        }

        public void OnEnterInteract()
        {
            onEnterInteract?.Invoke();
        }
        public void OnExitInteract()
        {
            onExitInteract?.Invoke();
        }

        public bool IsInteractableWith(GameObject go)
        {
            if (!enabled)
            {
                return false;
                
            }
            
            if (InteractableCheck==InteractableCheck.METHOD)
            {
                return IsCurrentlyInteractable(go);
            }
            else if (InteractableCheck == InteractableCheck.DISTANCE)
            {
                return Vector3.Distance(go.transform.position, transform.position)<= InteractableDistance;
            }else
            {
                return _isInteractable;
            }
        }
    }
}
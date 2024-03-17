using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SimpleInteractSystem
{
    public enum InteractState
    {
        Free,Detected,Interacting
    }

    public class InteractControl : MonoBehaviour
    {



        public InteractableUIPanel UIPanel;

        public UnityEvent OnInteractableDetected;
        public UnityEvent OnEnterInteract, OnExitInteract;
        public UnityEvent OnInteractTargetMiss;
        private Interactable _currentInteractable;

        // For external reference to know what's interacted
        public Interactable CurrentInteractable
        {
            get => _currentInteractable;
        }

        private  InteractState currentInteractState = InteractState.Free; 

        public UnityEvent onOptionInteractStart;
        public UnityEvent onOptionInteractComplete;

        public bool ExitOnOptionInteractComplete = true;
        public void DetectInteractable(Interactable interactable)
        {
            if (currentInteractState == InteractState.Interacting)
            {
                Debug.LogWarning("Is now interacting but still try to Interact");
                return;
            }

            if (_currentInteractable != interactable && _currentInteractable!=null)
            {
                _currentInteractable.MissDetect();
            }
            
            if (interactable!=null)
            {
                _currentInteractable = interactable;
                _currentInteractable.GetDetected();
                OnInteractableDetected?.Invoke();
                currentInteractState = InteractState.Detected;
            }
            else
            {
                Debug.LogWarning("There's no Interactable but still try to Interact");
            }
        }

        public void InteractableTargetMiss()
        {
            if (currentInteractState == InteractState.Detected)
            {
                _currentInteractable.MissDetect();
                _currentInteractable = null;
                OnInteractTargetMiss?.Invoke();
                currentInteractState = InteractState.Free;
            }
        }

        public void EnterInteract()
        {
            if (currentInteractState == InteractState.Detected)
            {
                OnEnterInteract?.Invoke();
                _currentInteractable.OnEnterInteract();
                _currentInteractable.OnOptionInteractStart += OnOptionInteractStart;
                _currentInteractable.OnOptionInteractComplete += OnOptionInteractComplete;
                UIPanel.ShowOptionMenu(_currentInteractable);
                currentInteractState = InteractState.Interacting;
            }
        }

        public void OnOptionInteractStart(InteractOption interactOption)
        {
            UIPanel.HideOptionMenu();
            if (interactOption.useInteractingUI)
            {
                UIPanel.SetInteractingUIActive(true);
            }
            else
            {
                UIPanel.SetInteractingUIActive(false);
            }
            onOptionInteractStart?.Invoke();
        }

        public void OnOptionInteractComplete(InteractOption interactOption)
        {
            UIPanel.ShowOptionMenu(_currentInteractable);
            UIPanel.SetInteractingUIActive(false);
            onOptionInteractComplete?.Invoke();
            if (ExitOnOptionInteractComplete)
            {
                ExitInteract();
            }
        }
        public void ExitInteract()
        {
            if (currentInteractState == InteractState.Interacting)
            {
                OnExitInteract?.Invoke();
                _currentInteractable.OnExitInteract();
                _currentInteractable.OnOptionInteractStart -= OnOptionInteractStart;
                _currentInteractable.OnOptionInteractComplete -= OnOptionInteractComplete;
                UIPanel.HideOptionMenu();
                UIPanel.HideUIPanel();
                currentInteractState = InteractState.Free;
            }
        }
    }
}
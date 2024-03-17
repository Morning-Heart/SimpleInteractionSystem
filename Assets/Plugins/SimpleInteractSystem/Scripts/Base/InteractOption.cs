using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SimpleInteractSystem
{
    [System.Serializable]
    public class InteractOption
    {
        public bool isUsable = true;
        public string displayName;
        public string hintInfo;
        // Show Interacting UI on Interact Start and close it when InteractComplete
        public bool useInteractingUI=true;
        public UnityEvent OnInteractStart;
        public UnityEvent OnInteractEnd;

        protected virtual void InteractStart()
        {
            OnInteractStart?.Invoke();
        }
        protected virtual void InteractComplete()
        {
            OnInteractEnd?.Invoke();
        }

        public async Task OnInteract()
        {
            InteractStart();
            Task interactTask = Interact();
            if (interactTask != null)
            {
                await interactTask;
            }
            InteractComplete();
        }
        protected async virtual Task Interact()
        {
            await Task.Yield();
        }
    }
}
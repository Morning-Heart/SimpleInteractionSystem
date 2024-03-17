using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleInteractSystem
{
    public class InteractableUIWorld : MonoBehaviour
    {
        // Start is called before the first frame update

        public Interactable interactable;
        public TextMeshProUGUI nameText;
        public RectTransform UIRectParent;
        // public UnityEvent onHide,onShow;
        public bool alwaysFaceCamera = true;
        void Start()
        {
            Setup();
        }

        private void Setup()
        {
            nameText.SetText(interactable.displayName);
        }

        private void Update()
        {
            if(alwaysFaceCamera)
            {
                UIRectParent.transform.LookAt(Camera.main.transform);
                UIRectParent.transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
            }
        }

        public void Hide()
        {
            UIRectParent.gameObject.SetActive(false);
            // onHide?.Invoke();
        }

        public void Show()  
        {
            UIRectParent.gameObject.SetActive(true);
            // onShow?.Invoke();
        }
    }
}

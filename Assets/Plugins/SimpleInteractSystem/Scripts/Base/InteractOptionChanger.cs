using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SimpleInteractSystem
{
    [RequireComponent(typeof(Collider))]
    public class InteractOptionChanger : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        [SerializeField] private bool optionUsable = false;
        [SerializeField] private int optionIndex = -1;
        private void Awake()
        {
            _collider = GetComponent<Collider>();
            if (_collider != null)
            {
                _collider.isTrigger = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.SetOptionUsable(optionIndex,optionUsable);
            }
        }
    }
}
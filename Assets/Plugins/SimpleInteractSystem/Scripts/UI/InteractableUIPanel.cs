using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace SimpleInteractSystem
{
    public class InteractableUIPanel : MonoBehaviour
    {
        // Start is called before the first frame update

        public TextMeshProUGUI nameText;
        public InteractOptionUI optionUIPrefab;
        public RectTransform optionUIParent;

        public GameObject CanvasUI;
        public RectTransform optionMenu;
        public RectTransform interactingUI;
        private List<InteractOptionUI> _optionUis = new List<InteractOptionUI>();

        private Interactable _interactable;

        public void SetInteractingUIActive(bool isActive)
        {
            interactingUI.gameObject.SetActive(isActive);
        }

        public void ShowUIPanel()
        {
            CanvasUI.SetActive(true);
        }
        public void HideUIPanel()
        {
            CanvasUI.SetActive(false);
        }
        public void ShowOptionMenu(Interactable interactable)
        {
            ShowUIPanel();
            _interactable = interactable;
        
            nameText.SetText(_interactable.displayName);
            if (_optionUis == null)
            {
                _optionUis = new List<InteractOptionUI>();
            }
            foreach (var option in interactable.options)
            {
                if (!option.isUsable)
                {
                    continue;
                }
                InteractOptionUI optionUI = Instantiate(optionUIPrefab,optionUIParent);
                optionUI.Setup(interactable,option);
                _optionUis.Add(optionUI);
            }
        
        
        
            optionMenu.gameObject.SetActive(true);
        }

        public void HideOptionMenu()
        {
            // remove last interactable's hooked events
            if (_interactable==null)
            {
                return;
            }
            _interactable = null;
            if (_optionUis != null)
            {
            
                for (int i = 0; i < _optionUis.Count; i++)
                {
                    DestroyImmediate(_optionUis[i].gameObject);
                }
                _optionUis.Clear();
           
            }
            optionMenu.gameObject.SetActive(false);
        }

    }
}

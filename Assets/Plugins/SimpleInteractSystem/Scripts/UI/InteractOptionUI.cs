using SimpleInteractSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleInteractSystem
{
    public class InteractOptionUI:MonoBehaviour
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI tipText;
        public Button selectButton;

        public void Setup(Interactable interactable, InteractOption option)
        {
            nameText.SetText(option.displayName);
            tipText.SetText(option.hintInfo);
            selectButton.onClick.RemoveAllListeners();
            selectButton.onClick.AddListener(() =>
            {
                interactable.OnSelectToInteract(option);
            });
        }
    }
}
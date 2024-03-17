using UnityEngine;

namespace SimpleInteractSystem
{
    public class InteractInputListener : MonoBehaviour
    {

        public InteractControl interact;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interact.EnterInteract();
            }
        }
    }
}

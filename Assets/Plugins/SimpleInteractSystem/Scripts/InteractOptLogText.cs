using System.Threading.Tasks;
using UnityEngine;

namespace SimpleInteractSystem
{
    [System.Serializable]
    public class InteractOptLogText : InteractOption
    {
        public float delay = 0;
        public string textToLog;
        protected override async Task Interact()
        {
            if (delay > 0)
            {
                await Task.Delay((int)(delay * 1000));
            }
            Debug.Log(" InteractOptLogText : "+textToLog);
        }
    }
}
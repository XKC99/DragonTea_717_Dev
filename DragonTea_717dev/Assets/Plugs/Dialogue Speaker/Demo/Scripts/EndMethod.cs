using UnityEngine;

namespace DialogueSpeakerSpace
{
    public class EndMethod : MonoBehaviour
    {
        public DialogueSpeaker[] ds;
        public GameObject text;
        

        void Update()
        {
            // check if all dialogue speakers have finished and enable the text
            foreach (var item in ds) {
                if (!item.isFinished) {
                    text.SetActive(false);
                    return;
                }
            }


            text.SetActive(true);
        }
    }
}

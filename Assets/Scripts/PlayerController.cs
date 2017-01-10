using UnityEngine;
using UnityEngine.Networking;

namespace AugmentedRPS
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField]
        private string m_Canvas;

        [SerializeField]
        private GameObject m_CanvasChild;

        private void Start()
        {
            if (!isLocalPlayer)
            {
                return;
            }

            GameObject GO = Instantiate(m_CanvasChild);
            GO.transform.SetParent(GameObject.Find(m_Canvas).transform);

            RectTransform rectTransform = GO.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0f, 0f);
            rectTransform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
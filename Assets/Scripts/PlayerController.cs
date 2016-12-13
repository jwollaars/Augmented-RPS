using UnityEngine;
using UnityEngine.Networking;

namespace AugmentedRPS
{
    public class PlayerController : NetworkBehaviour
    {
        private GameObject m_Canvas;

        [SerializeField]
        private GameObject m_CanvasChild;

        private void Awake()
        {
            m_Canvas = GameObject.Find("Canvas");
        }

        private void Start()
        {
            GameObject GO = Instantiate(m_CanvasChild);
            GO.transform.SetParent(m_Canvas.transform);
        }
    }
}
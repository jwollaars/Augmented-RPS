using UnityEngine;
using UnityEngine.Networking;

namespace ARRockPaperScissor
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField]
        private GameObject m_Canvas;
        [SerializeField]
        private GameObject m_EventSystem;

        [SerializeField]
        private GameObject[] m_CardsPreview = new GameObject[3];
        [SerializeField]
        private GameObject[] m_CardsPlaceable = new GameObject[3];

        [SerializeField]
        private NetworkIdentity m_NetworkIdentity;

        private int m_CurrentCard = 0;

        public override void OnStartLocalPlayer()
        {
            m_Canvas.SetActive(true);
            m_EventSystem.SetActive(true);
        }

        private void ShowCard(int index)
        {
            if (!isLocalPlayer)
            {
                return;
            }

            for (int i = 0; i < m_CardsPreview.Length; i++)
            {
                m_CardsPreview[i].SetActive(false);
            }

            m_CardsPreview[index].SetActive(true);
        }

        public void PreviousCard()
        {
            if (!isLocalPlayer)
            {
                return;
            }

            if (m_CurrentCard > 0)
            {
                m_CurrentCard -= 1;
            }
            else if (m_CurrentCard == 0)
            {
                m_CurrentCard = m_CardsPreview.Length - 1;
            }

            ShowCard(m_CurrentCard);
        }

        public void NextCard()
        {
            if (!isLocalPlayer)
            {
                return;
            }

            if (m_CurrentCard < m_CardsPreview.Length - 1)
            {
                m_CurrentCard += 1;
            }
            else if (m_CurrentCard == m_CardsPreview.Length - 1)
            {
                m_CurrentCard = 0;
            }

            ShowCard(m_CurrentCard);
        }

        [Command]
        public void CmdPlaceCard()
        {
            if (m_NetworkIdentity.netId.ToString() == "1")
            {
                GameObject card = Instantiate(m_CardsPlaceable[m_CurrentCard], new Vector3(0f, 0.25f, -3f), Quaternion.identity);

                NetworkServer.Spawn(card);
            }
            else if (m_NetworkIdentity.netId.ToString() == "2")
            {
                GameObject card = Instantiate(m_CardsPlaceable[m_CurrentCard], new Vector3(0f, 0.25f, 3f), Quaternion.identity);

                NetworkServer.Spawn(card);
            }
        }
    }
}
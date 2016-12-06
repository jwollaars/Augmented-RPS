using UnityEngine;

namespace AugmentedRPS
{
    public class ChooseACard : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] m_Cards = new GameObject[3];
        [SerializeField]
        private GameObject[] m_CardsPreview = new GameObject[3];

        private int m_CurrentCard = 0;

        private void ShowCard(int index)
        {
            for (int i = 0; i < m_CardsPreview.Length; i++)
            {
                m_CardsPreview[i].SetActive(false);
            }

            m_CardsPreview[index].SetActive(true);
        }

        public void PreviousCard()
        {
            if (m_CurrentCard > 0)
            {
                m_CurrentCard -= 1;
            }
            else if (m_CurrentCard == 0)
            {
                m_CurrentCard = 2;
            }

            ShowCard(m_CurrentCard);
        }

        public void NextCard()
        {
            if (m_CurrentCard < 2)
            {
                m_CurrentCard += 1;
            }
            else if (m_CurrentCard == 2)
            {
                m_CurrentCard = 0;
            }

            ShowCard(m_CurrentCard);
        }

        public void PlaceCard()
        {
            GameObject card = (GameObject)Instantiate(m_Cards[m_CurrentCard], new Vector3(0f, 0.5f, 0f), Quaternion.identity);
        }
    }
}
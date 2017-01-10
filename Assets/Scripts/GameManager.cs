using UnityEngine;
using UnityEngine.Networking;

namespace ARRockPaperScissor
{
    public class GameManager : NetworkBehaviour
    {
        private int m_MaxPlayers = 2;

        public override void OnStartServer()
        {
            Network.maxConnections = m_MaxPlayers;
        }
    }
}
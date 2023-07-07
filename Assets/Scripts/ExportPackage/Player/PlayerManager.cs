using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameSystem
{
    using Player;
    public class PlayerManager : Singleton.Singleton<PlayerManager>
    {
        PlayerInputs m_playerInputs;
        PlayerController m_playerController;
        PlayerRaycast m_playerRaycast;
        PlayerStatus m_playerStatus;

        public PlayerInputs m_PlayerInputs => m_playerInputs;
        public PlayerController m_PlayerController => m_playerController;
        public PlayerRaycast m_PlayerRaycast => m_playerRaycast;
        public PlayerStatus m_PlayerStatus => m_playerStatus;
    }
}
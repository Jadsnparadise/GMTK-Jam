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
        CapsuleCollider m_collider;
        Rigidbody m_rig;

        public PlayerInputs m_PlayerInputs => m_playerInputs;
        public PlayerController m_PlayerController => m_playerController;
        public PlayerRaycast m_PlayerRaycast => m_playerRaycast;
        public PlayerStatus m_PlayerStatus => m_playerStatus;
        public CapsuleCollider m_Collider => m_collider;
        public Rigidbody m_Rig => m_rig;

        protected override void Awake()
        {
            base.Awake();
            m_playerInputs ??= GetComponent<PlayerInputs>();
            m_playerController ??= GetComponent<PlayerController>();
            m_playerRaycast ??= GetComponent<PlayerRaycast>();
            m_playerStatus ??= GetComponent<PlayerStatus>();
            m_collider ??= GetComponent<CapsuleCollider>();
            m_rig ??= GetComponent<Rigidbody>();
        }
    }
}
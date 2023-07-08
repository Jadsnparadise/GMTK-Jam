using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameSystem.Player
{
    public class PlayerStatus : MonoBehaviour
    {
        PlayerManager m_playerManager;
        bool m_hide;
        Vector3 m_enterPosition;
        int m_currentKeys;
        public int m_CurrentKeys => m_currentKeys;

        public bool m_Hide => m_hide;

        public void Start()
        {
            m_playerManager = PlayerManager.Instance;
            m_hide = false;
        }

        void SetHide(bool hide)
        {
            m_hide = hide;
            m_playerManager.m_PlayerController.SetCanMove(!m_hide);
        }

        public void EnterHideSpot(Transform hideSpot)
        {
            m_enterPosition = transform.position;
            m_playerManager.m_Collider.enabled = false;
            m_playerManager.m_Rig.useGravity = false;
            SetHide(true);
            m_playerManager.transform.position = hideSpot.position;
        }

        public void ExitHideSpot()
        {
            m_playerManager.m_Collider.enabled = true;
            m_playerManager.m_Rig.useGravity = true;
            SetHide(false);
            m_playerManager.transform.position = m_enterPosition;
        }

        public void AddKey()
        {
            m_currentKeys++;
        }

        public void UseKey()
        {
            m_currentKeys--;
        }

        public bool HasKey()
        {
            return m_currentKeys > 0;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameSystem.Interact
{
    public class Hider : MonoBehaviour, IInteract
    {
        PlayerManager m_playerManager;
        [SerializeField] Transform m_hidePosition;
        Vector3 m_enterPosition;
        private void Start()
        {
            m_playerManager = PlayerManager.Instance;
            m_hidePosition ??= transform.GetChild(0);
        }
        public void Interact()
        {
            bool isHide = m_playerManager.m_PlayerStatus.m_Hide;

            if (isHide)
            {
                ExitHide();
            }
            else
            {
                EnterHide();
            }
        }

        void EnterHide()
        {
            m_playerManager.m_PlayerStatus.EnterHideSpot(m_hidePosition);
        }

        void ExitHide()
        {
            m_playerManager.m_PlayerStatus.ExitHideSpot();
        }
    }
}


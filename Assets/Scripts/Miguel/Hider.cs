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
            m_enterPosition = m_playerManager.transform.position;
            m_playerManager.m_Collider.enabled = false;
            m_playerManager.m_Rig.useGravity = false;
            m_playerManager.m_PlayerStatus.SetHide(true);
            
            m_playerManager.transform.position = m_hidePosition.position;
        }

        void ExitHide()
        {
            m_playerManager.m_Collider.enabled = true;
            m_playerManager.m_Rig.useGravity = true;
            m_playerManager.m_PlayerStatus.SetHide(false);
            m_playerManager.transform.position = m_enterPosition;
        }
    }
}


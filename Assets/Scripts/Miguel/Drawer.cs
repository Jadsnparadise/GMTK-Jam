using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

namespace Game.GameSystem.Interact
{
    public class Drawer : MonoBehaviour, IInteract
    {
        [SerializeField, Range(0, 10)] float m_animTime;
        [SerializeField] float m_zPositionBuff;
        Vector3 m_openedPosition;
        Vector3 m_closedPosition;
        [SerializeField] EventReference m_openAudio;
        [SerializeField] EventReference m_closeAudio;

        bool m_opened = false;
        private void Start()
        {
            m_opened = false;
            m_closedPosition = transform.position;
            m_openedPosition.Set(m_closedPosition.x, m_closedPosition.y, m_closedPosition.z + m_zPositionBuff);
        }

        void Update()
        {
            Vector3 newPosition = m_opened ? m_openedPosition : m_closedPosition;
            transform.position = Vector3.Lerp(transform.position, newPosition, m_animTime * Time.deltaTime);
        }

        public virtual void Interact()
        {
            ChangeState();
        }

        void ChangeState()
        {
            if (m_opened)
            {
                Close();
            }
            else
            {
                Open();
            }
        }

        void Open()
        {
            m_opened = true;
            RuntimeManager.PlayOneShot(m_openAudio);
        }

        void Close()
        {
            m_opened = false;
            RuntimeManager.PlayOneShot(m_closeAudio);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

namespace Game.GameSystem.Interact 
{
    public class Door : MonoBehaviour, IInteract
    {
        [SerializeField, Range(0, 10)] float m_animTime;
        [SerializeField] Vector3 m_openedAngle;
        [SerializeField] Vector3 m_closedAngle;
        [SerializeField] Transform m_doorPivot;
        [SerializeField] EventReference m_openAudio;
        [SerializeField] EventReference m_closeAudio;
        [SerializeField] bool m_locked;

        bool m_opened = false;
        private void Start()
        {
            m_opened = false;
        }

        void Update()
        {
            Vector3 newAngle = m_opened ? m_openedAngle : m_closedAngle;
            m_doorPivot.eulerAngles = Vector3.Lerp(m_doorPivot.eulerAngles, newAngle, m_animTime * Time.deltaTime);
        }

        public virtual void Interact()
        {
            if (m_locked)
            {
                if (!PlayerManager.Instance.m_PlayerStatus.HasKey())
                {
                    return;
                }
                PlayerManager.Instance.m_PlayerStatus.UseKey();
                m_locked = false;
            }
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
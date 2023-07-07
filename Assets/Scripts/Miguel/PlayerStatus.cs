using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameSystem.Player
{
    public class PlayerStatus : MonoBehaviour
    {
        bool m_hide;

        public bool m_Hide => m_hide;

        public void Start()
        {
            m_hide = false;
        }

        public void SetHide(bool hide)
        {
            m_hide = hide;
        }
    }
}


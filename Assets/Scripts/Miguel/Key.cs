using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameSystem.Interact 
{
    public class Key : MonoBehaviour, IInteract
    {
        public void Interact()
        {
            PlayerManager.Instance.m_PlayerStatus.AddKey();
            Destroy(gameObject);
        }
    }
}
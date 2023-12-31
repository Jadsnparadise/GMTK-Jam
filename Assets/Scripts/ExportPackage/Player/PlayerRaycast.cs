using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameSystem.Player
{
    public class PlayerRaycast : MonoBehaviour
    {
        [Header("Input Manager")]
        [SerializeField] PlayerInputs playerInputManager;

        [Header("Raycast Settings")]
        [SerializeField] Transform camPos;
        [SerializeField] float raycastDistance = 10f;
        RaycastHit hit;
        [SerializeField] LayerMask hitLayerMask;
        
#if UNITY_EDITOR
        [Header("Gizmos Settings")]
        [SerializeField] Color colorInHit = Color.green;
        [SerializeField] Color colorOutHit = Color.red;
#endif
        private void Awake()
        {
            playerInputManager ??= gameObject.TryGetComponent(out PlayerInputs _newPlayerInput) ? _newPlayerInput : gameObject.AddComponent<PlayerInputs>();
        }

        void Update()
        {
            if (playerInputManager.InteractKeycodePressed())
            {
                if (PlayerManager.Instance.m_PlayerStatus.m_Hide)
                {
                    PlayerManager.Instance.m_PlayerStatus.ExitHideSpot();
                    return;
                }
            }
            if (!InteractLogic()) return;
            PlayerInteract();
        }

        bool InteractLogic()
        {
            //if (!Input.GetKeyDown(interactKeycode)) return false;
            //if (hit.transform == null) return false;
            //return true
            return (playerInputManager.InteractKeycodePressed() && hit.transform != null); 
        }

        void PlayerInteract()
        {
            if (hit.transform.TryGetComponent(out Interact.IInteract _component))
            {
                _component.Interact();
            }
        }

        private void FixedUpdate()
        {
            Physics.Raycast(camPos.position, camPos.transform.forward, out hit, raycastDistance, hitLayerMask);
#if UNITY_EDITOR
            Debug.DrawRay(camPos.position, camPos.transform.forward * raycastDistance, hit.transform == null ? colorOutHit : colorInHit);
#endif
        }
    }
}

namespace Game.GameSystem.Interact
{
    public interface IInteract
    {
        void Interact();
    }
}
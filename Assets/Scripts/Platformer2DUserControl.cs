using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets._2D
{
    
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public bool m_Attack;
        public bool joinable;

        
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void FixedUpdate()
        {
            m_Jump = false;
            m_Attack = false;
            joinable = false;

            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            if (v < -0.9)
                joinable = true;

            if (!m_Attack)
                m_Attack = CrossPlatformInputManager.GetButtonDown("Attack");

            if (m_Attack && !joinable)
                m_Character.Attack();

            if (v > 0.9)
            {
                m_Jump = true;
            }
            // Pass all parameters to the character control script.
            m_Character.Move(h, m_Jump);

        }
    }
}

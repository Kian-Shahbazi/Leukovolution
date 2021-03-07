using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

        public Joystick joystick;
        public Button jumpButton;

        private bool touchActive = false; //using touch control
        private bool kbActive = true; //using keyboard control

        float horizontal;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Start()
        {
            jumpButton.onClick.AddListener(TaskOnClick);
        }

        private void Update()
        {
            checkInputMethod(); //checks whether to use touch or keyboard

            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }
        void TaskOnClick() //Touch control
        {
            m_Jump = true;
        }
        void checkInputMethod()
        {
            if (Input.anyKey) //use keyboard when keyboard is pressed
            {
                touchActive = false;
                kbActive = true;
            }
            if (joystick.Horizontal != 0) //use touch when joystick is used
            {
                touchActive = true;
                kbActive = false;
            }
        }

        private void FixedUpdate()
        {
            if (kbActive) //use keyboard when keyboard is pressed
            {
                horizontal = CrossPlatformInputManager.GetAxis("Horizontal"); //Keyboard Control
            }
            else if (touchActive) //use touch when joystick is used
            {
                horizontal = joystick.Horizontal * 1f; //Joystick Control
            }
            
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);     

            // Pass all parameters to the character control script.
            m_Character.Move(horizontal, crouch, m_Jump);
            m_Jump = false;
        }


    }
}

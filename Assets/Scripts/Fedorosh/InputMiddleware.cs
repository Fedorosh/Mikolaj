using Fedorosh.Dying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fedorosh
{
    public class InputMiddleware
    {
        private Joystick joystick;
        private DyingObject dyingObject;

        public InputMiddleware(Joystick joystick, DyingObject dyingObject)
        {
            this.joystick = joystick;
            this.dyingObject = dyingObject;
        }

        private bool VerifyInput()
        {
            if (dyingObject.State == DyingObjectState.Dead) return false;
            return true;
        }

        public float GetAxis(string axis)
        {
            if (!VerifyInput()) return 0f;
            return Input.GetAxis(axis);
        }

        public float GetHorizontalJoystick()
        {
            if(!VerifyInput()) return 0f;
            return joystick.Horizontal;
        }

        public float GetVerticalJoystick()
        {
            if (!VerifyInput()) return 0f;
            return joystick.Vertical;
        }

        public bool GetTouch()
        {
            if (!VerifyInput()) return false;
            if (Input.touchCount == 0) return false;

            Touch touch = Input.GetTouch(Input.touchCount - 1);

            Vector2 touchPos = touch.position;
            int x = Screen.width / 2;
            return touchPos.x >= x && touch.phase == TouchPhase.Ended;
        }

        public bool GetKey(KeyCode key)
        {
            if(!VerifyInput()) return false;
            return Input.GetKey(key);
        }

        public bool GetButtonDown(string button)
        {
            if (!VerifyInput()) return false;
            return Input.GetButtonDown(button);
        }
        public bool GetKeyDown(KeyCode key)
        {
            if (!VerifyInput()) return false;
            return Input.GetKeyDown(key);
        }
    }
}

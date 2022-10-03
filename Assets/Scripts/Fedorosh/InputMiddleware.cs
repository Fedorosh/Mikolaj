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

        public bool CanUseJump => VerifyInput();

        public float GetAxis(string axis)
        {
            if (!VerifyInput()) return 0f;
            return Input.GetAxis(axis);
        }

        public float GetHorizontalJoystick()
        {
            if(!VerifyInput()) return 0f;
            if (Mathf.Abs(joystick.Horizontal) < 0.3f) return 0f;
            return joystick.Horizontal;
        }

        public float GetVerticalJoystick()
        {
            if (!VerifyInput()) return 0f;
            return joystick.Vertical;
        }

        public bool GetTouchUp(Touch touch)
        {
            //if (!VerifyInput()) return false;
            //if (Input.touchCount == 0) return false;

            //Touch touch = Input.GetTouch(Input.touchCount - 1);
            return touch.phase == TouchPhase.Ended;
        }

        public bool GetTouchUpAnywhere()
        {
            if (!VerifyInput()) return false;
            if (Input.touchCount == 0) return false;

            Touch touch = Input.GetTouch(Input.touchCount - 1);
            return touch.phase == TouchPhase.Ended;
        }

        public bool GetTouchDown(out Touch touch)
        {
            touch = default;

            if (!VerifyInput()) return false;
            if (Input.touchCount == 0) return false;

            touch = Input.GetTouch(Input.touchCount - 1);

            Vector2 touchPos = touch.position;
            int x = Screen.width / 2;
            float y = Screen.height / 3.86f;
            return touch.phase == TouchPhase.Began;
        }

        public float GetTouchAxis(Touch touch, string axis)
        {
            switch(axis)
            {
                case "Horizontal":
                    return touch.deltaPosition.x;
                case "Vertical":
                    return touch.deltaPosition.y;
                default:
                    return 0f;
            }
        }

        public bool GetTouch()
        {
            if (!VerifyInput()) return false;
            if (Input.touchCount == 0) return false;

            Touch touch = Input.GetTouch(Input.touchCount - 1);

            int x = Screen.width / 2;
            if (touch.position.x < x) return false;

            return touch.phase == TouchPhase.Stationary
                || touch.phase == TouchPhase.Moved;
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

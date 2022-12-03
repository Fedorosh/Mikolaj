using MVC.Application;
using UnityEngine;

public class InputController : BaseController
{
    public override void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
        switch(p_event_path)
        {
            case BounceNotification.JumpClicked:
                if(!app.model.IsInAir)
                {
                    app.model.IsInAir = true;
                    app.view.ball.GetComponent<Rigidbody>().AddForce(new Vector3(0,app.model.jumpHeight,0),ForceMode.Impulse);
                    Debug.Log("Jumped");
                }
                break;
        }
    }
}

using MVC.Application;
using UnityEngine;

public class KeyboardInput : BounceElement
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            app.Notify(BounceNotification.JumpClicked,this);
        }
    }
}

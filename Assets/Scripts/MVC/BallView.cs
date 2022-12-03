using MVC.Application;
using UnityEngine;

public class BallView : BounceElement
{
    // Only this is necessary. Physics is doing the rest of work.
    // Callback called upon collision.
    void OnCollisionEnter(Collision collision) { app.Notify(BounceNotification.BallHitGround, this); }
}
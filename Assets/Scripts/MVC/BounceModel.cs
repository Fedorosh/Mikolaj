using MVC.Application;
using UnityEngine;

public class BounceModel : BounceElement
{
    //Data
    public int bounces;
    public int winCondition;
    public float jumpHeight;
    public bool IsInAir { get; set; } = true;
}
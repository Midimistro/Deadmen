using System;
using System.Collections.Generic;


public class Attack
{
    public List<string> PoseLeadins = new List<string> { "Idle" };
    public int ForwardThrust = 0;

    public Attack()
    {
    }

    public Attack(bool FromIdle)
    {
        if (FromIdle)
        {
            PoseLeadins = new List<string> { "Idle" };
        } else
        {
            PoseLeadins = new List<string> { };
        }
    }

    public Attack(List<string> poseLeadins)
    {
        PoseLeadins = poseLeadins;
    }

    public Attack(List<string> poseLeadins, int forwardThrust)
    {
        forwardThrust = ForwardThrust;
    }

    public bool canTransitionTo(string goTo)
    {
        return PoseLeadins.Contains(goTo);
    }
}

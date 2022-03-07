using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrackableEventHandler : DefaultTrackableEventHandler
{
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Player player = GetComponentInChildren<Player>();

        if (player != null)
            player.enabled = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        Player player = GetComponentInChildren<Player>();

        if (player != null)
            player.enabled = false;
    }
}

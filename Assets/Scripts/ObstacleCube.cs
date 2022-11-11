using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCube : CubeObject, ICubeObject
{
    public void TouchedByPlayer(PlayerCubes playerCubes)
    {
        playerCubes.StoreHit(NumCubes);
    }
}

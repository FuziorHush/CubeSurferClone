using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : CubeObject, ICubeObject
{
    public void TouchedByPlayer(PlayerCubes playerCubes)
    {
        playerCubes.AddCubes(NumCubes);
        Destroy(gameObject);
    }
}

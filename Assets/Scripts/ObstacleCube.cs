public class ObstacleCube : CubeObject, ICubeObject
{
    public void TouchedByPlayer(PlayerCubes playerCubes)
    {
        playerCubes.StoreHit(NumCubes);
    }
}

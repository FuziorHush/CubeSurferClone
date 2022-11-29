public class CollectableCube : CubeObject, ICubeObject
{
    public void TouchedByPlayer(PlayerCubes playerCubes)
    {
        playerCubes.AddCubes(NumCubes);
        Destroy(gameObject);
    }
}

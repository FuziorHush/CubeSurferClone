using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    [SerializeField] private TurnSide _turnSide;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMoove playerMoove = other.GetComponent<PlayerMoove>();
        if (playerMoove != null) {
            playerMoove.Turn90(_turnSide);
            Destroy(gameObject);
        }
    }
}

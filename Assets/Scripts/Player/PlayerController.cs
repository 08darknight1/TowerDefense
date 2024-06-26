using UnityEngine;

public enum PlayerActionTag {IDLE, MOVING_TURRET}

public class PlayerController : MonoBehaviour
{
    public PlayerActionTag _actionTag;

    void Start()
    {
        _actionTag = PlayerActionTag.IDLE;
    }
}

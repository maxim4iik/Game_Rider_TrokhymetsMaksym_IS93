using UnityEngine;

[RequireComponent(typeof(CatMover))]
public class CatInput : MonoBehaviour
{
    private CatMover _mover;

    private void Start()
    {
        _mover = GetComponent<CatMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            _mover.TryMoveUp();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            _mover.TryMoveDown();
    }
}

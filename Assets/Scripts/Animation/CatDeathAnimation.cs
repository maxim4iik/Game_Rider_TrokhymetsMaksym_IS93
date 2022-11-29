using UnityEngine;

[RequireComponent(typeof(Animation))]
public class CatDeathAnimation : MonoBehaviour
{
    [SerializeField] private Cat _cat;
    private Animation _deathAnimation;

    private void Start()
    {
        _deathAnimation = GetComponent<Animation>();
    }

    private void OnEnable()
    {
        _cat.Died += OnDeathAnimation;
    }

    private void OnDisable()
    {
        _cat.Died -= OnDeathAnimation;
    }

    private void OnDeathAnimation()
    {
        
    }
}

using UnityEngine;

public class CacheStartPosition : MonoBehaviour
{
    private Vector3 _originalPosition;

    private void Awake()
    {
        _originalPosition = transform.localPosition;
    }

    public void ResetPosition()
    {
        transform.localPosition = _originalPosition;
    }
}

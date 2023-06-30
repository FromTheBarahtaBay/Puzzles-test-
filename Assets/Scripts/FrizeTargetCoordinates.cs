using UnityEngine;

public class FrizeTargetCoordinates : MonoBehaviour
{
    private Vector3 _targetCoordinates;
    public Vector3 TargetCoordinates
    {
        get { return _targetCoordinates; }
        set { _targetCoordinates = value; }
    }

}

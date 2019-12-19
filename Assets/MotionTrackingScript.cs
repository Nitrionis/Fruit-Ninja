using UnityEngine;

/// <summary>
/// Class will tracking point rotation with 2 dots:
/// trackingPoint on the top the suber and handle dot
/// wich possess in the center of suber rotation.
/// Between two frame script create plane of slice.
/// This script must be a component of main suber object!
/// </summary>
public class MotionTrackingScript : MonoBehaviour
{
    public Transform trackingPoint;
    //Transform of the suber's handle
    private Vector3 handleTransform;
    //Last position of the tracking point
    private Vector3 lastPosition;

    void Start()
    {
        if (trackingPoint == null) throw new MissingReferenceException();

        lastPosition = trackingPoint.position;
        handleTransform = this.GetComponent<Transform>().position;
    }

    void Update()
    {
        //Посылаю точки: handleTransform, lastPosition и trackingPoint.Position в преобразователь
        lastPosition = trackingPoint.position;
    }
}

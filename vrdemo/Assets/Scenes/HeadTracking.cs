using UnityEngine;

public class HeadTracking : MonoBehaviour
{
    private Gyroscope gyro;
    private Vector3 initial = new Vector3(-90, 180, -90);

    // Use this for initialization
    void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        else
        {
            Debug.Log("No Gyro Support");
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (SystemInfo.supportsGyroscope)
        {
            var camRot = gyro.attitude;
            transform.eulerAngles = initial;
            transform.localRotation *= camRot;
        }
    }
}

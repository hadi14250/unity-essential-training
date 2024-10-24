using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // The duration of a full day in seconds (editable in Inspector)
    [SerializeField]
    private float dayDurationInSeconds = 120f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation step based on the time elapsed and day duration
        float rotationStep = 360f / dayDurationInSeconds * Time.deltaTime;

        // Apply rotation around the X-axis to simulate the day passing
        transform.Rotate(Vector3.right, rotationStep);
    }
}

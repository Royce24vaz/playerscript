 using UnityEngine;



public class DayNightCycle : MonoBehaviour

{

    public Light directionalLight; // The sun or moon light

    public float dayLength = 60f; // Length of a full day in seconds (60s = 1 minute day)

    public float intensityAtNoon = 1f; // Maximum light intensity at noon

    public float intensityAtMidnight = 0.1f; // Minimum light intensity at night



    private float timeOfDay = 0f; // Current time of the day (0 = midnight, 0.5 = noon, 1 = midnight again)



    void Update()

    {

        // Calculate the time of day based on the day length

        timeOfDay += Time.deltaTime / dayLength;

        if (timeOfDay >= 1f) timeOfDay = 0f; // Loop back to midnight after a full day



        // Rotate the directional light to simulate the sun's movement

        float rotationAngle = timeOfDay * 360f - 90f; // 0-360 degrees for a full day

        directionalLight.transform.rotation = Quaternion.Euler(rotationAngle, 170f, 0f);



        // Adjust the light intensity based on the time of day

        if (timeOfDay < 0.25f || timeOfDay > 0.75f) // Night time (early morning or evening)

        {

            directionalLight.intensity = Mathf.Lerp(intensityAtMidnight, intensityAtNoon, Mathf.PingPong(timeOfDay * 4f, 1f));

        }

        else // Daytime (morning to afternoon)

        {

            directionalLight.intensity = Mathf.Lerp(intensityAtNoon, intensityAtMidnight, Mathf.PingPong((timeOfDay - 0.25f) * 4f, 1f));

        }

    }

}


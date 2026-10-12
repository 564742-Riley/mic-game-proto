using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class ScaleFromMicrophone : MonoBehaviour
{
    

    GameObject dialog = null;
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;

    public float loudnessSensibillity = 100;
    public float threshold = 0.1f;

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
            dialog = new GameObject(); 
            print("no auth");

        }
        else
        {
            print("auth");
        }
    }

    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibillity;

        print("loudness=" + loudness);

        if (loudness < threshold)
            loudness = 0;


        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);

        UIScript.ui.DrawText("Loudness = " + loudness);
    


    }

   
}

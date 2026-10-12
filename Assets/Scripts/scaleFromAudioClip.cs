using UnityEngine;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class scaleFromAudioClip : MonoBehaviour
{
    

    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;

    public float loudnessSensibillity = 100;
    public float threshold = 0.1f;

    void Start()
    {
        

    }

    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibillity;

        if (loudness < threshold)
            loudness = 0;
        

        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }


   
}

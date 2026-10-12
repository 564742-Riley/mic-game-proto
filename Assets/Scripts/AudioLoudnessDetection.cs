using JetBrains.Annotations;
using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip;


    void Start()
    {
        MicrophoneToAudioClip();
    }

    

    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        print("mic name=" + microphoneName);
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }


    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }


    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPostion = clipPosition - sampleWindow;
        if (startPostion < 0)
            return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPostion);

        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++) 
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;
    }
}

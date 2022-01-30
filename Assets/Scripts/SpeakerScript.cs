using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SpeakerScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI text;
    
    // Start is called before the first frame update
    async void Start()
    {
        await AudioManager.GetPlayback(text.text);

        var path = Path.Combine(Application.dataPath, "Recordings");

        var directory = new DirectoryInfo(path);
        var playback = directory.GetFiles().Where(x => x.Name.Contains("Playback") && !x.Name.Contains(".meta"));
        var file = playback.OrderByDescending(x => x.LastWriteTime).First();
        
        var clip = await LoadClip(Path.Combine(path, file.Name));

        var source = this.GetComponent<AudioSource>();
        source.clip = clip;

        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task<AudioClip> LoadClip(string path)
    {
        AudioClip clip = null;
        UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV);
        
        uwr.SendWebRequest();

        // wrap tasks in try/catch, otherwise it'll fail silently
        try
        {
            while (!uwr.isDone) await Task.Delay(5);

            if (uwr.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log($"{uwr.error}");
            }
            else
            {
                clip = DownloadHandlerAudioClip.GetContent(uwr);
            }
        }
        catch (Exception err)
        {
            Debug.Log($"{err.Message}, {err.StackTrace}");
        }

        return clip;
    }
}

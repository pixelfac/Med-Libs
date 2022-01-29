[System.Serializable]
public class Transcript
{
    public string id;
    public string status;
    public string text;
}

[System.Serializable]
public class TranscriptUpload
{
    public string audio_url;
}

[System.Serializable]
public class Upload
{
    public string upload_url;
}

[System.Serializable]
public class GoogleSpeech
{
    public input input = new input();
    public voice voice = new voice();
    public audioConfig audioConfig = new audioConfig();
}

[System.Serializable]
public class input
{
    public string text;
}

[System.Serializable]
public class voice
{
    public string languageCode = "en-us";
    public string name = "en-US-Wavenet-D";
    public string ssmlGender = "MALE";
}

[System.Serializable]
public class audioConfig
{
    public string audioEncoding = "MP3";
}

[System.Serializable]
public class AudioResponse
{
    public string audioContent;
}

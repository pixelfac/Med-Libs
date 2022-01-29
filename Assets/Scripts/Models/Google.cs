using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GoogleSpeech
{
    public input input;
    public voice voice;
    public audioConfig audioConfig;
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

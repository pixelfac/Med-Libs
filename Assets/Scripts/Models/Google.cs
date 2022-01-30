[System.Serializable]
public class GoogleSpeech
{
    public Input input = new Input();
    public Voice voice = new Voice();
    public AudioConfig audioConfig = new AudioConfig();
}

[System.Serializable]
public class Input
{
    public string text;
}

[System.Serializable]
public class Voice
{
    public string languageCode = "en-gb";
    public string name = "en-gb-Standard-A";
    public string ssmlGender = "MALE";
}

[System.Serializable]
public class AudioConfig
{
    public string audioEncoding = "LINEAR16";
    public double speakingRate = 0.9;
    public double pitch = -8.0;
}

[System.Serializable]
public class AudioResponse
{
    public string audioContent;
}

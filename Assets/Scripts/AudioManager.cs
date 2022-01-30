using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using UnityEngine;

class AudioManager
{
    private readonly static string _assemblyAuth = "aa7987c18cc24a5bab99e644f4fb29e3";
    private readonly static string _googleAuth = "AIzaSyCqeBaO4tqyaZEUHHJeoqU4JH8h9qeHoz8";
    
    public static async Task<string> UploadFile(string fileName)
    {
        var filePath = Path.Combine(Application.dataPath, "Recordings", fileName);

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://api.assemblyai.com/v2/");
        client.DefaultRequestHeaders.Add("authorization", _assemblyAuth);

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "upload");
        request.Headers.Add("Transer-Encoding", "chunked");

        try
        {
            var fileReader = File.OpenRead(filePath);
            var streamContent = new StreamContent(fileReader);
            request.Content = streamContent;

            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
               
            var readString = await response.Content.ReadAsStringAsync();
            var result = JsonUtility.FromJson<Upload>(readString);
            Debug.Log($"Uploaded to: {result.upload_url}");
            return result.upload_url;
        }
        catch (Exception e)
        {
            Debug.LogError($"Exception: {e.Message}");
            throw;
        }
    }

    public static async Task<Transcript> GetTranscript(string url)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("authorization", _assemblyAuth);

        var transcript = await SendToUpload(client, url);

        while (transcript.status != "completed")
        {
            transcript = await GetTranscriptFromId(client, transcript.id);
            await Task.Delay(2000);
        }

        Debug.Log($"Transcript Log: { transcript.text }");

        return transcript;
    }

    public static async Task<Transcript> SendToUpload(HttpClient client, string url)
    {
        TranscriptUpload data = new TranscriptUpload();
        data.audio_url = url;

        try
        {
            StringContent payload = new StringContent(JsonUtility.ToJson(data));

            HttpResponseMessage response = await client.PostAsync("https://api.assemblyai.com/v2/transcript", payload);
            response.EnsureSuccessStatusCode();

            var readString = await response.Content.ReadAsStringAsync();
            Debug.Log(readString);
            return JsonUtility.FromJson<Transcript>(readString);
        }
        catch (Exception e)
        {
            Debug.LogError($"Exception: {e.Message}");
            throw;
        }
    }

    public static async Task<Transcript> GetTranscriptFromId(HttpClient client, string id)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync($"https://api.assemblyai.com/v2/transcript/{id}");
            response.EnsureSuccessStatusCode();

            var readString = await response.Content.ReadAsStringAsync();
            Debug.Log(readString);
            return JsonUtility.FromJson<Transcript>(readString);
        }
        catch (Exception e)
        {
            Debug.LogError($"ExceptionL: {e.Message}");
            throw;
        }
    }

    public static async Task GetPlayback(string text)
    {
        HttpClient client = new HttpClient();

        var json = new GoogleSpeech();
        json.input.text = text;

        StringContent payload = new StringContent(JsonUtility.ToJson(json));

        HttpResponseMessage response = await client.PostAsync($"https://texttospeech.googleapis.com/v1/text:synthesize?key={_googleAuth}", payload);
        response.EnsureSuccessStatusCode();

        var readString = await response.Content.ReadAsStringAsync();
        var data = JsonUtility.FromJson<AudioResponse>(readString);
        Debug.Log(data.audioContent);
        var bytes = Convert.FromBase64String(data.audioContent);

        string fileName = $"Playback-{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}.wav";

        var filepath = Path.Combine(Application.dataPath, "Recordings", fileName);

        var file = File.OpenWrite(filepath);

        await file.WriteAsync(bytes, 0, bytes.Length);

        file.Close();
    }
}
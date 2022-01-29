using System;
using System.Net.Http;
using System.Threading.Tasks;

using UnityEngine;

using Models;

class AudioTranscript
{
    readonly static string _auth = "";

    public static async Task<string> UploadFile(string filePath)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://api.assemblyai.com/v2/");
        client.DefaultRequestHeaders.Add("authorization", _auth);

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "upload");
        request.Headers.Add("Transer-Encoding", "chunked");

        try
        {
            var fileReader = System.IO.File.OpenRead(filePath);
            var streamContent = new StreamContent(fileReader);
            request.Content = streamContent;

            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
               
            var readString = await response.Content.ReadAsStringAsync();
            var result = JsonUtility.FromJson<Upload>(readString);
            //var result = await JsonSerializer.DeserializeAsync<Upload>( stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true } );
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
        client.BaseAddress = new Uri("https://api.assemblyai.com/v2/");
        client.DefaultRequestHeaders.Add("authorization", _auth);

        var json = new
        {
            audio_url = url
        };

        Transcript result;
        
        try
        {
            //StringContent payload = new StringContent(JsonSerializer.Serialize(json), Encoding.UTF8, "application/json");
            StringContent payload = new StringContent(JsonUtility.ToJson(json));

            HttpResponseMessage response = await client.PostAsync("https://api.assemblyai.com/v2/transcript", payload);
            response.EnsureSuccessStatusCode();

            var readString = await response.Content.ReadAsStringAsync();
            //var result = await JsonSerializer.DeserializeAsync<Transcript>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true } );
            result = JsonUtility.FromJson<Transcript>(readString);
        }
        catch (Exception e)
        {
            Debug.LogError($"ExceptionL: {e.Message}");
            throw;
        }

        // Error check to see if words was found
        if (result.words is null)
        {
            Debug.LogWarning("Words is null");
            return result;
        }

        string message = "";
        foreach (var word in result.words)
        {
            message += word.text + " ";
        }

        Debug.Log($"Transcript Log: { message.Trim() }");

        return result;
    }
}
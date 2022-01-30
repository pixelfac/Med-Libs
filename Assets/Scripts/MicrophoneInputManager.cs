using System;

using UnityEngine;
using UnityEngine.InputSystem;

public class MicrophoneInputManager : MonoBehaviour
{
    AudioSource recordingSource;
    Controls controls;
    string micName;

    [Range(1,10)]
    [SerializeField] int recordingLength;


    private void Awake()
    {
        controls = new Controls();
        recordingSource = GetComponent<AudioSource>();
        Debug.Log(recordingSource.ToString());
    }

    private void OnEnable()
    {
        controls.Record.Record.started += QueRecording;
        controls.Record.Record.performed += StartRecording;
        controls.Record.Record.canceled += StopRecording;

        controls.Google.Command.performed += BPressed;

        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Record.Record.started -= QueRecording;
        controls.Record.Record.performed -= StartRecording;
        controls.Record.Record.canceled -= StopRecording;

        controls.Google.Command.performed -= BPressed;

        controls.Disable();
    }

    private void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("device: " + device);
        }

        if (Microphone.devices.Length != 0)
        {
            micName = Microphone.devices[0];
        }
        else
        {
            Debug.LogError("No Microphone Detected");
        }
    }

    //Called when button is first pressed down, but before the recording actually starts
    private void QueRecording(InputAction.CallbackContext ctx)
    {
        Debug.Log("space is qued");
    }

    //Not called immediately on button press
    private void StartRecording(InputAction.CallbackContext ctx)
    {
        Debug.Log("space is starting");
        recordingSource.clip = Microphone.Start(micName, false, recordingLength, 44100);
    }

    //Called on button release
    private async void StopRecording(InputAction.CallbackContext ctx)
    {
        Debug.Log("space has ended");
        Microphone.End(micName);

        recordingSource.PlayDelayed(1f);

        string fileName = $"Clip-{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}.wav";

        SavWav.Save(fileName, recordingSource.clip);
        string url = await AudioManager.UploadFile(fileName);

        Transcript transcript = await AudioManager.GetTranscript(url);
    }

    private async void BPressed(InputAction.CallbackContext ctx)
    {
        await AudioManager.GetPlayback("By the next day, $ had entered into a humid slough, trudging through the murky waters and foggy heat, struggling to maintain balance as the slimy dirt suctioned them in place. There were $ hissing in writhing snarls underneath the ambience of the mangroves. A shadow moved by his left side revealing as such. $ was met with the image of a sickly, drooling toad-like creature, It's teeth dripping with $. $ was $. Taking a step back, they gathered themselves before lifting up their $. The toad produced a thunderous croak and lurched itself at $. Now on the defensive, they slung their $ at the beast - making contact with it's tender flesh and knocking it to the ground. ");
    }
}

using System.IO;

using UnityEngine;

using TMPro;

public class ScrollText : MonoBehaviour
{
    private readonly string txtfileName = @"Assets/FullStory.txt";
    private readonly string csvfileName = @"Assets/StoryVariables.csv";

    // Start is called before the first frame update
    void Start()
    {
        var text = ReadCSVfillBlank();
        this.GetComponent<TextMeshProUGUI>().text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string ReadCSVfillBlank()
    {
        StreamReader str1 = new StreamReader(txtfileName);
        StreamReader str2 = new StreamReader(csvfileName);
        //We need to read in the first line, which is different from the rest. 
        string fullStory;
        string index;

        string final = "";

        //what follows is the rest of the questions. 
        while ((fullStory = str1.ReadLine()) != null)
        {
            var data_values = fullStory.Split('$');

            for (int i = 0; i < data_values.Length; i++)
            {
                Debug.Log(data_values[i].ToString());
                final += data_values[i].ToString();

                if ((index = str2.ReadLine()) != null)
                {
                    int intIndex = int.Parse(index);
                    Debug.Log(intIndex);
                    Debug.Log(ReadCSV_qna.answerArray[intIndex]);
                    final += ReadCSV_qna.answerArray[intIndex];
                }

            }
        }

        return final;
    }
}

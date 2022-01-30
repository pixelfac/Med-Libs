using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadCSV_fillBlank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /////////*********REMOVE THESE ONCE WE HAVE ACTUAL LIST OF ANSWERS
        ReadCSV_qna.answerArray[0] = "Arthur";
        ReadCSV_qna.answerArray[1] = "Kingdom of England";
        ReadCSV_qna.answerArray[2] = "wonderful";
        ReadCSVfillBlank();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadCSVfillBlank(){
        /////////*********CHANGE FILE NAME FOR FINAL
        string txtfileName = @"Story1.txt";
        string csvfileName = @"fillBlanks_story1_TEST.csv";
        
        StreamReader str1 = new StreamReader(txtfileName);
        StreamReader str2 = new StreamReader(csvfileName);
        //We need to read in the first line, which is different from the rest. 
        string fullStory; 
        string index;

        //what follows is the rest of the questions. 
        while ( (fullStory = str1.ReadLine()) != null){
            var data_values = fullStory.Split('$');

            for (int i = 0 ; i < data_values.Length ; i++){
                Debug.Log(data_values[i].ToString());

                if ( (index = str2.ReadLine()) != null){
                    int intIndex = int.Parse(index);
                    //Debug.Log(intIndex);
                    Debug.Log(ReadCSV_qna.answerArray[intIndex]);
                }
                
            }
        }
    }
}

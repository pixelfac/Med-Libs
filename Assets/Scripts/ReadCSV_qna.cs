using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadCSV_qna : MonoBehaviour
{

    //static container for qna map
    public static Dictionary<int, List<string>> qnaStorage = new Dictionary<int, List<string>>();
    //static container for chosen answers
    public static string[] answerArray;


    // Start is called before the first frame update
    void Start()
    {
        //calls function below. 
        ReadCSVqna();


        /******* BELOW IS AN ITERATION FOR EACH ITEM IN THE MAP!
        Debug.Log("CHECKING IF EVERYTHING IS INSIDE");
        for (int i = 1 ; i < (qnaStorage.Count+1) ; i++ ){
            List<string> temp = qnaStorage[i];
            for (int j = 0 ; j < temp.Count ; j++){
                if (j == 0){
                    //question is read here
                    Debug.Log("Question: " + temp[j].ToString());

                }
                else{
                    //each answer is read here
                    Debug.Log("Answer Choice #" + j + " " + temp[j].ToString());
                
                }
            }
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadCSVqna(){
        /////////*********CHANGE FILE NAME FOR FINAL
        string fileName = @"qnaStorageFile_story1_TEST.csv";
        StreamReader str = new StreamReader(fileName);
        int count = 1;
        
        //We need to read in the first line, which is different from the rest. 
        string fullLine; 
        fullLine = str.ReadLine();
        var data_values = fullLine.Split(',');
        //displaying the output in the debug console: 
        Debug.Log("There are " + int.Parse(data_values[0]) + " questions in this story");
        //creating an answer array depending on how many questions there are. 
        answerArray = new string[int.Parse(data_values[0])];

        //what follows is the rest of the questions. 
        while ( (fullLine = str.ReadLine()) != null){
            data_values = fullLine.Split(',');
            List<string> temp = new List<string>();

            for (int i = 0 ; i < data_values.Length ; i++){
                if (!data_values[i].ToString().Equals("")){
                    if (i == 0){
                        //question is read here
                        Debug.Log("Question: " + data_values[i].ToString());
                        temp.Add(data_values[i].ToString());
                    }
                    else{
                        //each answer is read here
                        Debug.Log("Answer Choice #" + i + " " + data_values[i].ToString());
                        temp.Add(data_values[i].ToString());
                    }
                }
            }
            //indicated that this is the end of the line, so we move onto the next
            Debug.Log("Next line");
            qnaStorage.Add(count, temp);
            ++count;
        }

    }
}

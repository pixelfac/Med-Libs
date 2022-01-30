using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionChanger : MonoBehaviour
{

    //ReadCSV_qna.qnaStorage;

    int questionCount = ReadCSV_qna.qnaStorage.Count;
    int questionNumber = 1;

    public TextMeshProUGUI[] fourButtons = new TextMeshProUGUI[4];
    public TextMeshProUGUI[] threeButtons = new TextMeshProUGUI[3];
    public TextMeshProUGUI[] twoButtons = new TextMeshProUGUI[2];


    

    // Start is called before the first frame update
    void Start()
    {

        fourButtons[0].text = "Hello";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateQuestion(){

    }

    public void ButtonOneClicked(){
        ReadCSV_qna.answerArray[questionNumber - 1] = ReadCSV_qna.qnaStorage[questionNumber][1];
        Debug.Log("Woa the button 1 is clicked and answer Array didn't kill us. ");

    }

    public void ButtonTwoClicked(){
        ReadCSV_qna.answerArray[questionNumber - 1] = ReadCSV_qna.qnaStorage[questionNumber][2];
        Debug.Log("Woa the button 2 is clicked and answer Array didn't kill us. ");
    }

    public void ButtonThreeClicked(){
        ReadCSV_qna.answerArray[questionNumber - 1] = ReadCSV_qna.qnaStorage[questionNumber][3];
        Debug.Log("Woa the button 3 is clicked and answer Array didn't kill us. ");
    }

    public void ButtonFourClicked(){
        ReadCSV_qna.answerArray[questionNumber - 1] = ReadCSV_qna.qnaStorage[questionNumber][4];
        Debug.Log("Woa the button 4 is clicked and answer Array didn't kill us. ");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionChanger : MonoBehaviour
{

    //ReadCSV_qna.qnaStorage;

    int questionCount;
    int questionNumber;

    public GameObject groupFour, groupThree, groupTwo;
    public TextMeshProUGUI question;

    public TextMeshProUGUI[] fourButtons = new TextMeshProUGUI[4];
    public TextMeshProUGUI[] threeButtons = new TextMeshProUGUI[3];
    public TextMeshProUGUI[] twoButtons = new TextMeshProUGUI[2];

    // Start is called before the first frame update
    void Start()
    {

        //fourButtons[0].text = "Hello";
        questionCount = ReadCSV_qna.qnaStorage.Count;
        questionNumber = 0;
        updateQuestion();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonOneClicked(){
        ReadCSV_qna.answerArray[questionNumber - 1] = ReadCSV_qna.qnaStorage[questionNumber][1];
        Debug.Log("Woa the button 1 is clicked and answer Array didn't kill us. ");
        updateQuestion();
    }

    public void ButtonTwoClicked(){
        ReadCSV_qna.answerArray[questionNumber - 1] = ReadCSV_qna.qnaStorage[questionNumber][2];
        Debug.Log("Woa the button 2 is clicked and answer Array didn't kill us. ");
        updateQuestion();
    }

    public void ButtonThreeClicked(){
        ReadCSV_qna.answerArray[questionNumber - 1] = ReadCSV_qna.qnaStorage[questionNumber][3];
        Debug.Log("Woa the button 3 is clicked and answer Array didn't kill us. ");
        updateQuestion();
    }

    public void ButtonFourClicked(){
        ReadCSV_qna.answerArray[questionNumber - 1] = ReadCSV_qna.qnaStorage[questionNumber][4];
        Debug.Log("Woa the button 4 is clicked and answer Array didn't kill us. ");
        updateQuestion();
    }

    void updateQuestion(){
        ++questionNumber;
        Debug.Log(questionNumber);
        Debug.Log(questionCount);

        if (questionNumber > questionCount){

            for (int i = 0 ; i < ReadCSV_qna.answerArray.Length ; i++){
                Debug.Log("Index " + i + " is " + ReadCSV_qna.answerArray[i]);
            }

        }
        else{
            question.text = ReadCSV_qna.qnaStorage[questionNumber][0];

            int vectorSize = ReadCSV_qna.qnaStorage[questionNumber].Count;

            if (vectorSize == 5){
                groupFour.SetActive(true);
                groupThree.SetActive(false);
                groupTwo.SetActive(false);

                fourButtons[0].text = ReadCSV_qna.qnaStorage[questionNumber][1];
                fourButtons[1].text = ReadCSV_qna.qnaStorage[questionNumber][2];
                fourButtons[2].text = ReadCSV_qna.qnaStorage[questionNumber][3];
                fourButtons[3].text = ReadCSV_qna.qnaStorage[questionNumber][4];
            }
            else if (vectorSize == 4){
                groupFour.SetActive(false);
                groupThree.SetActive(true);
                groupTwo.SetActive(false);

                threeButtons[0].text = ReadCSV_qna.qnaStorage[questionNumber][1];
                threeButtons[1].text = ReadCSV_qna.qnaStorage[questionNumber][2];
                threeButtons[2].text = ReadCSV_qna.qnaStorage[questionNumber][3];

            }
            else if (vectorSize == 3){
                groupFour.SetActive(false);
                groupThree.SetActive(false);
                groupTwo.SetActive(true);

                twoButtons[0].text = ReadCSV_qna.qnaStorage[questionNumber][1];
                twoButtons[1].text = ReadCSV_qna.qnaStorage[questionNumber][2];
                
            }
        }

        

    }
}

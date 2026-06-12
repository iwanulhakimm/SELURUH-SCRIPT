using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MatchGameController : MonoBehaviour
{

    [Header("DATABASE")]
    public AksaraQuestionTable table;

    [Header("UI SOAL")]
    public Image[] soalImages;
    public Button[] soalButtons;

    [Header("UI JAWABAN")]
    public TMP_Text[] jawabanTexts;
    public Button[] jawabanButtons;

    private List<AksaraQuestion> selectedQuestions = new List<AksaraQuestion>();

    private int selectedSoalIndex = -1;
    private int[] answerID;

    void Start()
    {
        GenerateQuestions();
        SetupButtons();
    }

    void GenerateQuestions()
    {
        List<AksaraQuestion> temp = new List<AksaraQuestion>(table.questions);

        selectedQuestions.Clear();

        for (int i = 0; i < 5; i++)
        {
            int rand = Random.Range(0, temp.Count);
            selectedQuestions.Add(temp[rand]);
            temp.RemoveAt(rand);
        }

        for (int i = 0; i < 5; i++)
        {
            soalImages[i].sprite = selectedQuestions[i].aksaraImage;
        }

        List<AksaraQuestion> answerPool = new List<AksaraQuestion>(selectedQuestions);

        Shuffle(answerPool);

        answerID = new int[5];

        for (int i = 0; i < 5; i++)
        {
            jawabanTexts[i].text = answerPool[i].answerText;
            answerID[i] = answerPool[i].id;
        }
    }

    void SetupButtons()
    {
        for (int i = 0; i < soalButtons.Length; i++)
        {
            int index = i;
            soalButtons[i].onClick.AddListener(() => SelectSoal(index));
        }

        for (int i = 0; i < jawabanButtons.Length; i++)
        {
            int index = i;
            jawabanButtons[i].onClick.AddListener(() => SelectJawaban(index));
        }
    }

    void SelectSoal(int index)
    {
        selectedSoalIndex = index;
    }

    void SelectJawaban(int index)
    {
        if (selectedSoalIndex == -1) return;

        int soalID = selectedQuestions[selectedSoalIndex].id;
        int jawabanID = answerID[index];

        if (soalID == jawabanID)
        {
            StartCoroutine(CorrectMatch(selectedSoalIndex, index));
        }
        else
        {
            StartCoroutine(WrongMatch(selectedSoalIndex, index));
        }

        selectedSoalIndex = -1;
    }

    IEnumerator CorrectMatch(int soalIndex, int jawabanIndex)
    {
        SoundManager.instance.PlayCorrect();

        soalButtons[soalIndex].image.color = Color.green;
        jawabanButtons[jawabanIndex].image.color = Color.green;

        soalButtons[soalIndex].interactable = false;
        jawabanButtons[jawabanIndex].interactable = false;

        yield return null;
    }

    IEnumerator WrongMatch(int soalIndex, int jawabanIndex)
    {
        SoundManager.instance.PlayWrong();

        soalButtons[soalIndex].image.color = Color.red;
        jawabanButtons[jawabanIndex].image.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        soalButtons[soalIndex].image.color = Color.white;
        jawabanButtons[jawabanIndex].image.color = Color.white;
    }

    void Shuffle(List<AksaraQuestion> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            AksaraQuestion temp = list[i];
            int rand = Random.Range(i, list.Count);
            list[i] = list[rand];
            list[rand] = temp;
        }
    }
}

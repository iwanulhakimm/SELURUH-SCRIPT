using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AksaraQuestionTable", menuName = "ARASUN/Aksara Question Table")]
public class AksaraQuestionTable : ScriptableObject
{
    public List<AksaraQuestion> questions;
}

[System.Serializable]
public class AksaraQuestion
{
    public int id;
    public Sprite aksaraImage;
    public string answerText;
}
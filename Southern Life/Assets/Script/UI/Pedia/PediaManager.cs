using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PediaManager : MonoBehaviour
{
    public static PediaManager instance;
    public Image leftImage, rightImage;
    public Text leftText, rightText;
    public Page lPage, rPage;
    public int pageNum = 0;
    public int pageLength;
    
    private void Start()
    {
        leftImage.sprite = lPage.pic[0];
        leftText.text = lPage.desText[0];
        rightImage.sprite = rPage.pic[0];
        rightText.text = rPage.desText[0];
        pageLength = lPage.desText.Length-1;
    }

    public void NextPage()
    {
        if(pageNum < pageLength)
        {
            pageNum += 1;
            leftImage.sprite = lPage.pic[pageNum];
            leftText.text = lPage.desText[pageNum];
            rightImage.sprite = rPage.pic[pageNum];
            rightText.text = rPage.desText[pageNum];
        }
    }

    public void PreviousPage()
    {
        if (pageNum > 0)
        {
            pageNum -= 1;
            leftImage.sprite = lPage.pic[pageNum];
            leftText.text = lPage.desText[pageNum];
            rightImage.sprite = rPage.pic[pageNum];
            rightText.text = rPage.desText[pageNum];
        }
    }
}

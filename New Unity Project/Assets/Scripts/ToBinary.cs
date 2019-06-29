using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToBinary : MonoBehaviour
{
    private int stringDate = 0;
    private int twoCut = 0;
    private char textStr = ' ';
    private string binaryString = "";
    private int remainder = 0;
    private string remainStr;
    // Start is called before the first frame update
    void Start()
    {
        //InputFieldのテキストの長さが奇数だった場合入る。
        if (NumberCheck.inputField.text.Length % 2 == 1)
        {
            //最後の文字を先に2進数にして取っておく
            remainder = StringToBinary(NumberCheck.inputField.text[NumberCheck.inputField.text.Length]);            
            remainStr = remainder.ToString();
            //奇数の最後の文字は6bitで表す(余りは0詰め)
            remainStr.PadLeft(6, '0');           
        }
    }

    // Update is called once per frame
    void Update()
    {
        //InputFieldのテキストの長さ分回す
        for(int i = 0; i < NumberCheck.inputField.text.Length; i++)
        {
            //一文字ずつ2進数化していく
            textStr = NumberCheck.inputField.text[i];            
            //仮想的に2文字ずつに分け、一文字目は45をかける。二文字目は一文字目の数字に足す。
            CalString(i, StringToBinary(textStr));
        }
    }

    public int StringToBinary(char str)
    {
        switch (str)
        {
            case '0':
                stringDate = 0;
                return stringDate;
        }
        return -1;
    }   

    private void CalString(int i, int strDate)
    {
        if (i % 2 == 1)
        {
            //もし奇数が最後の文字だった場合入る
            if(i == NumberCheck.inputField.text.Length)
            {
                binaryString += remainStr;
                return;
            }            
            twoCut = stringDate * 45;
        }
        else if (i % 2 == 0)
        {
            twoCut += stringDate;
            //
            binaryString += twoCut.ToString();
            twoCut = 0;            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToBinary : MonoBehaviour
{
    private int stringDate = 0;
    private int twoCut = 0;    
    private char textStr = ' ';
    public static string binaryString = "";
    private int remainder = 0;
    private string remainStr = "";
    private string binary = "";
    private int textLength = 0;
    void Start()
    {
        //使用頻度が高いので変数を短く
        textLength = NumberCheck.inputField.text.Length;

        //数字モードかつInputFieldのテキストの長さが3で割れない場合入る
        if (textLength % 3 != 0 && NumberCheck.modeJudge == "0001")
        {
            if (textLength % 3 == 1)
            {
                //InputFieldのテキストの最後の文字を取得
                textStr = NumberCheck.inputField.text[textLength];
                //文字型を文字列方に変換しPadLeftを使用できるようにする
                remainStr = textStr.ToString();
                remainStr.PadLeft(4, '0');
            }
            else if (textLength % 3 == 2)
            {
                //後ろから2つを取得するため、Substringを使用し最後の文字と最後から1つ前の文字を取得
                remainStr = NumberCheck.inputField.text.Substring(textLength - 1, textLength);
                //取得した文字列をint型に変換
                remainder = int.Parse(remainStr);
                //変換したものを2進数にする
                remainStr = System.Convert.ToString(remainder, 2);
                //左に0詰め
                remainStr.PadLeft(7, '0');
            }
        }

        //英数字モードかつInputFieldのテキストの長さが奇数だった場合入る。
        if (textLength % 2 == 1 && NumberCheck.modeJudge == "0010")
        {
            //最後の文字を先に10進数に変換する
            remainder = StringToBinary(NumberCheck.inputField.text[textLength]);
            //10進数に変換したものを2進数にする
            remainStr = System.Convert.ToString(remainder, 2);
            //奇数の最後の文字は6bitで表す(余りは0詰め)
            remainStr.PadLeft(6, '0');
        }
    }

    // Update is called once per frame
    void Update()
    {
        //InputFieldのテキストの長さ分回す
        for(int i = 0; i < textLength; i++)
        {
            //一文字ずつ10進数化していく
            textStr = NumberCheck.inputField.text[i];            
            //仮想的に2文字ずつに分ける
            CalString(i, StringToBinary(textStr));            
        }
    }

    public int StringToBinary(char str)
    {
        //文字を10進数で表す。
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
            if(i == textLength)
            {               
                binaryString += remainStr;
                return;
            }            
            //一文字目は45をかける
            twoCut = strDate * 45;
        }
        else if (i % 2 == 0)
        {
            //二文字目は一文字目の数字に足す
            twoCut += strDate;
            //10進数に変換したものを2進数にする
            binary = System.Convert.ToString(twoCut, 2);
            //奇数の最後の文字は6bitで表す(余りは0詰め)
            binary.PadLeft(11, '0');
            //
            binaryString += binary;            
            twoCut = 0;
        }
    }
}

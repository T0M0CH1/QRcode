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
    private string threeCut = "";
    public static bool toBinaryBool = false;

    private void Start()
    {
        if (NumberCheck.inputField.text == null) return;

        Debug.Log("inStart");
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
                //左に0詰め
                remainStr = remainStr.PadLeft(4, '0');
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
                remainStr = remainStr.PadLeft(7, '0');
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
            remainStr = remainStr.PadLeft(6, '0');
        }
    }

    private void Update()
    {
        if (toBinaryBool == true)
        {
            toBinaryBool = false;
            //英数字モードの場合
            if (NumberCheck.modeJudge == "0010")
            {                
                //InputFieldのテキストの長さ分回す
                for (int i = 0; i < textLength; i++)
                {
                    Debug.Log("sssss");
                    //一文字ずつ10進数化していく
                    textStr = NumberCheck.inputField.text[i];
                    Debug.Log(i + "回目" + textStr);
                    //仮想的に2文字ずつに分ける
                    CalString(i, StringToBinary(textStr));
                }
            }
            //数字モードの場合
            else if (NumberCheck.modeJudge == "0001")
            {
                //InputFieldのテキストの長さ分回す
                for (int i = 0; i < textLength; i++)
                {
                    //一文字ずつ10進数化していく
                    threeCut += NumberCheck.inputField.text[i];
                    for (int j = 0; j <= 3; j++)
                    {
                        //3文字ずつに分ける
                        if (j == 3)
                        {
                            if (i == textLength && textLength % 3 == 2)
                            {
                                binaryString += remainStr;
                                return;
                            }
                            else if (i == textLength && textLength % 3 == 1)
                            {
                                binaryString += remainStr;
                                return;
                            }

                            remainder = int.Parse(threeCut);
                            threeCut += System.Convert.ToString(remainder, 2);
                            binaryString += threeCut.PadLeft(10, '0');
                            threeCut = "";
                        }
                    }
                }
            }
        }        
    }
   
    private void CalString(int i, int strDate)
    {
        if (i % 2 == 1)
        {
            //もし奇数が最後の文字だった場合入る
            if (i == textLength)
            {
                binaryString += remainStr;
                Debug.Log(binaryString);
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
            //2進数にされたものを11bitで表す
            binary = binary.PadLeft(11, '0');
            binaryString += binary;
            twoCut = 0;
            if(i == textLength)
            {
                Debug.Log(binaryString);
                return;
            }
        }
    }

    private int StringToBinary(char str)
    {
        //文字を10進数で表す。
        switch (str)
        {
            case '0':
                stringDate = 0;
                return stringDate;
            case '1':
                stringDate = 1;
                return stringDate;
            case '2':
                stringDate = 2;
                return stringDate;
            case '3':
                stringDate = 3;
                return stringDate;
            case '4':
                stringDate = 4;
                return stringDate;
            case '5':
                stringDate = 5;
                return stringDate;
            case '6':
                stringDate = 6;
                return stringDate;
            case '7':
                stringDate = 7;
                return stringDate;
            case '8':
                stringDate = 8;
                return stringDate;
            case '9':
                stringDate = 9;
                return stringDate;
            case 'A':
                stringDate = 10;
                return stringDate;
            case 'B':
                stringDate = 11;
                return stringDate;
            case 'C':
                stringDate = 12;
                return stringDate;
            case 'D':
                stringDate = 13;
                return stringDate;
            case 'E':
                stringDate = 14;
                return stringDate;
            case 'F':
                stringDate = 15;
                return stringDate;
            case 'G':
                stringDate = 16;
                return stringDate;
            case 'H':
                stringDate = 17;
                return stringDate;
            case 'I':
                stringDate = 18;
                return stringDate;
            case 'J':
                stringDate = 19;
                return stringDate;
            case 'K':
                stringDate = 20;
                return stringDate;
            case 'L':
                stringDate = 21;
                return stringDate;
            case 'M':
                stringDate = 22;
                return stringDate;
            case 'N':
                stringDate = 23;
                return stringDate;
            case 'O':
                stringDate = 24;
                return stringDate;
            case 'P':
                stringDate = 25;
                return stringDate;
            case 'Q':
                stringDate = 26;
                return stringDate;
            case 'R':
                stringDate = 27;
                return stringDate;
            case 'S':
                stringDate = 28;
                return stringDate;
            case 'T':
                stringDate = 29;
                return stringDate;
            case 'U':
                stringDate = 30;
                return stringDate;
            case 'V':
                stringDate = 31;
                return stringDate;
            case 'W':
                stringDate = 32;
                return stringDate;
            case 'X':
                stringDate = 33;
                return stringDate;
            case 'Y':
                stringDate = 34;
                return stringDate;
            case 'Z':
                stringDate = 35;
                return stringDate;
            case ' ':
                stringDate = 36;
                return stringDate;
            case '$':
                stringDate = 37;
                return stringDate;
            case '%':
                stringDate = 38;
                return stringDate;
            case '*':
                stringDate = 39;
                return stringDate;
            case '+':
                stringDate = 40;
                return stringDate;
            case '-':
                stringDate = 41;
                return stringDate;
            case '.':
                stringDate = 42;
                return stringDate;
            case '/':
                stringDate = 43;
                return stringDate;
            case ':':
                stringDate = 44;
                return stringDate;
        }
        return -1;
    }
}

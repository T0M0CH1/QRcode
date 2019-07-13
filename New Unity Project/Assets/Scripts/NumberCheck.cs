﻿using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System;

public class NumberCheck : MonoBehaviour
{
    [SerializeField]
    private Text text;
    public static InputField inputField;
    private int stringLength;
    private int stringByte;
    public static string modeJudge;
    private string binary;

    void Start()
    {        
        inputField = this.GetComponent<InputField>();
        inputField.ActivateInputField();        
    }
   
    public void checkZenkaku()
    {
        if (inputField.text != null)
        {
            //入力した文字数を計算
            stringLength = inputField.text.Length;
            //Byteの数を計算
            stringByte = Encoding.GetEncoding("Shift_JIS").GetByteCount(inputField.text);
            StringJudge();  
            //文字数とByte数を比べ、全角が入っていたら弾く処理
            if (stringLength == stringByte)
            {                
                text.text = "QRコード作成";
                //Debug.Log(modeJudge);
                //入力された文字数を情報として取得
                ConvertBinary(stringLength,modeJudge);
            }
            else
            {
                text.text = "入力された文字が全角です。すべて半角で入力してください。";
                stringLength = 0;
                stringByte = 0;
                inputField.ActivateInputField();
            }
        }
        else
        {
            text.text = "文字が入力されていません。";
        }
        inputField.text = "";
        inputField.ActivateInputField();
    }

    private void StringJudge()
    {
        ToBinary.binaryString = "";
        //InputFieldに打った文字分回す
        for (int i = 1; i < stringLength; i++)
        {
            //英数字か数字だけかを判定する処理
            if (Char.IsDigit(inputField.text, i) == false)
            {            
                //英数字の場合
                modeJudge = "0010";                
            }
            else
            {
                //数字のみの場合
                modeJudge = "0001";
            }
        }
        ToBinary.binaryString += modeJudge;
    }

    public void ConvertBinary(int decimalNum, string modeSelect)
    {
        
        //入力された文字数2進数に変換する処理
        binary = System.Convert.ToString(decimalNum, 2);
        //英数字の場合は入力された文字数を9bitで表す(余りは0詰め)       
        if (modeSelect == "0010")
        {
            //Debug.Log("inJudge");
            binary = binary.PadLeft(9, '0');
        }
        //数字のみの場合は入力された文字数を10bitで表す(余りは0詰め)
        if (modeSelect == "0001")
        {
            binary = binary.PadLeft(10, '0');
        }
        ToBinary.binaryString += binary;
        Debug.Log("binaryString:" + ToBinary.binaryString);
        ToBinary.toBinaryBool = true;
    }
}

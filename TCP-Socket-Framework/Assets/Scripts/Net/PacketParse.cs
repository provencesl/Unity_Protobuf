using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PacketParse{


    public void Parse(byte[] data)
    {
        Debug.Log("Parse:data length:" + data.Length );

        //解析数据包头
        int readIndex = 0;

        ushort len = ReadUInt16(data,readIndex);

        readIndex += 2;



    }


    private ushort ReadUInt16(byte[] data,int from)
    {
        byte[] array = new byte[2];


        Array.Copy(data,from,array,0,4);
        ushort result = (ushort)BitConverter.ToInt16(array,0);

        return result;

    }










}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class PacketBuilder{



    public byte[] BuildPacket(object protobufObj)
    {
        if (null == protobufObj)
        {
           
            return null;
        }

        int writeIndex = 0;


        byte[] protobufData = DataCenter.protobufUtility.Serialize(protobufObj);

        Packet.messageName = protobufObj.GetType().Name;

        byte[] messageNameBytes = Encoding.UTF8.GetBytes(Packet.messageName + "\0");
        Packet.messageNameLen = (ushort)messageNameBytes.Length;

        Packet.len = (ushort)(2 + 2 + 4 + Packet.messageNameLen + protobufData.Length);

        byte[] packet = new byte[Packet.len];

        WriteUInt16(ref packet,ref writeIndex,Packet.len);
        WriteUInt16(ref packet,ref writeIndex,Packet.messageNameLen);

        WriteBytes(ref packet,ref writeIndex,protobufData,protobufData.Length);

        WriteBytes(ref packet,ref writeIndex,protobufData,protobufData.Length);
        WriteInt32(ref packet,ref writeIndex,Packet.checkCode);

        return packet;


    }



    private void WriteUInt16(ref byte[] packet, ref int writeIndex, ushort num)
    {
        byte[] temp = BitConverter.GetBytes(num);
        Array.Copy(temp,0,packet,writeIndex,2);
        writeIndex += 2;

    }

    private void WriteInt32(ref byte[] packet, ref int writeIndex, int num)
    {

        byte[] temp = BitConverter.GetBytes(num);
        Array.Copy(temp, 0, packet, writeIndex, 4);
        writeIndex += 4;
    }


    private void WriteBytes(ref byte[] packet, ref int writeIndex, byte[] data, int len)
    {
        Array.Copy(data, 0, packet, writeIndex, len);
        writeIndex += len;
    }







}

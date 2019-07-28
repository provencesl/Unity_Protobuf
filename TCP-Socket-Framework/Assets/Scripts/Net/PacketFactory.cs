using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PacketFactory{


    private Type _type;

    private Queue<Packet> _queue;

    public PacketFactory(Type packet)
    {
        _type = packet;
        _queue = new Queue<Packet>();
    }

    public Packet CreatePacket()
    {
        if (null != _type)
        {
            //动态创建类型
            object target = Activator.CreateInstance(_type);

            if (target is Packet)
            {
                return target as Packet;
            }

        }
        return null;
    }


    public Packet GetPacket()
    {
        if (_queue.Count > 0)
        {
            return _queue.Dequeue();
        }
        //没有则添加
        return CreatePacket();
    }


    public void ReturnPacket(Packet packet)
    {
        _queue.Enqueue(packet);
    }




}

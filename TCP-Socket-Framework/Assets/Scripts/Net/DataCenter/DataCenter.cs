using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCenter{



    private static ProtobufUtility _protobufUtility = null;

    public static ProtobufUtility protobufUtility
    {
        get
        {
            if (_protobufUtility == null)
            {
                _protobufUtility = new ProtobufUtility();
            }
            return _protobufUtility;
        }
    }

    private static PacketBuilder _packetBuilder = null;

    public static PacketBuilder PacketBuilder
    {
        get
        {
            if (null == _packetBuilder)
            {
                _packetBuilder = new PacketBuilder();
            }

            return _packetBuilder;
        }
    }


    private static PacketParse _packetParser = null;

    public static PacketParse PacketParser
    {
        get
        {
            if (_packetParser == null)
            {
                _packetParser = new PacketParse();
            }
            return _packetParser;
        }
    }






}

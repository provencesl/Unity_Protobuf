using System.Collections.Generic;
using System.IO;
using ProtoBuf;

public class ProtobufUtility{


    private Dictionary<string, System.Type> protobufType = new Dictionary<string, System.Type>();


    public ProtobufUtility()
    {
        InitProtobufTypes(this.GetType().Assembly);
    }

    /// <summary>
    /// 将Protobuf消息泪打包成二进制数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public byte[] Serialize(object data)
    {
        byte[] buffer = null;

        //
        using (MemoryStream stream = new MemoryStream())
        {
            Serializer.Serialize(stream,data);
            stream.Position = 0;
            int len = (int)stream.Length;

            buffer = new byte[len];
            stream.Read(buffer,0,len);

        }
        return buffer;

    }

    //public static byte[] Serialize<T>(T msg)
    //{
    //    byte[] result = null;
    //    if (msg != null)
    //    {
    //        using (MemoryStream stream = new MemoryStream())
    //        {
    //            Serializer.Serialize<T>(stream,msg);
    //            result = stream.ToArray();
    //        }
    //    }
    //    return result;
    //}


    public object Deserialize(byte[] data, string messageName)
    {
        System.Type type = GetTypeByName(messageName);
        using (MemoryStream m = new MemoryStream())
        {
            return ProtoBuf.Meta.RuntimeTypeModel.Default.Deserialize(m,null,type);
        }

    }


    /// <summary>
    /// 反序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <returns></returns>
    //public static T Deserialize<T>(byte[] message)
    //{
    //    T result = default(T);
    //    if (message != null)
    //    {
    //        using (MemoryStream stream = new MemoryStream(message))
    //        {
    //            result = Serializer.Deserialize<T>(stream);
    //        }
    //    }
    //    return result;

    //}








    ///
    ///<summary>
    ///遍历所有protobuf消息类，将类型和类名存入字典
    ///</summary>
    ///
    private void InitProtobufTypes(System.Reflection.Assembly assembly)
    {
        foreach (System.Type t in assembly.GetTypes())
        {
            ProtoBuf.ProtoContractAttribute[] pc = (ProtoBuf.ProtoContractAttribute[])t.GetCustomAttributes(typeof(ProtoBuf.ProtoContractAttribute),false);
            if (pc.Length > 0)
            {
                protobufType.Add(t.Name,t);
            }
        }

    }










    /// <summary>
    /// 通过protobuf消息名，获取消息类型
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public System.Type GetTypeByName(string name)
    {
        return protobufType[name];
    }




}

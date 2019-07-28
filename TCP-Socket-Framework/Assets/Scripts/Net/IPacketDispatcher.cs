using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPacketDispatcher{

    void RegistMessage(int type);

    void UnRegist(int type);




}

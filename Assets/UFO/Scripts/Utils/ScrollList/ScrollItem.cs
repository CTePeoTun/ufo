using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ScrollItem<InfoType> : PoolObject
{
    public abstract void Init(InfoType info);

}

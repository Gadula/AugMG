using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class JSONSerialize
{
    public string cardType;
    public string product_id;
    public string text;
    public string url;

}

[Serializable]
public class Data
{
    public List<JSONSerialize> json;

}

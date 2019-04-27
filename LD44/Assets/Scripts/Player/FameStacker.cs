using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FameStacker : MonoBehaviour
{

    private int __fameStacked;

    public int convertFameToMoney()
    {
        return __fameStacked;
    }

    public void gainFame()
    {
        __fameStacked++;
    }

    public void addFame(int iValue)
    {
        __fameStacked += iValue;
    }

    public void loseFame()
    {
        __fameStacked--;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

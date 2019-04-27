using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputComponent : MonoBehaviour
{
    private bool _FixedUpdateHappened = false;

    protected abstract void GetInputs(bool fixedUpdateHappened);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs(_FixedUpdateHappened || Mathf.Approximately(Time.timeScale, 0));

        _FixedUpdateHappened = false;
    }

    private void FixedUpdate()
    {
        _FixedUpdateHappened = true;
    }
}

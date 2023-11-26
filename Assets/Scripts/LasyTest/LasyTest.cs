using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasyTest 
{
    private LasyTest2 _lasyTest;

    public LasyTest(LasyTest2 lasyTest)
    {
        _lasyTest = lasyTest;
    }

    public void Execute()
    {
        _lasyTest.Draw();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProduct
{
    bool HasStok();
    void Reserve();
    void Commit();
    void Cancel();
}

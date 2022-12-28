using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectChopping : MonoBehaviour
{
    private Tree _tree;
    private int _cutDownTrees = 0;
    private Accelerometer _accelerometer;

    public delegate void CutDownTree(int numberOfTrees);
    public event CutDownTree CutDownTreeEvent;

    public delegate void Hit();
    public event Hit HitTree;
    // Start is called before the first frame update
    void Start()
    {
        _accelerometer = Accelerometer.Instance;
        _tree = new Tree();
        _tree.CutDown += TreeCutDown;
    }

    public void Reset()
    {
        _cutDownTrees = 0;
    }
    public int CuttedTrees()
    {
        return _cutDownTrees;
    }

    public void StartChoping()
    {
        _accelerometer.OnChop += ShakeDetected;
        _accelerometer.OnSuperChop += SuperShakeDetected;
        _tree = new Tree();
        _tree.CutDown += TreeCutDown;
    }

    public void StopChopping()
    {
        _accelerometer.OnChop -= ShakeDetected;
        _accelerometer.OnSuperChop -= SuperShakeDetected;
    }
    private void OnDestroy()
    {
        _accelerometer.OnChop -= ShakeDetected;
        _accelerometer.OnSuperChop -= SuperShakeDetected;
    }
    private void ShakeDetected()
    {
        Debug.Log("Shake");
        _tree.Hit();
        HitTree?.Invoke();
    }

    private void SuperShakeDetected()
    {
        Debug.Log("Super Shake");
        _tree.SuperHit();
    }

    private void TreeCutDown()
    {
        _tree = new Tree();
        _tree.CutDown += TreeCutDown;
        _cutDownTrees++;
        CutDownTreeEvent?.Invoke(_cutDownTrees);
        Debug.Log("Cut tree number " + _cutDownTrees);
    }
}

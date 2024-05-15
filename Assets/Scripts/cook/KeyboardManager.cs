using UnityEngine;
using UnityEngine.Events;

public class KeyboardManager : MonoBehaviour
{
    // 字母键的 UnityEvents
    public UnityEvent keyDownA, keyDownB, keyDownC, keyDownD, keyDownE, keyDownF, keyDownG,
                      keyDownH, keyDownI, keyDownJ, keyDownK, keyDownL, keyDownM, keyDownN,
                      keyDownO, keyDownP, keyDownQ, keyDownR, keyDownS, keyDownT, keyDownU,
                      keyDownV, keyDownW, keyDownX, keyDownY, keyDownZ;

    // 数字键的 UnityEvents
    public UnityEvent keyDown0, keyDown1, keyDown2, keyDown3, keyDown4,
                      keyDown5, keyDown6, keyDown7, keyDown8, keyDown9;

    // 方向键的 UnityEvents
    public UnityEvent keyDownUp, keyDownDown, keyDownLeft, keyDownRight;

    void Update()
    {
        // 检测并响应字母键
        if (Input.GetKeyDown(KeyCode.A)) keyDownA.Invoke();
        if (Input.GetKeyDown(KeyCode.B)) keyDownB.Invoke();
        if (Input.GetKeyDown(KeyCode.C)) keyDownC.Invoke();
        if (Input.GetKeyDown(KeyCode.D)) keyDownD.Invoke();
        if (Input.GetKeyDown(KeyCode.E)) keyDownE.Invoke();
        if (Input.GetKeyDown(KeyCode.F)) keyDownF.Invoke();
        if (Input.GetKeyDown(KeyCode.G)) keyDownG.Invoke();
        if (Input.GetKeyDown(KeyCode.H)) keyDownH.Invoke();
        if (Input.GetKeyDown(KeyCode.I)) keyDownI.Invoke();
        if (Input.GetKeyDown(KeyCode.J)) keyDownJ.Invoke();
        if (Input.GetKeyDown(KeyCode.K)) keyDownK.Invoke();
        if (Input.GetKeyDown(KeyCode.L)) keyDownL.Invoke();
        if (Input.GetKeyDown(KeyCode.M)) keyDownM.Invoke();
        if (Input.GetKeyDown(KeyCode.N)) keyDownN.Invoke();
        if (Input.GetKeyDown(KeyCode.O)) keyDownO.Invoke();
        if (Input.GetKeyDown(KeyCode.P)) keyDownP.Invoke();
        if (Input.GetKeyDown(KeyCode.Q)) keyDownQ.Invoke();
        if (Input.GetKeyDown(KeyCode.R)) keyDownR.Invoke();
        if (Input.GetKeyDown(KeyCode.S)) keyDownS.Invoke();
        if (Input.GetKeyDown(KeyCode.T)) keyDownT.Invoke();
        if (Input.GetKeyDown(KeyCode.U)) keyDownU.Invoke();
        if (Input.GetKeyDown(KeyCode.V)) keyDownV.Invoke();
        if (Input.GetKeyDown(KeyCode.W)) keyDownW.Invoke();
        if (Input.GetKeyDown(KeyCode.X)) keyDownX.Invoke();
        if (Input.GetKeyDown(KeyCode.Y)) keyDownY.Invoke();
        if (Input.GetKeyDown(KeyCode.Z)) keyDownZ.Invoke();

        // 检测并响应数字键
        if (Input.GetKeyDown(KeyCode.Alpha0)) keyDown0.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha1)) keyDown1.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha2)) keyDown2.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha3)) keyDown3.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha4)) keyDown4.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha5)) keyDown5.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha6)) keyDown6.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha7)) keyDown7.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha8)) keyDown8.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha9)) keyDown9.Invoke();

        // 检测并响应方向键
        if (Input.GetKeyDown(KeyCode.UpArrow)) keyDownUp.Invoke();
        if (Input.GetKeyDown(KeyCode.DownArrow)) keyDownDown.Invoke();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) keyDownLeft.Invoke();
        if (Input.GetKeyDown(KeyCode.RightArrow)) keyDownRight.Invoke();
    }
}

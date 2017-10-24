using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIPopup_Update1 : UIPopup
{
    #region VARIABLES
    private Text _txtInfo;
    #endregion


    #region METHODS - reserved
    protected override void Awake()
    {
        base.Awake();

        _txtInfo = base.Find<Text>("Dialog/Text");
    }

    public override void Init(params object[] args_)
    {
        base.Init(args_);

        if (args_.IsNullOrEmpty())
            return;

        _txtInfo.text = (string)args_[0];
    }
    #endregion


    #region METHODS - base
    public override void Show()
    {
        base.Show();
        base.SetSizedelta();
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationPanel
{
    public InformationPanel(int gameLevel, int gameTry, int gamePoints, InformationPanelDrawer darwer)
    {
        GameLevel = gameLevel;
        GameTry = gameTry;
        GamePoints = gamePoints;
        Drawer = darwer;
        Drawer.UpdateDisplayUI(this);
    }

    public int GameLevel { get; private set; }
    public int GameTry { get; private set; }
    public int GamePoints { get; private set; }
    public InformationPanelDrawer Drawer { get; private set; }

    public void Change(DataField dataField, int point)
    {
        switch (dataField)
        {
            case DataField.GameLevel:
                GameLevel += point;
                break;
            case DataField.gameTry:
                GameTry += point;
                break;
            case DataField.gamePoints:
                GamePoints += point;
                break;
        }
        Drawer.UpdateDisplayUI(this);
    }

    public enum DataField
    {
        GameLevel,
        gameTry,
        gamePoints
    }
}

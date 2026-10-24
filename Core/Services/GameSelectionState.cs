using Core.Models;

namespace Core.Services;

public class GameSelectionState
{
    public event Action OnChangeGame;
    public event Action OnChangeVersionGroup;

    public Game? SelectedGame
    {
        get;
        set
        {
            field = value;
            OnChangeGame?.Invoke();
        }
    }

    public VersionGroup? SelectedVersionGroup
    {
        get;
        set
        {
            field = value;
            OnChangeVersionGroup?.Invoke();
        }
    }
}
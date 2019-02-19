namespace MBRD.Component
{
    interface IStateService
    {
        void ChangeState(GameState newState);
        GameState GetCurrentState();
    }
}

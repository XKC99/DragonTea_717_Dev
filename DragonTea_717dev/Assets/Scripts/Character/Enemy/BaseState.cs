

public abstract class BaseState 
{
    protected BaseEnemy currentEnemy;
    public abstract void Enter(BaseEnemy enemy);
    public abstract void Exit();
    public abstract void LogicUpdate();
    public abstract void PhysicsUpdate();
}

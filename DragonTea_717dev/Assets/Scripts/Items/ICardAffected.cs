/// <summary>
/// 卡牌效果作用逻辑
/// </summary>
public interface ICardAffected 
{
    /// <summary>
    /// 根据 cardType 自行处理相关逻辑
    /// </summary>
    /// <param name="card"></param>
    /// <returns>生效的卡牌返回 true</returns>
    bool Execute(Card card);
}
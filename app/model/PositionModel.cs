public class PositionModel
{
    private int positionId;
    private string positionName = "";

    public void SetPositionId(int id)
    {
        positionId = id;
    }

    public int GetPositionId()
    {
        return positionId;
    }

    public void SetPositionName(string model)
    {
        positionName = model;
    }

    public string GetPositionName()
    {
        return positionName;
    }
}
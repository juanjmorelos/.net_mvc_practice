public class EmployeeModel
{
    private string name = "";
    private string lastName = "";
    private string position = "";

    public void SetName(string value)
    {
        name = value;
    }

    public string GetName()
    {
        return name;
    }

    public void SetLastName(string value)
    {
        lastName = value;
    }

    public string GetLastName()
    {
        return lastName;
    }

    public void SetPosition(string value)
    {
        position = value;
    }

    public string GetPosition()
    {
        return position;
    }
}

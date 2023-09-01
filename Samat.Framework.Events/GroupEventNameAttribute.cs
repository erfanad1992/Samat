namespace Samat.Framework.Events;

public class GroupEventNameAttribute : Attribute
{
    public string GroupType { get; set; }

    public GroupEventNameAttribute(GroupType groupType)
    {
        GroupType = groupType.ToString();
    }

    public GroupEventNameAttribute(string groupName)
    {
        GroupType = groupName;
    }
}
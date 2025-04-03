namespace Repo.Public.Specs
{
    public enum ChildrenInclude
    {
        None,           // Nothing included
        Flat,           // 1:1 relations included
        Immediate,      // One level of children included
        Nested,         // Full nested tree structure included
    }
}

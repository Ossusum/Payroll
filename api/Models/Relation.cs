using System.ComponentModel;

namespace WebApplication8.api.Model
{
    public enum Relation
    {
        [Description("Spouse")]
        Spouse = 0,

        [Description("Child")]
        Child = 1
    }
}

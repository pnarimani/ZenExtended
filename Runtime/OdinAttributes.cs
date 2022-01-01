// Dummy classes for when odin is not installed

#if !ODIN_INSPECTOR
using System;

namespace ZenExtended
{
    internal class BoxGroupAttribute : Attribute
    {
        public BoxGroupAttribute(string _)
        {
        }

        public BoxGroupAttribute()
        {
            
        }
    }

    internal class ShowIfAttribute : Attribute
    {
        public ShowIfAttribute(string _)
        {
        }
    }

    internal class InlinePropertyAttribute : Attribute
    {
    }
    
    
    internal class HideLabelAttribute : Attribute
    {
    }

#if !NAUGHTY_ATTRIBUTES
    internal class ValueDropdownAttribute : Attribute
    {
        public ValueDropdownAttribute(string _)
        {
            
        }
    }  
#endif
}
#endif
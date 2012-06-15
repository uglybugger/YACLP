using System;

namespace Yaclp
{
    public interface ITypeConverter
    {
        object Convert(string value, Type toType);
    }
}
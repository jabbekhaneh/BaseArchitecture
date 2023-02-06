global using FizzWare.NBuilder;
using System;

namespace Portal.Application.UnitTests.Configs.Builders;

public abstract class ReflectionBuilder<T>
{
    
    protected static Random random = new Random();
    protected T Builder;
    public abstract T Build();
    

}

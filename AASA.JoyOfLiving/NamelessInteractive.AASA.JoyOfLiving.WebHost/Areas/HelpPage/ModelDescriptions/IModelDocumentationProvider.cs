using System;
using System.Reflection;

namespace NamelessInteractive.AASA.JoyOfLiving.WebHost.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}
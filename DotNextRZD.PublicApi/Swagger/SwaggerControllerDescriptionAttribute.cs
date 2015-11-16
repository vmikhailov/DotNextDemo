using System;

namespace DotNextRZD.PublicApi.Swagger
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SwaggerControllerDescriptionAttribute : Attribute
    {
        public SwaggerControllerDescriptionAttribute(string description)
        {
            ControllerDescription = description;
        }

        public SwaggerControllerDescriptionAttribute(string tag, string description)
        {
            ControllerTag = tag;
            ControllerDescription = description;
        }

        public string ControllerTag { get; private set; }

        public string ControllerDescription { get; private set; }
    }
}
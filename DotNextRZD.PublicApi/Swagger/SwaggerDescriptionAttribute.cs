using System;

namespace DotNextRZD.PublicApi.Swagger
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SwaggerDescriptionAttribute : Attribute
    {
        public SwaggerDescriptionAttribute(string description)
        {
            ControllerDescription = description;
        }

        public SwaggerDescriptionAttribute(string tag, string description)
        {
            ControllerTag = tag;
            ControllerDescription = description;
        }

        public string ControllerTag { get; private set; }

        public string ControllerDescription { get; private set; }
    }
}
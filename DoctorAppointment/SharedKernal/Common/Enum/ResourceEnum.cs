using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Common.Enum
{
    public class ResourceEnum
    {

        /// <summary>
        /// Localization Type used to identify whether the resource type.
        /// </summary>
        public enum LocalizationType
        {
            [EnumMessage("Controls")]
            Controls = 1,
            [EnumMessage("Actions")]
            Actions = 2,
            [EnumMessage("ValidationMessage")]
            ValidationMessage = 3,
            [EnumMessage("Messages_{0}")]
            Message = 4,
            [EnumMessage("IntegrationMessage")]
            IntegrationMessage = 5
        }


    }
}

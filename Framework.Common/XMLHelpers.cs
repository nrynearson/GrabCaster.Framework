﻿// --------------------------------------------------------------------------------------------------
// <copyright file = "XMLHelpers.cs" company="Nino Crudele">
//   Copyright (c) 2013 - 2015 Nino Crudele. All Rights Reserved.
// </copyright>
// <summary>
//    Copyright (c) 2013 - 2015 Nino Crudele
//    Blog: http://ninocrudele.me
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License. 
// </summary>
// --------------------------------------------------------------------------------------------------
namespace GrabCaster.Framework.Common
{
    using System.Xml;

    /// <summary>
    /// TODO The xml helpers.
    /// </summary>
    public static class XmlHelpers
    {
        /// <summary>
        /// The add attribute.
        /// </summary>
        /// <param name="xmlDocument">
        /// The xml document.
        /// </param>
        /// <param name="xmlElement">
        /// The xml element.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public static void AddAttribute(XmlDocument xmlDocument, XmlElement xmlElement, string name, string value)
        {
            var xmlAttribute = xmlDocument.CreateAttribute(name);
            xmlAttribute.Value = value;
            xmlElement.Attributes.Append(xmlAttribute);
        }
    }
}
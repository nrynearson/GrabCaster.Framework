﻿// --------------------------------------------------------------------------------------------------
// <copyright file = "SerializationHelper.cs" company="Nino Crudele">
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
namespace GrabCaster.Framework.Serialization.Xml
{
    using System;
    using System.Collections.Generic;

    using GrabCaster.Framework.Contracts.Bubbling;
    using GrabCaster.Framework.Contracts.Channels;
    using GrabCaster.Framework.Contracts.Configuration;
    using GrabCaster.Framework.Contracts.Points;

    using Newtonsoft.Json;

    /// <summary>
    /// TODO The serialization helper.
    /// </summary>
    public static class SerializationHelper
    {
        /// <summary>
        /// TODO The crete json trigger configuration template.
        /// </summary>
        /// <param name="BubblingEvent">
        /// TODO The bubbling event.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string CreteJsonTriggerConfigurationTemplate(BubblingEvent BubblingEvent)
        {
            var eventCorrelationTemplate = new Event(
                "{Event component ID to execute if Correlation = true}", 
                "{Configuration ID to execute if Correlation = true}", 
                "EventName", 
                "EventDescription");
            try
            {
                var triggerConfiguration = new TriggerConfiguration();
                triggerConfiguration.Trigger = new Trigger(
                    BubblingEvent.IdComponent, 
                    BubblingEvent.Name, 
                    BubblingEvent.Description);
                triggerConfiguration.Trigger.TriggerProperties = new List<TriggerProperty>();
                foreach (var Property in BubblingEvent.Properties)
                {
                    if (Property.Name != "DataContext")
                    {
                        var triggerProperty = new TriggerProperty(Property.Name, "Value to set");
                        triggerConfiguration.Trigger.TriggerProperties.Add(triggerProperty);
                    }
                }

                triggerConfiguration.Events = new List<Event>();

                // 1*
                var eventTriggerTemplate = new Event(
                    "{Event component ID to execute}", 
                    "{Configuration ID to execute}", 
                    "Event Name", 
                    "Event Description");
                eventTriggerTemplate.Channels = new List<Channel>();
                var points = new List<Point>();
                points.Add(new Point("Point ID", "Point Name", "Point Description"));
                eventTriggerTemplate.Channels.Add(
                    new Channel("Channel ID", "Channel Name", "Channel Description", points));

                eventCorrelationTemplate.Channels = new List<Channel>();
                eventCorrelationTemplate.Channels.Add(
                    new Channel("Channel ID", "Channel Name", "Channel Description", points));

                triggerConfiguration.Events.Add(eventTriggerTemplate);

                var events = new List<Event>();
                events.Add(eventCorrelationTemplate);
                eventTriggerTemplate.Correlation = new Correlation("Correlation Name", "C# script", events);

                var serializedMessage = JsonConvert.SerializeObject(
                    triggerConfiguration, 
                    Formatting.Indented, 
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                // string serializedMessage = JsonConvert.SerializeObject(triggerConfiguration);
                return serializedMessage;

                // return "<![CDATA[" + serializedMessage + "]]>";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// TODO The crete json event configuration template.
        /// </summary>
        /// <param name="BubblingEvent">
        /// TODO The bubbling event.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string CreteJsonEventConfigurationTemplate(BubblingEvent BubblingEvent)
        {
            try
            {
                var eventConfiguration = new EventConfiguration();
                eventConfiguration.Event = new Event(
                    BubblingEvent.IdComponent, 
                    "{Configuration ID to execute}", 
                    BubblingEvent.Name, 
                    BubblingEvent.Description);

                eventConfiguration.Event.EventProperties = new List<EventProperty>();
                foreach (var Property in BubblingEvent.Properties)
                {
                    if (Property.Name != "DataContext")
                    {
                        var eventProperty = new EventProperty(Property.Name, "Value to set");
                        eventConfiguration.Event.EventProperties.Add(eventProperty);
                    }
                }

                var eventCorrelationTemplate = new Event(
                    "{Event component ID to execute if Correlation = true}", 
                    "{Configuration ID to execute if Correlation = true}", 
                    "EventName", 
                    "EventDescription");
                eventCorrelationTemplate.Channels = new List<Channel>();
                var points = new List<Point>();
                points.Add(new Point("Point ID", "Point Name", "Point Description"));
                eventCorrelationTemplate.Channels.Add(
                    new Channel("Channel ID", "Channel Name", "Channel Description", points));

                var events = new List<Event>();
                events.Add(eventCorrelationTemplate);
                eventConfiguration.Event.Channels = new List<Channel>();
                eventConfiguration.Event.Channels.Add(
                    new Channel("Channel ID", "Channel Name", "Channel Description", points));

                eventConfiguration.Event.Correlation = new Correlation("Correlation Name", "C# script", events);

                var serializedMessage = JsonConvert.SerializeObject(
                    eventConfiguration, 
                    Formatting.Indented, 
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                return serializedMessage;

                // return "<![CDATA[" + serializedMessage + "]]>";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model.Devices.Property
{
    public class PropetryCollection: IPropetryCollection
    {
        public PropetryCollection()
        {
        }

        public PropetryCollection(IEnumerable<IProperty> properties)
        {
            Properties = properties;
        }
        public IEnumerable<IProperty>? Properties { get; set; } = new List<IProperty>();
    }

    public class DeviceProperty : IProperty
    {
        public DeviceProperty()
        {
        }

        public DeviceProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;

    }
    public interface IPropetryCollection
    {
        IEnumerable<IProperty>? Properties { get; }
    }
    public interface IProperty
    {
        string Name { get; }
        string Value { get; }
    }

    public enum PropertyType
    {
        SN,
        Address,
        DeviceType
    };

    public class DeviceType
    {
        static DeviceType() { }

        public static readonly Dictionary<int, string> dictionary = new()
        {
        { 1, "Счетчик ЭЭ Миртек 1ф" },
        { 2, "Счетчик ЭЭ Миртек 3ф" },
        { 3, "Меркурий 203" },
        { 4, "Меркурий 230" },
        { 5, "Меркурий 234" },
        { 6, "РиМ 189" },
        { 7, "Милур 107" }
        };
    }
}

namespace CommonTypeDevice
{
    public class Register
    {
        public string LogicalName { set; get; } = string.Empty;
        public double Value { set; get; }
        public uint Unit { set; get; }
    }

    public class DeviceEvent
    {
        public List<EventParameter> EventParameters = [];
        // public List<EventParameter> AdditionalParameters = [];
        public DateTime DateTime { set; get; }
    }

    public class EventParameter
    {
        public string Name { set; get; } = string.Empty;
        public string Value { set; get; } = string.Empty;
    }

    public enum EventParameterType
    {
        SN,
        Address,
        TypeEvent
    };

    public class CommonEvent
    {

        static CommonEvent() { }

        public static readonly Dictionary<int, string> dictionary = new()
        {
        { 0x00010002, "Перезагрузка устройства" },
        { 0x000B0001, "Вскрытие пломбы клеммной крышки" },
        { 0x000B0002, "Вскрытие пломбы корпуса" },
        { 0x000B0003, "Вскрытие пломбы отсека сменного модуля" },
        { 0x000B0004, "Сброс состояний пломб" },
        { 0x00030001, "Попытка несанкционированного доступа" },
        { 0x00040001, "Отключение реле нагрузки по превышению лимита активной мощности" },
        { 0x00040002, "Отключение реле нагрузки по превышению напряжения" },
        { 0x00050002, "Изменение заводского номера счетчика" },
        { 0x00050003, "Изменение связного адреса счетчика" },
        { 0x00070002, "Время изменено" },
        { 0x00090001, "Пропадание фазного напряжения фазы A" },
        { 0x00090002, "Пропадание фазного напряжения фазы B" },
        { 0x00090003, "Пропадание фазного напряжения фазы C" },
        { 0x000A0019, "Фаза А - превышение максимального тока" },
        { 0x000A001B, "Фаза В - превышение максимального тока" },
        { 0x000A001D, "Фаза С - превышение максимального тока" },
        { 0x000C0001, "Превышение напряжения - порог №1" },
        { 0x000C0002, "Превышение напряжения - порог №2" },
        { 0x000E0001, "Превышение максимального тока прибора" },
        { 0x000F0001, "Превышение установленного порога" },
        { 0x00130001, "Батарея заряжена" },
        { 0x00150001, "Срабатывание сигнализации" }
        };
    }

    public class UnitType
    {

        static UnitType() { }

        public static readonly Dictionary<int, string> dictionary = new()
        {
        { 1, "В" },
        { 2, "А" },
        { 3, "Вт*ч" },
        { 4, "Вт*ч" }
        };
    }
}

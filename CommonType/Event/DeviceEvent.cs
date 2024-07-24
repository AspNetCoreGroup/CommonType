﻿namespace CommonTypeDevice.Event
{
    public class EventDictionary
    {

        static EventDictionary() { }

        public static readonly Dictionary<int, string> dictionary = new()
        {
        { 1, "Перезагрузка устройства" },
        { 2, "Вскрытие пломбы клеммной крышки" },
        { 3, "Вскрытие пломбы корпуса" },
        { 4, "Вскрытие пломбы отсека сменного модуля" },
        { 5, "Сброс состояний пломб" },
        { 6, "Попытка несанкционированного доступа" },
        { 7, "Отключение реле нагрузки по превышению лимита активной мощности" },
        { 8, "Отключение реле нагрузки по превышению напряжения" },
        { 9, "Изменение заводского номера счетчика" },
        { 10, "Изменение связного адреса счетчика" },
        { 11, "Время изменено" },
        { 12, "Пропадание фазного напряжения фазы A" },
        { 13, "Пропадание фазного напряжения фазы B" },
        { 14, "Пропадание фазного напряжения фазы C" },
        { 15, "Фаза А - превышение максимального тока" },
        { 16, "Фаза В - превышение максимального тока" },
        { 17, "Фаза С - превышение максимального тока" },
        { 18, "Превышение напряжения - порог №1" },
        { 19, "Превышение напряжения - порог №2" },
        { 20, "Превышение максимального тока прибора" },
        { 21, "Превышение установленного порога" },
        { 22, "Батарея заряжена" },
        { 23, "Срабатывание сигнализации" }
        };
    }

    public class DeviceEvent
    {
        public List<EventItem> EventParameters { set; get; } = new();
        public DateTime DateTime { set; get; }
    }

    public class EventItem
    {
        public int Key { set; get; }
        public string Name { set; get; } = string.Empty;
    }
}
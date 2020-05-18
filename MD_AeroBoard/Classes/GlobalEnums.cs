using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_AeroBoard
{
    public enum FlightType
    {
        [Description("Неизвестно")]
        Unknown = 0,
        [Description("Ту-134")] // 80-96
        TU134 = 1,
        [Description("Ту-154")] // 152-158
        TU154 = 2,
        [Description("Ту-154Э")] // 180
        TU154E = 3,
        [Description("Ту-204")] // 196-214
        TU204 = 4,
        [Description("SukhoiSuperJet-100")] // 86
        SSJ95 = 5,
        [Description("Ту-134")] // 96
        SSJ95LR = 6,
        [Description("Ил-62")] // 198
        IL62 = 7,
        [Description("Ил-86")] // 314
        IL86 = 8,
        [Description("Ил-96")] // 300
        IL96 = 9,
        [Description("Ил-96М")] // 435
        IL96M = 10,
        [Description("A-310")] // 183
        Aerobus310 = 11,
        [Description("A-320")] // 149
        Aerobus320 = 12,
        [Description("A-330")] // 440
        Aerobus330 = 13,
        [Description("Boeing-737-600")] // 122
        Boeing7376 = 14,
        [Description("Boeing-737-700")] // 140
        Boeing7377 = 15,
        [Description("Boeing-737-800")] // 175
        Boeing7378 = 16,
        [Description("Boeing-737-900ER")] // 192
        Boeing7379ER = 17,
        [Description("Boeing-747")] // 370
        Boeing747 = 18,
        [Description("Boeing-767")] // 252
        Boeing767 = 19,
        [Description("Boeing-777")] // 235
        Boeing777 = 20,
        [Description("Embraer-170")] // 78
        Embraer170 = 21

    }


    public enum CityType
    {
        [Description("Неизвестно")]
        Unknown = 0,
        [Description("Москва")]
        Moscow = 1,
        [Description("Пермь")]
        Perm = 2,
        [Description("Иркутск")]
        Irkutsk = 3,
        [Description("Воронеж")]
        Voronezh = 4,
        [Description("Екатеринбург")]
        Ekaterinburg = 5,
        [Description("Тюмень")]
        Tjumen = 6,
        [Description("Самара")]
        Samara = 7,
        [Description("Калининград")]
        Kaliningrad = 8,
        [Description("Челябинск")]
        Chelyabinsk = 9,
        [Description("Сургут")]
        Surgut = 10,
        [Description("Уфа")]
        Ufa = 11,
        [Description("Новосибирск")]
        Novosibirsk = 12,
        [Description("Волгоград")]
        Volgograd = 13,
        [Description("Адлер")]
        Adler = 14,
        [Description("Сочи")]
        Sochi = 15,
        [Description("Белгород")]
        Belgorod = 16
    }

    public enum DirectionType
    {
        [Description("Прибытие")]
        Arrival=1,
        [Description("Вылет")]
        Departure=2,
        [Description("Неизвестно")]
        Unknown=0
    }


    public enum DirectionStatusType
    {
        [Description("Прибыл")]
        Arrived,
        [Description("Прибывает")]
        Arriving,
        [Description("Вылетел")]
        Departured,
        [Description("Осуществляется посадка")]
        InPlane,
        [Description("Неизвестно")]
        Unknown,
        [Description("Отменён")]
        Canceled,
        [Description("Задержан")]
        Delayed
    }


}

namespace OohelpWebApps.Presentations.ApiClient.Entities.Common.Enums;

public enum IconStyle
{
    //старые стили (ссылка на базовую прозрачную картинку, цвет в тело маркера)
    OldDrop = 0,
    OldCircle = 1,

    //новые стили (ссылка на картинку google, цвет в тело ссылки)
    Drop = 10,
    Circle = 11,
    Point = 12,

    Billboard = 30,
    House = 31,

    //указатель в SVG, картинка в маркер пишется как Path, цвет в тело маркера
    Arrow = 100
}

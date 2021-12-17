
using UnityEngine;

namespace Skipin2D
{ // создаем класс расширения и изменения Vector3
    public static class Utils
    {
        // У нас есть вектор3 , который мы передаем в функцию , проверяем есть ли какие координаты х, у, z.И если координаты изменены,
        //то возвразаем новый вектор3 с изменеными координатмаи , есди кординавты не менядись, то возвращаем, какие были.
        public static Vector3 Change(this Vector3 org, object x = null, object y = null, object z = null)
        {
            //через тернарные операции ? и : мы либо возращаем что пришло либо возращаем координаты.
            return new Vector3(x == null ? org.x:(float)x, y == null ? org.y : (float)y, z == null ? org.z :(float)z) ;
        }

    }
}
